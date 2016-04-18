using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	private float time;
	private float temp;
	private Vector3 mo = Vector3.zero;
	private bool pre = true;
	private Rect but1 = new Rect(new Vector2(-2.3f,.65f),new Vector2(4.5f,1));
	public void Start(){
		gameObject.SetActive (false);
	}
	public void pause(){
		Cursor.visible = true;
		Time.timeScale = 0f;
		pre = true;
		transform.position = GameObject.Find ("Main Camera").transform.position + new Vector3(0,0,1);
	}
	
	// Update is called once per frame
	void Update () {
		time = Time.realtimeSinceStartup;
		if (temp + .1f < time) {
			if (Input.GetButton ("pause")&& !pre) {
				Cursor.visible = false;
				Time.timeScale = 1f;
				GameObject.Find ("Player").GetComponent<PlayerCOn> ().resetTimerPause ();
				gameObject.SetActive (false);
				transform.position = GameObject.Find ("Main Camera").transform.position + new Vector3(0,0,1);
			}
			mo =Input.mousePosition ;
			mo = Camera.main.ScreenToWorldPoint (mo);
			mo = mo - Camera.main.transform.position;
			if (but1.Contains (mo) && Input.GetMouseButton (0)) {
				Debug.Log ("I quit");
				Application.Quit ();
			}
			pre = Input.GetButton ("pause");
			temp = time;
		}

	}
}
