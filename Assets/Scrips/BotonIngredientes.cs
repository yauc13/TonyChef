using UnityEngine;
using System.Collections;

public class BotonIngredientes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		//este metodo escucha los eventos del mouse, en este caso
		//si se ha pulsado el objeto BotonIngredientes en la escena de cocina
		Debug.Log("click para saltar escena: ");
		NotificationCenter.DefaultCenter().PostNotification(this, "limpiarIngredientes", true);
		Application.LoadLevel ("EscenaIngredientes"); //para cambia de la escena actual a la EscenaIngredientes

	}
}
