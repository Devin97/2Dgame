using UnityEngine;
using System.Collections;

public class followPlayerInXDir : MonoBehaviour {

	public Transform target; // Player that this object will follow

	public float smoothing;

	Vector3 offset;
	float lowY;
	// Use this for initialization
	void Start () {
		offset = target.position - transform.position;
		lowY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			Vector3 targetPos = target.position - offset;
			transform.position = Vector3.Lerp (transform.position, targetPos, smoothing * Time.deltaTime);

			if (transform.position.y > lowY) {
				lowY = transform.position.y;
			}		

			if (transform.position.y < lowY) {
				transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
			} 
		}
	}
}
