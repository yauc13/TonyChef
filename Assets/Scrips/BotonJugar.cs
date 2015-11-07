using UnityEngine;
using System.Collections;

public class BotonJugar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//este metodo escucha los eventos del mouse, en este caso
		//si se ha pulsado el objeto BotonJugar en la escena de inicio
		Debug.Log("click para saltar escena: ");
		//string[] listIngredientes= new string[5];
		//Debug.Log("nombre"+0+" :"+Canasta.canasta.numIngredientes);
		//Debug.Log("nombre"+0+" :"+EstadoJuego.estadoJuego.puntuacionMaxima);
		 //Canasta.canasta.listIngre.Length;

		//se envia estas notificaciones para limpiar la lista de ingredientes a cargar
		NotificationCenter.DefaultCenter().PostNotification(this, "limpiarIngredientes", true);
		NotificationCenter.DefaultCenter().PostNotification(this, "limpiarReceta", true);
		Application.LoadLevel ("EscenaCocina"); //para cambia de la escena actual a la EscenaCocina

	}


}
