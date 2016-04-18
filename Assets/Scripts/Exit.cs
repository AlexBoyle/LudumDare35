using UnityEngine;
using System.Collections;
using System;
public class Exit : MonoBehaviour {
	public GameObject fade;

	


	void OnTriggerEnter2D(Collider2D a){
		Debug.Log ("here");
		fade.GetComponent<Fade>().fadePlz(false);
	}


}
