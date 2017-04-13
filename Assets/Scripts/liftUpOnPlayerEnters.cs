using UnityEngine;
using System.Collections;

public class liftUpOnPlayerEnters : MonoBehaviour {

	HingeJoint2D thisPlatformJoint;

	JointAngleLimits2D limits ;

	// Use this for initialization
	void Start () {
		thisPlatformJoint = GetComponent<HingeJoint2D> ();
		limits = thisPlatformJoint.limits;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") {
			StartCoroutine (changeLimits ());
			thisPlatformJoint.limits = limits;
		} 
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
				limits.max = 45;
				thisPlatformJoint.limits = limits;
		}
	}

	IEnumerator changeLimits()
	{
		while (limits.max != 0) {
			limits.max -= 1;
			yield return new WaitForSeconds (0.5f);
		}
	}
}
