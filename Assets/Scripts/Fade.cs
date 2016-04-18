using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Fade : MonoBehaviour {
	private bool fade = false;
	private float speed = .1f;
	private bool die = false;
	// Update is called once per frame
	void FixedUpdate () {
		if (fade) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.Lerp (gameObject.GetComponent<SpriteRenderer> ().color, Color.black, speed);
			if (gameObject.GetComponent<SpriteRenderer> ().color.a >.9f)
			if (die)
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			else
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
		}

	}
	public void fadePlz(bool di){
		fade = true;
		die = di;
	}
}
