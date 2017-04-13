using UnityEngine;
using System.Collections;

public class shootOtherBoars : MonoBehaviour {

	public GameObject boar;

	public Transform shootFrom;

	public float shootTime;

	public int chanceShoot;

	float nextShootTime;

	// Use this for initialization
	void Start () {
		nextShootTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && nextShootTime < Time.time) {
			nextShootTime = Time.time + shootTime;
			if (Random.Range (0, 10) >= chanceShoot) {
				Instantiate (boar,shootFrom.position,Quaternion.identity);
			}
		}
	}
}
