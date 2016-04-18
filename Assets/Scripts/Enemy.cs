using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {
	public float speed = .05f;
	public Vector3[] positions;
	private int aniSpeed = 5;
	private int anicount = 0;
	private int aniStep = 0;
	private int arrPos = 1;
	public bool dirOver = false;
	public bool dir= false;
	private Vector3 start;
	private Vector3 end;
	private Vector3 pre;
	private animationState state = animationState.Walk;
	private CameraCon Animations;
	private RaycastHit2D[] left = {new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D()};
	private RaycastHit2D[] right = {new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D(),new RaycastHit2D()};
	public GameObject fade;
	// Use this for initialization
	void Start () {
		pre = transform.position;
		end = positions [0];
		Animations = GameObject.Find ("Main Camera").GetComponent<CameraCon> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		pre = transform.position;
		if (transform.position == end) {
			arrPos++;
			if (arrPos % positions.Length == 0)
				arrPos = 0;
			end = positions [arrPos];
		}
			

		transform.position = Vector3.MoveTowards (transform.position, end, speed);
		if ((transform.position - pre).x < 0) {
			transform.localRotation = Quaternion.Euler (new Vector3 (180, 0, 180));
			for (int i = 0; i < right.Length; i++) {
				right [i] = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y), new Vector2(-60,18 +(-6*i)));
				Debug.DrawRay(transform.position,new Vector3(-60,18 +(-6*i),0));
			}
			for (int i = 0; i < 7; i ++)
				try{
				if(right[i].collider.tag == "Player" && right[i].distance < 5.7 && !right[i].collider.gameObject.GetComponent<PlayerCOn>().getIsTransformed()){
					
					fade.GetComponent<Fade>().fadePlz(true);
				}
			}catch(Exception e){

			}
		} else {
			transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, 0));
			for (int i = 0; i < left.Length; i++) {
				Debug.DrawRay(transform.position,new Vector3(60,18 +(-6*i),0));
				left [i] = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y), new Vector2(60,18 +(-6*i)));
			}
			for (int i = 0; i < 7; i ++)
			try{
				if(left[i].collider.tag == "Player" && left[i].distance < 5.7 && !left[i].collider.gameObject.GetComponent<PlayerCOn>().getIsTransformed()){
					fade.GetComponent<Fade>().fadePlz(true);
				}
			}catch(Exception e){

			}
		}
		if ((anicount++) == aniSpeed) {
			anicount = 0;
			aniStep++;
		}
		switch (state) {
		case animationState.Walk:
			if ((aniStep % Animations.agentWalk.Length) == 0)
				aniStep = 0;
			gameObject.GetComponent<SpriteRenderer>().sprite = Animations.agentWalk[aniStep];
			break;
		case animationState.Stop:
			if ((aniStep % Animations.agentWalk.Length) == 0)
				aniStep = 0;
			gameObject.GetComponent<SpriteRenderer>().sprite = Animations.agentWalk[aniStep];
			break;
		}
		if(dirOver)
		if(dir)
			transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		else
			transform.localRotation = Quaternion.Euler (new Vector3 (0, 180, 0));
	}
}
