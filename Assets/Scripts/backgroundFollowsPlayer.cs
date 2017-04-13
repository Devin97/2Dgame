using UnityEngine;
using System.Collections;

public class backgroundFollowsPlayer : MonoBehaviour {

	public Transform target;

	public float smoothness;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			//transform.position = new Vector3 (Mathf.Abs (target.position.x), Mathf.Clamp (transform.position.y, transform.position.y, transform.position.y), transform.position.z);
			Vector3 toPosition = new Vector3 (Mathf.Abs (target.position.x), Mathf.Clamp (transform.position.y, transform.position.y, transform.position.y), transform.position.z);
			transform.position = Vector3.Lerp (transform.position, toPosition, smoothness * Time.deltaTime);
		}
	}
}
