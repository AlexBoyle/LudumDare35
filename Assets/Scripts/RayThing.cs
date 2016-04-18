using UnityEngine;
using System.Collections;

using System;

public class RayThing : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D a){
		if(a.tag == "Agent")
			GetComponentInParent<PlayerCOn> ().playerTransform ();
	}
}
