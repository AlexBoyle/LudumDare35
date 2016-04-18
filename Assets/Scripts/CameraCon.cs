using UnityEngine;
using System.Collections;

public class CameraCon : MonoBehaviour {
	public GameObject followMe;
	public Sprite[] alienWalk;
	public Sprite[] alienStop;
	public Sprite[] alienCrawlStop;
	public Sprite[] alienCrawl;
	public Sprite[] alienJump;
	public Sprite[] agentWalk;
	public Sprite[] agentStop;
	public Sprite[] agentJump;
	public Sprite[] agentCrawl;
	public Sprite[] agentCrawlStop;
	public Sprite[] agentSpotted;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, followMe.transform.position, .5f);

		transform.position = new Vector3 (
			transform.position.x <0 ? 0 : transform.position.x, 
			transform.position.y <0 ? 0 : transform.position.y, 
			-10
		);
	}
}
