using UnityEngine;
using System.Collections;

public class grenadeController : MonoBehaviour {


	public float grenadeSpeed;

	public float grenadeAngle;

	public float grenadeTorqueAngle;

	Rigidbody2D grenadeRB;
	// Use this for initialization
	void Start () {
		grenadeRB = GetComponent<Rigidbody2D> ();
		grenadeRB.AddForce (new Vector2 (grenadeAngle,grenadeSpeed),ForceMode2D.Impulse);
		grenadeRB.AddTorque (grenadeTorqueAngle);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
