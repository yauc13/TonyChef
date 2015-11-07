using UnityEngine;
using System.Collections;
using System;

public class Canasta : MonoBehaviour {
	public int numIngredientes=0;
	public string[] listIngre = new string[5]; 
	int i=0;
	public static Canasta canasta;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D objCollider){
		DragYDrop canas = objCollider.GetComponent<DragYDrop>();
		string nom = canas.name;  //captura el nombre de GameObject que colisiona con la canasta
		Debug.Log("nombre GameObject: "+nom+" posicion:"+i);
		listIngre[i] = nom;
		i++;


		if(canas != null){
			numIngredientes++;
			Debug.Log("Colision con ingrediente y No:"+numIngredientes);
			//se envia el num de ingredientes q colisionan con canasta y los manda a puntuacion
			NotificationCenter.DefaultCenter().PostNotification(this, "agregarIngrediente", numIngredientes);
		}else{
			Debug.Log("No  hay Colision");
		}

		for(int j=0; j<listIngre.Length;j++){
			Debug.Log("MOstrar Vector nombre"+j+" :"+listIngre[j]);
		}

	}

	void OnMouseDown(){
		//se envia la lista de ingredientes a puntuacion
		NotificationCenter.DefaultCenter().PostNotification(this, "listaIngredientes", listIngre);
	}


}//cierre clase
