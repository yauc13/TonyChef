
using UnityEngine;
using System.Collections;

public class Receta : MonoBehaviour {
	public const int n=6; //numero de elementos del vector receta

	string [] receta = new string[n];
	string [] receta1 = new string[n]{"receta1","Diabolo de Frutas","manzanaQ","banano","uvas","mandarina"};
	string [] receta2 = new string[n]{"receta2","Jugo","papaamarilla","tomate","banano","mandarina"};
	string [] receta3 = new string[n]{"receta3","","","","",""};
	string [] receta4 = new string[n]{"receta4","","","","",""};
	string [] receta5 = new string[n]{"receta5","","","","",""};
	string [] receta6 = new string[n]{"receta6","","","","",""};
	string [] receta7 = new string[n]{"receta7","","","","",""}; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		string nombreReceta = gameObject.name;
		switch(nombreReceta){
		case "receta1":
			receta=receta1;
			break;
		case "receta2":
			receta=receta2;
			break;
		case "receta3":
			receta=receta3;
			break;
		case "receta4":
			receta=receta4;
			break;
		case "receta5":
			receta=receta5;
			break;
		case "receta6":
			receta=receta6;
			break;
		case "receta7":
			receta=receta7;
			break;
		}

		Debug.Log("----Nombre Receta:-----"+nombreReceta);
		//essta notificacion se envia a puntuacion, para que guarde la receta a preparar
		NotificationCenter.DefaultCenter().PostNotification(this, "getReceta", receta);
		Application.LoadLevel("EscenaCocina"); //para cambia de la escena actual a la EscenaCocina
		
	}
}
