using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VerReceta : MonoBehaviour {
	public GameObject panelVerReceta;
	public Text nombreReceta;
	public Image imagenReceta;
	public Sprite spriteReceta1;
	public Sprite spriteReceta2;

	string receta;

	// Use this for initialization
	void Start () {
		ocultarReceta();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnOffPanelReceta(){
		bool act = panelVerReceta.activeInHierarchy;  //captura el estado del panel de receta
		if(act==false){
			mostrarReceta();
		}else{
			ocultarReceta();
		}
	}

	public void ocultarReceta(){
		panelVerReceta.SetActive(false);
	}

	public void mostrarReceta(){
		panelVerReceta.SetActive(true);
		receta = nombreReceta.text;
		switch(receta){
		case "Diabolo de Frutas":
			imagenReceta.sprite = spriteReceta1; //asigna cual imagen mostrar
			break;
		case "Pizza de Frutas":
			imagenReceta.sprite = spriteReceta2;
			break;
		case "receta3":
			imagenReceta.sprite = spriteReceta2;
			break;
		case "receta4":
			imagenReceta.sprite = spriteReceta2;
			break;
		case "receta5":
			imagenReceta.sprite = spriteReceta2;
			break;
		case "receta6":
			imagenReceta.sprite = spriteReceta2;
			break;
		case "receta7":
			imagenReceta.sprite = spriteReceta2;
			break;
		}


	}
}
