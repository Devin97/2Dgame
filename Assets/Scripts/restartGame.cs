using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour {

	public float restartTime;

	bool restartNow = false;

	float resetTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (restartNow && resetTime <= Time.time) {
			//Application.LoadLevel (Application.loadedLevel);
			SceneManager.LoadScene ("Main");
		}
	}

	public void restartTheGame()
	{
		restartNow = true;
		resetTime = Time.time + restartTime;
	}
}
