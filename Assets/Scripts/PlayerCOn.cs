using UnityEngine;
using System.Collections;
public enum animationState {Walk = 0,Stop = 1,Crouch = 2, Crawl = 3,Jump = 4};
public class PlayerCOn : MonoBehaviour {
	public int timerMax = 60;
	public GameObject[] timer;
	private bool direction = false;
	private int timerCount = 0;
	private int timerPause = 0;
	public float speed = 1;
	private bool isTransformed = false;
	private Vector3 rot;
	private int aniSpeed = 5;
	private int anicount = 0;
	private int aniStep = 0;
	public GameObject fade;
	public GameObject pauseMenu;
	public animationState state = animationState.Stop;
	private CameraCon Animations;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Animations = GameObject.Find ("Main Camera").GetComponent<CameraCon> ();
		for (int i = 0; i < timer.Length; i++)
			timer [i].SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float top = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y), Vector2.up).distance;
		float distance = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y), Vector2.down).distance;
		if (state == animationState.Crawl || state == animationState.Crouch)
			state = animationState.Crouch;
		else
			state = animationState.Stop;
		if (Input.GetButton ("space") && distance < 1.08 && !(state == animationState.Crawl || state == animationState.Crouch)) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 700));
		}
		if (Input.GetButton ("a")) {
			if(!(top > 0 && top <.898f))
			rot = new Vector3(180,0,180);
			transform.position -= new Vector3 (speed,0,0);
			state = animationState.Walk;
			direction = true;
		}
		if (Input.GetButton ("d")) {
			if(!(top > 0 && top <.898f))
			rot = new Vector3(0,0,0);
			gameObject.transform.position += new Vector3 (speed,0,0);
			state = animationState.Walk;
			direction = false;
		}
		if (Input.GetButton ("r")) {
			fade.GetComponent<Fade>().fadePlz(true);
		}
		if (Input.GetButton ("pause") && timerPause >40) {
			pauseMenu.SetActive (true);
			pauseMenu.GetComponent<PauseMenu> ().pause ();

		}
		if(timerPause <50)
		timerPause++;
		if (Input.GetButton ("q") && !(state == animationState.Crawl || state == animationState.Crouch)) {
			if(direction)
			gameObject.GetComponent<Suck> ().shoot (new Vector2(-300,0));
			else
			gameObject.GetComponent<Suck> ().shoot (new Vector2(300,0));
		}
			
		if (((top > 0 && top <.898f) ||Input.GetButton ("s")) && distance < 1.08) {
			

			if(direction)
				rot = new Vector3(0,180,270);
			else 
				rot = new Vector3(0,0,270);
			if (state == animationState.Stop || state == animationState.Crouch)
				state = animationState.Crouch;
			else
				state = animationState.Crawl;
		}

		transform.localRotation = Quaternion.Euler (rot);
		if ((anicount++) == aniSpeed) {
			anicount = 0;
			aniStep++;
		}
		if (distance > 1.08)
			state = animationState.Jump;
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		switch (state) {
		//Walk/////////////////////////////////////////////////////////////////////////////////////
		case animationState.Walk:
			if (isTransformed) {
				if ((aniStep % Animations.agentWalk.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.agentWalk [aniStep % Animations.agentWalk.Length];
			} else {
				if ((aniStep % Animations.alienWalk.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.alienWalk [aniStep % Animations.alienWalk.Length];
			}
			break;
			//Stop///////////////////////////////////////////////////////////////////////////////
		case animationState.Stop:
			if (direction)
				rot = new Vector3 (180, 0, 180);
			else
				rot = new Vector3 (0, 0, 0);
			if (isTransformed) {
				if ((aniStep % Animations.agentStop.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.agentStop [aniStep % Animations.agentStop.Length];
			} else {
				if ((aniStep % Animations.alienStop.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.alienStop [aniStep % Animations.alienStop.Length];
			}
			break;
			//Crouch///////////////////////////////////////////////////////////////////////////////
		case animationState.Crouch:
			if (isTransformed) {
				if ((aniStep % Animations.agentCrawlStop.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.agentCrawlStop [aniStep % Animations.agentCrawlStop.Length];
			} else {
				if ((aniStep % Animations.alienCrawlStop.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.alienCrawlStop [aniStep % Animations.alienCrawlStop.Length];
			}
			break;
			//Crawl///////////////////////////////////////////////////////////////////////////////////
		case animationState.Crawl:
			if (isTransformed) {
				if ((aniStep % Animations.agentCrawl.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.agentCrawl [aniStep % Animations.agentCrawl.Length];
			} else {
				if ((aniStep % Animations.alienCrawl.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.alienCrawl [aniStep % Animations.alienCrawl.Length];
			}
			break;
			//Jump/////////////////////////////////////////////////////////////////////////////////
		case animationState.Jump:
			if (direction)
				rot = new Vector3 (180, 0, 180);
			else
				rot = new Vector3 (0, 0, 0);
			
			if (isTransformed) {
				if ((aniStep % Animations.agentJump.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.agentJump [aniStep% Animations.agentJump.Length];
			} else {
				if ((aniStep % Animations.alienJump.Length) == 0)
					aniStep = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Animations.alienJump [aniStep % Animations.alienJump.Length];
			}
			break;
		}
		if (isTransformed) {
			timerCount++;
			timer [((int)(((float)timerCount/timerMax)*11))].SetActive (false);
			if (timerCount > timerMax) {
				isTransformed = false;
				timerCount = 0;
			}
		}
	}
	public void playerTransform(){
		timerCount = 0;
		isTransformed = true;
		for (int i = 0; i < timer.Length; i++)
			timer [i].SetActive (true);
	}
	public bool getIsTransformed(){
		return isTransformed;
	}
	public void resetTimerPause(){
		timerPause = 0;
	}
}
