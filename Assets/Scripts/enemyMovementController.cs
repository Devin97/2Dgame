﻿using UnityEngine;
using System.Collections;

public class enemyMovementController : MonoBehaviour {

	public float enemySpeed;

	Animator enemyAnimator;

	//facing

	bool facingRight = false;
	bool canFlip = true;
	public GameObject enemyGraphics;
	float flipTime = 5f;
	float nextFlipChance = 0f;

	//attack
	public float chargeTime;
	float startChargeTime;
	bool charging;
	Rigidbody2D enemyRB;


	// Use this for initialization
	void Start () {
		enemyAnimator = GetComponentInChildren<Animator> ();
		enemyRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFlipChance) {
			if (Random.Range (0, 10) > 5)
				facingFlip ();
			nextFlipChance = Time.time + flipTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if (facingRight && other.transform.position.x < transform.position.x) {
				facingFlip ();
			} else if (!facingRight && other.transform.position.x > transform.position.x) {
				facingFlip ();
			}
			canFlip = false;
			charging = true;
			startChargeTime = Time.time + chargeTime;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if (startChargeTime < Time.time) {
				if (!facingRight) {
					enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed);
					enemyRB.velocity = new Vector2 (-enemySpeed, 0f);
				} else {
					enemyRB.AddForce (new Vector2 (1, 0) * enemySpeed);
					enemyRB.velocity = new Vector2 (enemySpeed, 0f);
				}
				enemyAnimator.SetBool ("isCharging",charging);
			}
		}			
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			canFlip = true;
			charging = false;
			enemyRB.velocity = Vector2.zero;
			enemyAnimator.SetBool ("isCharging",charging);
		}
	}

	void facingFlip()
	{
		if (!canFlip)
			return;
		float facingX = enemyGraphics.transform.localScale.x;
		facingX *= -1;
		enemyGraphics.transform.localScale= new Vector3 (facingX, enemyGraphics.transform.localScale.y, enemyGraphics.transform.localScale.z);
		facingRight = !facingRight;
	}
}
