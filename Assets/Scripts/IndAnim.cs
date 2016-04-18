using UnityEngine;
using System.Collections;

public class IndAnim : MonoBehaviour {
	public Sprite[] anim;
	public bool On = true;
	private int aniSpeed = 5;
	private int anicount = 0;
	private int aniStep = 0;
	void Start(){
		
	}
	void FixedUpdate () {
		if (On) {
			if ((anicount++) == aniSpeed) {
				anicount = 0;
				aniStep++;
			}
			if ((aniStep % anim.Length) == 0)
				aniStep = 0;
			gameObject.GetComponent<SpriteRenderer> ().sprite = anim [aniStep];
		}
	}
	public void off(){
		On = false;
		gameObject.GetComponent<SpriteRenderer> ().sprite = new Sprite ();
	}
	public void on(){
		On = true;
	}
}
