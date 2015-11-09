using UnityEngine;
using System.Collections;

public class ComportamientoCuchillo : MonoBehaviour {
	int contBox=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Vector3 dist;
	float posX;
	float posY;
	
	void OnMouseDown(){
		dist = Camera.main.WorldToScreenPoint(transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
		
	}
	
	void OnMouseDrag(){
		Vector3 curPos = 
			new Vector3(Input.mousePosition.x - posX, 
			            Input.mousePosition.y - posY, dist.z);  
		
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
		transform.position = worldPos;
	}

	void OnTriggerEnter2D(Collider2D objCollider){
		
		DragYDrop ingre = objCollider.GetComponent<DragYDrop>();
		  //captura el nombre de GameObject que colisiona con el cuchillo

		if(ingre != null){
			string nom = ingre.name;
			Vector3 poscol = ingre.transform.position;
			object [] nomcol = new object[]{nom, poscol.x, poscol.y};
			Debug.Log("Punto de colision: ("+poscol.x+", "+poscol.y+")");
			Debug.Log("Nombre del ingrediente Notificacion: "+nom);
			gameObject.transform.position = new Vector3(6.5f, 2.2f, 0f);
			NotificationCenter.DefaultCenter().PostNotification(this, "cortarCuchillo", nomcol);

			Debug.Log("contBox: "+contBox);
			if(contBox==0){
				//si es la primera vez que coliciona, desactiva el boxcollider

				gameObject.GetComponent<BoxCollider2D>().enabled = false;
				contBox++;
				Debug.Log("contBox: "+contBox);

				StartCoroutine(desActColl());
			}else{
				//si NO es la primera vez que coliciona,Destruye el gameObject y lo transforma
				//Debug.Log("Destruir GameObject MitaD Manzana: ");
				//Destroy(gameObject);
			}

			 
		}else{
			//Debug.Log("No  hay Colision");
		}
	}

	IEnumerator desActColl(){
		Debug.Log("----entro a esperar segundos: "+Time.time);
		//gameObject.GetComponent<BoxCollider2D>().enabled = false;
		yield return new WaitForSeconds(1);
		Debug.Log("---despues a esperar segundos"+Time.time);
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
		contBox=0;
	}

}
