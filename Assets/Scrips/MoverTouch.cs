using UnityEngine;
using System.Collections;

public class MoverTouch : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 0.20f;
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<Rigidbody2D>()
		float gOx = transform.position.x;
		float gOy = transform.position.y;
		float mTx =Input.touches[0].deltaPosition.x;
		float mTy =Input.touches[0].deltaPosition.y;
		Debug.Log(" gOx:"+gOx+" gOy:"+gOy+" mTx:"+mTx+" mTy:"+mTy);
		if(gOx==mTx && gOy==mTy){
			transform.Translate(Input.touches[0].deltaPosition.x*speed,
			                    Input.touches[0].deltaPosition.y *speed, 0);
		}
	}
	
}
