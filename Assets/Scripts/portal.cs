using UnityEngine;
using System.Collections;

public class portal : MonoBehaviour {

	Animator portalAnim;

	// Use this for initialization
	void Start () {
		portalAnim = GetComponent<Animator> ();
		portalAnim.SetTrigger ("rotate");
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log ("NextLevel");
		}
	}
}

