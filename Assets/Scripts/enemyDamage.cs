using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class enemyDamage : MonoBehaviour {

	public float damage;
	public float damageRate;
	public float pushBackForce;

	float nextDamage;

	// Use this for initialization
	void Start () {
		nextDamage = 0f;  
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && nextDamage < Time.time) 
		{
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (damage);
			nextDamage = Time.time + damageRate;

			pushBack(other.transform);
		}
	}

	void pushBack(Transform pushedObject)
	{
		Vector2 pushDirection = new Vector2 (0,(pushedObject.position.y - transform.position.y)).normalized; 
		pushDirection *= pushBackForce;  // Calculates at what force the player should be pushed back
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> (); //getting the RigidBody component of a player
		pushRB.velocity = Vector2.zero; // setting the velocity of player to zero[0]
		pushRB.AddForce (pushDirection,ForceMode2D.Impulse); // pushing the player back with the pushback force and impulse Forcemode
	}
}
