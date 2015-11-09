using UnityEngine;
using System.Collections;

public class ComportamientoOlla : MonoBehaviour {

	public Animator anim;
	public int ingredientes=0;
	public int contIngre=0;



	//public ComportamientoReceta receta= new ComportamientoReceta();


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

		//se envia notificacion a puntuacion, para verificar si la receta esta bien preparada
		NotificationCenter.DefaultCenter().PostNotification(this, "confirmacionReceta", contIngre);

		controlAnimacion();
		//Destroy(gameObject);
	}

	void OnMouseDrag(){
		Vector3 curPos = 
			new Vector3(Input.mousePosition.x - posX, 
			            Input.mousePosition.y - posY, dist.z);  
		
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
		transform.position = worldPos;
	}



	void OnTriggerEnter2D(Collider2D objCollider){

		DragYDrop olla = objCollider.GetComponent<DragYDrop>();
		string nom = olla.name;  //captura el nombre de GameObject que colisiona con la olla

	

		if(olla != null){
			string [] receta = EstadoJuego.estadoJuego.recetaCargar;

			for (int i=0; i<receta.Length;i++){
				string nomr=receta[i];
				bool eq= nom.Contains(nomr);
				Debug.Log("nombre GameObject: "+nom+" nombre del vector receta: "+receta[i]+" igual: "+eq);


				if(nom.Contains(nomr)){
					contIngre++;
					Debug.Log(" entro contIngre :"+contIngre);
				}else{
					Debug.Log("contIngre :"+contIngre);
				}
			}
			
		}else{
			Debug.Log("No  hay Colision");
		}
	}


	void controlAnimacion(){
		//ingredientes = receta.olla.ingredientes;
		bool estanim = anim.GetBool("ollaDestapada");
		Debug.Log("estado olla destapada "+estanim);
		if(estanim==false){



			anim.SetBool("ollaDestapada",true);
			anim.SetBool("ollaTapada",false);
			Debug.Log("estado ingredientes "+ingredientes);
		}
		else {
			anim.SetBool("ollaDestapada",false);
			anim.SetBool("ollaTapada",true);
			Debug.Log("estado ingredientes "+ingredientes);
		}

		
	}


} //cierre de clase
