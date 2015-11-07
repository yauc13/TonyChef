using UnityEngine;
using System.Collections;

public class ComportamientoReceta : MonoBehaviour {
	public Animator anim;
	int contClick=0;
	int recetaGastada=0;
	 //public ComportamientoOlla olla= new ComportamientoOlla();

	// Use this for initialization
	void Start () {
		//contClick=0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//Destroy(gameObject);

		controlAnimacion();
		//Destroy(gameObject);
	}

	void controlAnimacion(){

		contClick++;  //cuenta el numero de click en receta

		if(contClick==1){
			Debug.Log("num click: 1 if "+contClick);
			anim.SetBool("Receta14",false);
			anim.SetBool("Receta12",false);
			anim.SetBool("Receta34",true);
			recetaGastada++;

		}
		else if(contClick==2){
			Debug.Log("num click: 2 if "+contClick);
			anim.SetBool("Receta14",false);
			anim.SetBool("Receta34",false);
			anim.SetBool("Receta12",true);
			recetaGastada++;

		}
		else if (contClick==3){
			Debug.Log("num click: 3 if "+contClick);
			anim.SetBool("Receta12",false);
			anim.SetBool("Receta34",false);
			anim.SetBool("Receta14",true);
			recetaGastada++;

		}
		else if(contClick==4){
			anim.SetBool("Receta12",false);
			anim.SetBool("Receta34",false);
			anim.SetBool("Receta14",true);
			recetaGastada++;
			NotificationCenter.DefaultCenter().PostNotification(this, "terminaReceta", recetaGastada);
			Destroy(gameObject);
		}
		Debug.Log("Receta Gastada: "+recetaGastada);
		//se envia esta notificacion de los puntos al componente Puntuacion que esta en el MainCamera
		NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", recetaGastada);


	}
}
