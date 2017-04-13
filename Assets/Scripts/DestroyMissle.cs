using UnityEngine;
using System.Collections;

public class DestroyMissle : MonoBehaviour {

	public float ActiveTime;

	// Use this for initialization
	void Awake () 
	{
		Destroy (gameObject, ActiveTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
