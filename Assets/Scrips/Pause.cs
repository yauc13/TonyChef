using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject pauseButton, pausePanel;

	// Use this for initialization
	void Start () {
		OnUnPause();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPause(){

		pausePanel.SetActive(true); 
		pauseButton.SetActive(false);
		Time.timeScale = 0;
	}

	public void OnUnPause(){
		pausePanel.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
	}
}
