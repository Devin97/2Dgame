using UnityEngine;
using System.Collections;

public class enableDisableEffector : MonoBehaviour {

	public GameObject effector;
	// Use this for initialization
	void Start () {
		effector = GameObject.Find ("Effector");
		//this.gameObject.GetComponentInChildren<AreaEffector2D> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			effector.GetComponent<AreaEffector2D> ().enabled = true;
			//this.gameObject.GetComponentInChildren<AreaEffector2D> ().enabled = true;
		} else {
			effector.GetComponent<AreaEffector2D> ().enabled = false;
			//this.gameObject.GetComponentInChildren<AreaEffector2D> ().enabled = false;
		}
	}
}
