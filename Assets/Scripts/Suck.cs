using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Suck : MonoBehaviour {
	public GameObject chain;
	GameObject knifet;

	private int timer = 0;


	// Use this for initialization
	void Start () {
		knifet = (Instantiate (chain) as GameObject);
		knifet.transform.parent = gameObject.transform;
		knifet.transform.localPosition = new Vector3 (0, 0, 0);
		knifet.SetActive (false);
	}
	public void shoot(Vector2 force){
		
		if (timer > 30) {
			timer = 0;
			knifet.SetActive (true);
			knifet.transform.localPosition = new Vector3 (.05f, 0, 1);
			knifet.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			knifet.GetComponent<Rigidbody2D> ().AddForce (force);
		}
	}
	public void stop(){
		
		knifet.SetActive (false);
	}
	public void FixedUpdate(){
		
		timer++;
		if (timer > 10)
			stop ();
	}


}