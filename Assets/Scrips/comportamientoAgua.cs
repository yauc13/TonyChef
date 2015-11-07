using UnityEngine;
using System.Collections;

public class comportamientoAgua : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 0.20f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		float ancho =Screen.width;
		float alto =Screen.height;
		float posx = Input.mousePosition.x/ancho;
		float posy = Input.mousePosition.y/alto;

	

		Debug.Log(" posxMouse:"+posx+" posYmouse"+posy);
			transform.Translate(posx, posy, 0);

	}



	/*void OnGUI(){	
		foreach( Touch touch in Input.touches){
			string texto = "";
			//muestra los diferentes touch
			texto += "ID: "+ touch.fingerId +"\n" ;
			texto += "TapCount: "+ touch.tapCount +"\n" ;
			texto += "phase: "+ touch.phase.ToString() +"\n" ;
			texto += "Pos X: "+ touch.position.x +"\n" ;
			texto += "Pos Y: "+ touch.position.y +"\n" ;

			int num = touch.fingerId;
			GUI.Label(new Rect(0 + 130 * num,0,120,100),texto);
		}	
	} */

}
