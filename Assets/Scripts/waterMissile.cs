using UnityEngine;
using System.Collections;

public class waterMissile : MonoBehaviour {

	public float weaponDamage;

	public float weaponDamageRate;

	float nextDamage=0f;

	public GameObject watertStream;

	ProjectileController myPC;

	//float time = 0f;
	// Use this for initialization
	void Start () {
		myPC = GetComponentInParent<ProjectileController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") {
			myPC.removeForce ();
			Instantiate (watertStream,transform.position,transform.rotation);
			Destroy (gameObject);
			if (other.tag == "Enemy" && nextDamage < Time.time) {
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
				hurtEnemy.addDamage (weaponDamage);
				nextDamage = Time.time + weaponDamageRate;
			}
			//if (time == 10f) {
				//Destroy (gameObject);
				//return;
			//}
			//time = time + 0.1f;
		}
	}*/

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Enemy") {
			myPC.removeForce ();
			Instantiate (watertStream,transform.position,transform.rotation);
			Destroy (gameObject);
			if (other.tag == "Enemy" && nextDamage < Time.time) {
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
				hurtEnemy.addDamage (weaponDamage);
				nextDamage = Time.time + weaponDamageRate;
			}
			//if (time == 10f) {
			//Destroy (gameObject);
			//return;
			//}
			//time = time + 0.1f;
		}
	}
}
