using UnityEngine;
using System.Collections;

public class smokeScreenInitiate : MonoBehaviour {

	public GameObject smokeScreen;

	public Transform initiatePoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initiateSmoke()
	{
		Instantiate (smokeScreen,initiatePoint.position,initiatePoint.rotation);
	}
}
