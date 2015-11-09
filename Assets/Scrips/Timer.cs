using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public GUIText tiempoText;
	public float tiempo = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tiempo -= Time.deltaTime;
		tiempoText.text = "" + tiempo.ToString("f0");
	}

}
