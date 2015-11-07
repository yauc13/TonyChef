using UnityEngine;
using System.Collections;

public class BotonReceta : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		
		//NotificationCenter.DefaultCenter().PostNotification(this, "getReceta", "1");
		Application.LoadLevel("EscenaRecetas"); //para cambia de la escena actual a la EscenaCocina
		
	}
}
