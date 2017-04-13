using UnityEngine;
using System.Collections;

public class openWhenPlayerEnters : MonoBehaviour {

	float y;
	int open=0;
	public float smoothing;
	// Use this for initialization
	void Start () {
		y = transform.position.y;
		y += 30f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") {
			open += 1;
		}
		if (other.tag == "Player" && open >= 400) {
			Vector3 newPos = new Vector3 (transform.position.x, y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, newPos, smoothing * Time.smoothDeltaTime);
		} 
	}
}
