using UnityEngine;
using System.Collections;

public class bossShootBoarController : MonoBehaviour {

	public float boarSpeedHigh;

	public float boarSpeedLow;

	public float boarAngle;

	Rigidbody2D boarRB;

	// Use this for initialization
	void Start () {
		boarRB = GetComponent<Rigidbody2D> ();
		boarRB.AddForce (new Vector2 (Random.Range (-boarAngle,boarAngle),Random.Range (boarSpeedLow,boarSpeedHigh)),ForceMode2D.Impulse);
		//sporeRB.AddTorque ((Random.Range (-sporeTorqueAngle,sporeTorqueAngle)));
	}

	// Update is called once per frame
	void Update () {

	}

}
