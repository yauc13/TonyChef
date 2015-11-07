using UnityEngine;
using System.Collections;

public class DragYDrop : MonoBehaviour {

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

		Canasta canas = objCollider.GetComponent<Canasta>();
		if(canas != null){
			Debug.Log("Colision con canasta");
			Destroy(gameObject);
			Debug.Log("Objeto destruido");
		}else{
			//Debug.Log("No  hay Colision");
		}

		 
		ComportamientoOlla olla = objCollider.GetComponent<ComportamientoOlla>();
		if(olla != null){
			Debug.Log("Colision con olla");
			Destroy(gameObject);
			Debug.Log("Objeto destruido");
		}else{
			//Debug.Log("No  hay Colision");
		}

		ComportamientoCuchillo cuchillo = objCollider.GetComponent<ComportamientoCuchillo>();

		if(cuchillo != null){
			if(gameObject.GetComponent<BoxCollider2D>().isTrigger == false){
			Debug.Log("Colision con cuchillo");
			Destroy(gameObject);
			Debug.Log("Objeto dividido");
			}
		}else{
			//Debug.Log("No  hay Colision");
		}

	}

}// fin de clase
