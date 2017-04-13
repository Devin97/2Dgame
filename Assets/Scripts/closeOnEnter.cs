using UnityEngine;
using System.Collections;

public class closeOnEnter : MonoBehaviour {

	Rigidbody2D thisBody;
	// Use this for initialization
	void Start () {
		thisBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			thisBody.isKinematic = false;
		}
	}
}
