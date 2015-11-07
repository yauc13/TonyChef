using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	/**
		Esta clase es la encargada de capturar las notificaciones que desde los otros 
		GameObjects se realizan para luego ser mostrados en pantalla.
		ademas se encarga de guardar cambios en los valores persistentes
		
	 **/

	public int puntuacion = 0;
	public int puntuacionAcumulada=0;
	public int numIngredientes=0;
	public string nomReceta="Ninguna";
	public string [] recetaCargar= new string[6]{"vacio","vacio","vacio","vacio","vacio","vacio"};
	public string [] listIngreCargar= new string[5]{"vacio","vacio","vacio","vacio","vacio"};
	public TextMesh marcador;
	public TextMesh acumulado;
	public TextMesh ingredientes;
	public TextMesh nombreReceta;
	//para cargar los ingredientes
	public Transform manzanaTransform;	
	public Transform papaamarillaTransform;
	public Transform papanegraTransform;
	public Transform remolachaTransform;
	public Transform tomateTransform;
	public Transform mandarinaTransform;
	public Transform uvasTransform;
	public Transform bananoTransform;
	public Transform manzanaA12Transform;
	public Transform manzanaB12Transform;
	public Transform manzanaQA12AA14Transform;
	public Transform manzanaQA12AB14Transform;
	public Transform manzanaQB12AA14Transform;
	public Transform manzanaQB12AB14Transform;

	
	// Use this for initialization
	void Start () {

		//recibe el valor que se envio desde el script del componente Receta
		NotificationCenter.DefaultCenter().AddObserver(this, "cortarCuchillo");
		NotificationCenter.DefaultCenter().AddObserver(this, "getReceta");
		NotificationCenter.DefaultCenter().AddObserver(this, "limpiarReceta");
		NotificationCenter.DefaultCenter().AddObserver(this, "limpiarIngredientes");
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter().AddObserver(this, "terminaReceta");
		NotificationCenter.DefaultCenter().AddObserver(this, "agregarIngrediente");
		NotificationCenter.DefaultCenter().AddObserver(this, "listaIngredientes");
		ActualizarMarcador();
		cargarIngredientes();
	}

	void getReceta(Notification notificacion){
		string [] obtenerReceta = (string[])notificacion.data;
		for(int i=0; i<obtenerReceta.Length;i++){
			Debug.Log("Contenido Receta:"+obtenerReceta[i]);
		}
		
		EstadoJuego.estadoJuego.recetaCargar= obtenerReceta;
		EstadoJuego.estadoJuego.Guardar();
	}

	void terminaReceta(Notification notificacion){
		Debug.Log("puntuacion maxima "+EstadoJuego.estadoJuego.puntuacionMaxima);
		int puntosAGuardar = (int)notificacion.data;
		Debug.Log("puntuacion actual "+puntosAGuardar);
		EstadoJuego.estadoJuego.puntuacionMaxima += puntosAGuardar;
		EstadoJuego.estadoJuego.Guardar();  //para guardar el puntaje cuando la receta desaparece
	}

	
	void IncrementarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion=puntosAIncrementar;
		ActualizarMarcador();
	}

	void agregarIngrediente(Notification notificacion){
		Debug.Log("numero ingredientes :"+EstadoJuego.estadoJuego.objetosCanasta);
		int puntosAGuardar = (int)notificacion.data;
		numIngredientes = puntosAGuardar;
		ActualizarMarcador();
	}

	void listaIngredientes(Notification notificacion){

		string [] listaingredientes = (string[])notificacion.data;
		for(int i=0; i<listaingredientes.Length;i++){
			Debug.Log("lista ingredientes:"+listaingredientes[i]);
		}

		EstadoJuego.estadoJuego.listaIngredientes = listaingredientes;
		EstadoJuego.estadoJuego.Guardar();

	}

	void limpiarIngredientes(Notification notificacion){
		bool lim= (bool)notificacion.data;
		if(lim ==true){
		listIngreCargar= new string[5]{"vacio","vacio","vacio","vacio","vacio"};
		EstadoJuego.estadoJuego.listaIngredientes = listIngreCargar;
		EstadoJuego.estadoJuego.Guardar();
		}
	}

	void limpiarReceta(Notification notificacion){
		bool lim= (bool)notificacion.data;
		if(lim ==true){
			recetaCargar= new string[6]{"vacio","vacio","vacio","vacio","vacio","vacio"};
			EstadoJuego.estadoJuego.recetaCargar = recetaCargar;
			EstadoJuego.estadoJuego.Guardar();
		}
	}


	
	void ActualizarMarcador(){
		if(acumulado!= null && marcador!= null && ingredientes!= null && nombreReceta!=null){
			puntuacionAcumulada =EstadoJuego.estadoJuego.puntuacionMaxima;
			acumulado.text = puntuacionAcumulada.ToString();
			marcador.text = puntuacion.ToString();
			ingredientes.text = numIngredientes.ToString();
			nomReceta =EstadoJuego.estadoJuego.recetaCargar[1];
			Debug.Log("nombre de la receta :"+nomReceta);
			nombreReceta.text = nomReceta;
		}else if (acumulado !=null && marcador==null && ingredientes!=null){

			Debug.Log("numero ingredientes a mostrar pantalla :"+numIngredientes);
			ingredientes.text = numIngredientes.ToString();
			puntuacionAcumulada =EstadoJuego.estadoJuego.puntuacionMaxima;
			acumulado.text = puntuacionAcumulada.ToString();
		}else if (nombreReceta!=null){
			

			nomReceta =EstadoJuego.estadoJuego.recetaCargar[1];
			Debug.Log("nombre de la receta :"+nomReceta);
			nombreReceta.text = nomReceta;
			

		}
		else{
			Debug.Log("NO ENTRO A LOS IF");
		}

		Debug.Log("FIN DEL LOS IF");
	
	}

	void cargarIngredientes(){
		listIngreCargar= EstadoJuego.estadoJuego.listaIngredientes;
		for(int i=0; i<listIngreCargar.Length;i++){
			Debug.Log("lista ingredientes cargados:"+listIngreCargar[i]);
			if(listIngreCargar[i]=="mazzana" && manzanaTransform!=null){
				var manzanaObjeto = Instantiate (manzanaTransform) as Transform;
				manzanaObjeto.position = new Vector3(-6,-2,0);
			}
			if(listIngreCargar[i]=="papaamarilla" && papaamarillaTransform!=null){
				var papaamarillaObjeto = Instantiate (papaamarillaTransform) as Transform;
				papaamarillaObjeto.position = new Vector3(-6,-1,0);
			}
			if(listIngreCargar[i]=="papanegra" && papanegraTransform!=null){
				var papanegraObjeto = Instantiate (papanegraTransform) as Transform;
				papanegraObjeto.position = new Vector3(-6,0,0);
			}
			if(listIngreCargar[i]=="remolacha" && remolachaTransform!=null){
				var remolachaObjeto = Instantiate (remolachaTransform) as Transform;
				remolachaObjeto.position = new Vector3(-6,1,0);
			}
			if(listIngreCargar[i]=="tomate" && tomateTransform!=null){
				var tomateObjeto = Instantiate (tomateTransform) as Transform;
				tomateObjeto.position = new Vector3(-3,-2,0);
			}
			if(listIngreCargar[i]=="mandarina" && mandarinaTransform!=null){
				var mandarinaObjeto = Instantiate (mandarinaTransform) as Transform;
				mandarinaObjeto.position = new Vector3(-3,-1,0);
			}
			if(listIngreCargar[i]=="uvas" && uvasTransform!=null){
				var uvasObjeto = Instantiate (uvasTransform) as Transform;
				uvasObjeto.position = new Vector3(-3,0,0);
			}
			if(listIngreCargar[i]=="banano" && bananoTransform!=null){
				var bananoObjeto = Instantiate (bananoTransform) as Transform;
				bananoObjeto.position = new Vector3(-3,1,0);
			}

		}
	}


	void cortarCuchillo(Notification notificacion){
		string ingreCortado = (string)notificacion.data;
		int longi= ingreCortado.Length;
		Debug.Log("ingrediente Cortado que llega de notificacion: "+ingreCortado+" Tamano: "+longi);
		if(ingreCortado.Contains("mazzana(Clone)") && manzanaA12Transform!=null && manzanaB12Transform!=null){
			var manzanaA12Objeto = Instantiate (manzanaA12Transform) as Transform;
			var manzanaB12Objeto = Instantiate (manzanaB12Transform) as Transform;
			Debug.Log("[Instancia] ....manzanaA12  manzanaB12 ");
			manzanaA12Objeto.position = new Vector3(0.8f, 3.5f,0f);
			manzanaB12Objeto.position = new Vector3(3f, 3.5f,0f);
		} else if(ingreCortado.Contains("manzanaA12(Clone)") && manzanaQA12AA14Transform!=null && manzanaQA12AB14Transform!=null){
			var manzanaQA12AA14Objeto = Instantiate (manzanaQA12AA14Transform) as Transform;
			var manzanaQA12AB14Objeto = Instantiate (manzanaQA12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....manzanaA12AA14  manzanaA12AB14  primeros cuartos ");
			manzanaQA12AA14Objeto.position = new Vector3(0.8f, 3.5f,0f);
			manzanaQA12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			manzanaQA12AB14Objeto.position = new Vector3(3f, 3.5f,0f);
			manzanaQA12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}else if(ingreCortado.Contains("manzanaB12(Clone)") && manzanaQB12AA14Transform!=null && manzanaQB12AB14Transform!=null){
			var manzanaQB12AA14Objeto = Instantiate (manzanaQB12AA14Transform) as Transform;
			var manzanaQB12AB14Objeto = Instantiate (manzanaQB12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....manzanaB12AA14  manzanaB12AB14 segundos cuartos");
			manzanaQB12AA14Objeto.position = new Vector3(0.8f, 3.5f,0f);
			manzanaQB12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			manzanaQB12AB14Objeto.position = new Vector3(3f, 3.5f,0f);
			manzanaQB12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}
		else if(ingreCortado.Contains("manzanaQA12AA14(Clone)")){
			Debug.Log("cuarto manzana tocado....");
		}

		ingreCortado = "";
	}



	// Update is called once per frame
	void Update () {
		
	}
}
