using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuego : MonoBehaviour {

	public int puntuacionMaxima = 0;
	public int objetosCanasta = 0;
	public string [] listaIngredientes = new string[5]{"vacio","vacio","vacio","vacio","vacio"} ;
	public string [] recetaCargar= new string[6]{"vacio","vacio","vacio","vacio","vacio","vacio"};
	public static EstadoJuego estadoJuego;
	private String rutaArchivo;

	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos.dat"; //carga la ruta de los puntos
		//condicion para saber si ya hay una instancia del objeto, si la hay
		//entonces la elimina, sino la crea, asi se pasa un objeto entre escenas
		if(estadoJuego==null){
			estadoJuego = this;
			DontDestroyOnLoad(gameObject);
		}else if(estadoJuego!=this){
			Destroy(gameObject);
		} 
	}

	// Use this for initialization
	void Start () {
		Cargar();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Guardar(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(rutaArchivo);
		
		DatosAGuardar datos = new DatosAGuardar();
		datos.puntuacionMaxima = puntuacionMaxima;
		datos.objetosCanasta = objetosCanasta;
		datos.listaIngredientes = listaIngredientes;
		datos.recetaCargar = recetaCargar;
		
		bf.Serialize(file, datos);
		
		file.Close();
	}
	
	void Cargar(){
		if(File.Exists(rutaArchivo)){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(rutaArchivo, FileMode.Open);
			
			DatosAGuardar datos = (DatosAGuardar) bf.Deserialize(file);
			
			puntuacionMaxima = datos.puntuacionMaxima;
			objetosCanasta = datos.objetosCanasta;
			listaIngredientes = datos.listaIngredientes;
			recetaCargar = datos.recetaCargar;

			
			file.Close();
		}else{
			puntuacionMaxima = 0;
			objetosCanasta = 0;
			listaIngredientes = new string[]{"vacio","vacio","vacio","vacio","vacio"};
			recetaCargar= new string[6]{"vacio","vacio","vacio","vacio","vacio","vacio"};

		}
	}
} //cierre de clase

[Serializable]
class DatosAGuardar{
	public int puntuacionMaxima; //se declaran los datos a guardar
	public int objetosCanasta;
	public string [] listaIngredientes = new string[5]{"vacio","vacio","vacio","vacio","vacio"};
	public string [] recetaCargar= new string[6]{"vacio","vacio","vacio","vacio","vacio","vacio"};
}
