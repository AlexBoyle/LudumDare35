using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour {
	private int time = 0;

	
	// Update is called once per frame
	void FixedUpdate () {
		time++;
		if (time > 180)
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}
}
