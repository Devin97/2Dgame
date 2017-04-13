using UnityEngine;
using System.Collections;

public class grenadeDamage : MonoBehaviour {

	public int timer = 0; 

	public float radius;

	public GameObject explosion;

	public float damage;

	//float movespeed = 10f;

	bool explode = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerStay2D(Collider2D other)
	{
		timer += 1;
		if (timer >= 300 && explode) {
				//this.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			explode = false;
			//this.gameObject.GetComponentInParent<Rigidbody2D> ().AddForce (new Vector2(movespeed,0));
			Instantiate (explosion, transform.position, transform.rotation);
			if (other.tag == "Enemy") {
				if (other.gameObject.name == "canon") {
					enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
					hurtEnemy.addDamage (damage);
					return;
				}
				other.gameObject.GetComponentInParent<Rigidbody2D> ().AddForce (new Vector2 (10f, 10f), ForceMode2D.Impulse);
				other.gameObject.GetComponent<enemyHealth> ().enemySlider.gameObject.SetActive (true);
				other.gameObject.GetComponent<enemyHealth> ().addDamage (damage);
			}
			Destroy (gameObject);
		}
	}
}
