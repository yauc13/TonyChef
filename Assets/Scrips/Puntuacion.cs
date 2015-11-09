using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour {

	/**
		Esta clase es la encargada de capturar las notificaciones que desde los otros 
		GameObjects se realizan para luego ser mostrados en pantalla.
		ademas se encarga de guardar cambios en los valores persistentes
		
	 **/

	//public float tiempo = 0.0f;


	public int puntuacion = 0;
	public int puntuacionAcumulada=0;
	public int numIngredientes=0;
	public string nomReceta="Ninguna";
	public string [] recetaCargar= new string[6]{"vacio","vacio","vacio","vacio","vacio","vacio"};
	public string [] listIngreCargar= new string[5]{"vacio","vacio","vacio","vacio","vacio"};
	public Text reloj; 
	public TextMesh marcador;
	public TextMesh acumulado;
	public TextMesh ingredientes;
	public Text nombreReceta;
	public Text textConfRece;
	//para cargar los ingredientes
		
	public Transform papaamarillaTransform;
	public Transform papanegraTransform;
	public Transform remolachaTransform;
	public Transform tomateTransform;

	public Transform uvasTransform;


	// variables para asignar los prefabs de las frutas
	public Transform manzanaTransform;
	public Transform manzanaA12Transform;
	public Transform manzanaB12Transform;
	public Transform manzanaQA12AA14Transform;
	public Transform manzanaQA12AB14Transform;
	public Transform manzanaQB12AA14Transform;
	public Transform manzanaQB12AB14Transform;

	public Transform fresaTransform;
	public Transform fresaA12Transform;
	public Transform fresaB12Transform;
	public Transform fresaQA12AA14Transform;
	public Transform fresaQA12AB14Transform;
	public Transform fresaQB12AA14Transform;
	public Transform fresaQB12AB14Transform;

	public Transform bananoTransform;
	public Transform bananoA12Transform;
	public Transform bananoB12Transform;
	public Transform bananoQA12AA14Transform;
	public Transform bananoQA12AB14Transform;
	public Transform bananoQB12AA14Transform;
	public Transform bananoQB12AB14Transform;

	public Transform mandarinaTransform;
	public Transform mandarinaA12Transform;
	public Transform mandarinaB12Transform;
	public Transform mandarinaQA12AA14Transform;
	public Transform mandarinaQA12AB14Transform;
	public Transform mandarinaQB12AA14Transform;
	public Transform mandarinaQB12AB14Transform;

	
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
		NotificationCenter.DefaultCenter().AddObserver(this, "confirmacionReceta");  //viene de comportamientoOlla
		ActualizarMarcador();
		cargarIngredientes();
	}

	// Update is called once per frame
	void Update () {
		/*tiempo += Time.deltaTime;
		reloj.text = "" + tiempo.ToString("f0"); */  

		if(reloj!=null){
			
			reloj.text = "" + EstadoJuego.estadoJuego.tiempo.ToString("f0");
		}
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
			if(listIngreCargar[i]=="fresa" && fresaTransform!=null){
				var fresaObjeto = Instantiate (fresaTransform) as Transform;
				fresaObjeto.position = new Vector3(-3,2,0);
			}

		}
	}


	void cortarCuchillo(Notification notificacion){
		object [] nomcol = (object[])notificacion.data;
		string ingreCortado= nomcol[0].ToString();
		float posxcol = (float)(nomcol[1]);
		float posycol = (float)(nomcol[2]);
		int longi= ingreCortado.Length;
		Debug.Log("ingrediente Cortado que llega de notificacion: "+ingreCortado+" Tamano: "+longi+" posi colision ("+posxcol+", "+posycol+")");

		if(ingreCortado.Contains("mazzana(Clone)") && manzanaA12Transform!=null && manzanaB12Transform!=null){
			var manzanaA12Objeto = Instantiate (manzanaA12Transform) as Transform;
			var manzanaB12Objeto = Instantiate (manzanaB12Transform) as Transform;
			Debug.Log("[Instancia] ....manzanaA12  manzanaB12 ");
			manzanaA12Objeto.position = new Vector3(posxcol, posycol,0f);
			manzanaB12Objeto.position = new Vector3(posxcol+1.8f, posycol,0f);
		} else if(ingreCortado.Contains("manzanaA12(Clone)") && manzanaQA12AA14Transform!=null && manzanaQA12AB14Transform!=null){
			var manzanaQA12AA14Objeto = Instantiate (manzanaQA12AA14Transform) as Transform;
			var manzanaQA12AB14Objeto = Instantiate (manzanaQA12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....manzanaA12AA14  manzanaA12AB14  primeros cuartos ");
			manzanaQA12AA14Objeto.position = new Vector3(posxcol, posycol,0f);
			manzanaQA12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			manzanaQA12AB14Objeto.position = new Vector3(posxcol, posycol-1.8f,0f);
			manzanaQA12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}else if(ingreCortado.Contains("manzanaB12(Clone)") && manzanaQB12AA14Transform!=null && manzanaQB12AB14Transform!=null){
			var manzanaQB12AA14Objeto = Instantiate (manzanaQB12AA14Transform) as Transform;
			var manzanaQB12AB14Objeto = Instantiate (manzanaQB12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....manzanaB12AA14  manzanaB12AB14 segundos cuartos");
			manzanaQB12AA14Objeto.position = new Vector3(posxcol, posycol,0f);
			manzanaQB12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			manzanaQB12AB14Objeto.position = new Vector3(posxcol, posycol-1.8f,0f);
			manzanaQB12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}

		else if(ingreCortado.Contains("fresa(Clone)") && fresaA12Transform!=null && fresaB12Transform!=null){
			var fresaA12Objeto = Instantiate (fresaA12Transform) as Transform;
			var fresaB12Objeto = Instantiate (fresaB12Transform) as Transform;
			Debug.Log("[Instancia] ....fresaA12  fresaB12 ");
			fresaA12Objeto.position = new Vector3(posxcol, posycol,0f);
			fresaB12Objeto.position = new Vector3(posxcol+1.8f, posycol,0f);
		} else if(ingreCortado.Contains("fresaA12(Clone)") && fresaQA12AA14Transform!=null && fresaQA12AB14Transform!=null){
			var fresaQA12AA14Objeto = Instantiate (fresaQA12AA14Transform) as Transform;
			var fresaQA12AB14Objeto = Instantiate (fresaQA12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....fresaA12AA14  fresaaA12AB14  primeros cuartos ");
			fresaQA12AA14Objeto.position = new Vector3(posxcol, posycol,0f);
			fresaQA12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			fresaQA12AB14Objeto.position = new Vector3(posxcol, posycol-1.8f,0f);
			fresaQA12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}else if(ingreCortado.Contains("fresaB12(Clone)") && fresaQB12AA14Transform!=null && fresaQB12AB14Transform!=null){
			var fresaQB12AA14Objeto = Instantiate (fresaQB12AA14Transform) as Transform;
			var fresaQB12AB14Objeto = Instantiate (fresaQB12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....manzanaB12AA14  manzanaB12AB14 segundos cuartos");
			fresaQB12AA14Objeto.position = new Vector3(posxcol, posycol,0f);
			fresaQB12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			fresaQB12AB14Objeto.position = new Vector3(posxcol, posycol-1.8f,0f);
			fresaQB12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}

		else if(ingreCortado.Contains("banano(Clone)") && bananoA12Transform!=null && bananoB12Transform!=null){
			var bananoA12Objeto = Instantiate (bananoA12Transform) as Transform;
			var bananoB12Objeto = Instantiate (bananoB12Transform) as Transform;
			Debug.Log("[Instancia] ....bananoA12 bananoB12 ");
			bananoA12Objeto.position = new Vector3(posxcol, posycol,0f);
			bananoB12Objeto.position = new Vector3(posxcol+1.8f, posycol,0f);
		} else if(ingreCortado.Contains("bananoA12(Clone)") && bananoQA12AA14Transform!=null && bananoQA12AB14Transform!=null){
			var bananoQA12AA14Objeto = Instantiate (bananoQA12AA14Transform) as Transform;
			var bananoQA12AB14Objeto = Instantiate (bananoQA12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....bananoA12AA14  bananoA12AB14  primeros cuartos ");
			bananoQA12AA14Objeto.position = new Vector3(posxcol, posycol,0f);
			bananoQA12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			bananoQA12AB14Objeto.position = new Vector3(posxcol, posycol-1.8f,0f);
			bananoQA12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}else if(ingreCortado.Contains("bananoB12(Clone)") && bananoQB12AA14Transform!=null && bananoQB12AB14Transform!=null){
			var bananoQB12AA14Objeto = Instantiate (bananoQB12AA14Transform) as Transform;
			var bananoQB12AB14Objeto = Instantiate (bananoQB12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....manzanaB12AA14  manzanaB12AB14 segundos cuartos");
			bananoQB12AA14Objeto.position = new Vector3(posxcol, posycol,0f);
			bananoQB12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			bananoQB12AB14Objeto.position = new Vector3(posxcol, posycol-1.8f,0f);
			bananoQB12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}

		else if(ingreCortado.Contains("mandarina(Clone)") && mandarinaA12Transform!=null && mandarinaB12Transform!=null){
			var mandarinaA12Objeto = Instantiate (mandarinaA12Transform) as Transform;
			var mandarinaB12Objeto = Instantiate (mandarinaB12Transform) as Transform;
			Debug.Log("[Instancia] ....mandarinaA12 mandarinaB12 ");
			mandarinaA12Objeto.position = new Vector3(posxcol, posycol,0f);
			mandarinaB12Objeto.position = new Vector3(posxcol+1.6f, posycol,0f);
		} else if(ingreCortado.Contains("mandarinaA12(Clone)") && mandarinaQA12AA14Transform!=null && mandarinaQA12AB14Transform!=null){
			var mandarinaQA12AA14Objeto = Instantiate (mandarinaQA12AA14Transform) as Transform;
			var mandarinaQA12AB14Objeto = Instantiate (mandarinaQA12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....mandarinaA12AA14  mandarinaA12AB14  primeros cuartos ");
			mandarinaQA12AA14Objeto.position = new Vector3(posxcol, posycol,0f);
			mandarinaQA12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			mandarinaQA12AB14Objeto.position = new Vector3(posxcol, posycol-1.2f,0f);
			mandarinaQA12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}else if(ingreCortado.Contains("mandarinaB12(Clone)") && mandarinaQB12AA14Transform!=null && mandarinaQB12AB14Transform!=null){
			var mandarinaQB12AA14Objeto = Instantiate (mandarinaQB12AA14Transform) as Transform;
			var mandarinaQB12AB14Objeto = Instantiate (mandarinaQB12AB14Transform) as Transform;
			Debug.Log("[Instancia] ....manzanaB12AA14  manzanaB12AB14 segundos cuartos");
			mandarinaQB12AA14Objeto.position = new Vector3(posxcol, posycol,0f);
			mandarinaQB12AA14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
			mandarinaQB12AB14Objeto.position = new Vector3(posxcol, posycol-1.2f,0f);
			mandarinaQB12AB14Objeto.GetComponent<BoxCollider2D>().isTrigger=true;
		}




		else if(ingreCortado.Contains("manzanaQA12AA14(Clone)")){
			Debug.Log("cuarto manzana tocado....");
		}

		ingreCortado = "";
	}


	void confirmacionReceta(Notification notificacion){
		int conRec = (int)notificacion.data;
		string rece = conRec.ToString();
		bool igual = rece.Contains(EstadoJuego.estadoJuego.recetaCargar[0]);
		Debug.Log("revision de receta igua: "+igual);
		textConfRece.GetComponent<Text>().enabled = true;
		if(rece.Contains(EstadoJuego.estadoJuego.recetaCargar[0])){
			textConfRece.text = "receta bien elaborada";
			Debug.Log("receta bien elaborada");
		}else{

			textConfRece.text = "receta MAL elaborada";      
			Debug.Log("receta MAL elaborada");  
		}
		StartCoroutine(desActTextConfRecet());

	}


	IEnumerator desActTextConfRecet(){
		yield return new WaitForSeconds(3);
		textConfRece.GetComponent<Text>().enabled = false;
	}




}
