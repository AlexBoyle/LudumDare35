using UnityEngine;
using System.Collections;
using System;
public class Door : MonoBehaviour {
	public bool open = false;
	private int aniStep = -1;
	public Sprite[] doorAni;
	public GameObject scan;
	void Start(){
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (aniStep < 6) {
			RaycastHit2D a = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y), Vector2.left);
			RaycastHit2D b = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y), Vector2.right);
			try {
				
				if (open && aniStep < 6) {
					aniStep++;
					gameObject.GetComponent<SpriteRenderer> ().sprite = doorAni [aniStep];
				} 
				else if (a.collider.tag == "Player" ){
					if (a.collider.transform.gameObject.GetComponent<PlayerCOn> ().getIsTransformed () && a.distance < .5f){
						open = true;
					}
				}
				else if(b.collider.tag == "Player" ){
					if (b.collider.transform.gameObject.GetComponent<PlayerCOn> ().getIsTransformed () && b.distance < .5f){
						open = true;
					}
				}
			} catch (Exception e) {

			}
		} else if(aniStep == 6) {
			aniStep++;
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			scan.GetComponent<IndAnim> ().off ();
		}
	}
}
