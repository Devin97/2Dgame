using UnityEngine;
using System.Collections;

public class rocketHit : MonoBehaviour {

	public float weaponDamage;

	ProjectileController myPC;

	public GameObject explosion;

	public float knockbackX = 10f , knockbackY = 10f;

	// Use this for initialization
	void Awake () {
		myPC = GetComponentInParent<ProjectileController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) 
		{
			myPC.removeForce ();
			Instantiate (explosion,transform.position,transform.rotation);
			Destroy (gameObject);
			if (other.gameObject.name == "canon") {
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
				hurtEnemy.addDamage (weaponDamage);
			}
			else
			{
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
				hurtEnemy.addDamage (weaponDamage);
				other.gameObject.transform.GetComponentInParent<Rigidbody2D> ().AddForce (new Vector2 (knockbackX, knockbackY), ForceMode2D.Impulse);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) 
		{
			myPC.removeForce ();
			Instantiate (explosion,transform.position,transform.rotation);
			Destroy (gameObject);
			if (other.tag == "Enemy") 
			{
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
				hurtEnemy.addDamage (weaponDamage);
			}
		}
	}
}
