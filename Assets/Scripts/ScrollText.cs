using UnityEngine;
using System.Collections;

public class ScrollText : MonoBehaviour {
	public float speed;
	public Vector3 a;
	public int wait;
	public void FixedUpdate(){
		transform.position = Vector3.MoveTowards (transform.position, a, speed); 
		if (a == transform.position)
			wait++;
		if(wait > 180)
			Application.Quit ();
	}
}
