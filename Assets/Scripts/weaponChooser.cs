using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class weaponChooser: MonoBehaviour {

	public GameObject missile2;

	GameObject storeIntialBullet;

	public GameObject missile3;

	public GameObject missile4;

	public GameObject torpedoMissile;

	AudioSource setPlay;

	playerController playerBullet;

	float storeFireRate,storeknockbackX,storeknockbackY;
	// Use this for initialization
	void Start () {
		playerBullet = GetComponentInParent<playerController> ();
		setPlay = GetComponent<AudioSource> ();
		storeIntialBullet = playerBullet.bullet;
		storeFireRate = playerBullet.fireRate;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			playerBullet.bullet = missile2;
			playerBullet.fireRate = storeFireRate;
			setPlay.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			playerBullet.bullet = storeIntialBullet;
			playerBullet.fireRate = storeFireRate;
			setPlay.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			playerBullet.bullet = missile3;
			playerBullet.fireRate = storeFireRate;
			setPlay.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Alpha4)) {
				playerBullet.bullet = missile4;
				playerBullet.fireRate = 0.2f;
				setPlay.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			playerBullet.bullet = torpedoMissile;
			playerBullet.fireRate = 2.1f;
			setPlay.Play ();
		}
	}
}
