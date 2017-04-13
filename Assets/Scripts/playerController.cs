using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class playerController : MonoBehaviour {

	[SerializeField]
	private float maxSpeed;

	private Rigidbody2D myRB;

	private Animator myAnim;

	//public GameObject grenade;

	bool facingRight;

	bool grounded = true;

	public float groundCheckRadius = 0.2f;

	public LayerMask groundLayer;

	public Transform groundCheck;

	public float jumpHeight;

	//Shoot

	public Transform gunTip;
	public Transform grenadeTip;
	public GameObject bullet;
	public GameObject grenade;
	public float fireRate = 0.8f;
	float nextFire = 0f;

	// Use this for initialization
	void Start () 
	{
	    myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (grounded && Input.GetAxis ("Jump") > 0) 
		{
			grounded = false;
			myAnim.SetBool ("isGrounded",grounded);
			myRB.AddForce (new Vector2(0,jumpHeight));
		}

		if (Input.GetAxisRaw ("Fire1") > 0) 
		{
			fireRocket ();
		}	

		if (Input.GetKeyDown (KeyCode.G)) {
			throwGrenade ();
		}
	}
		
	void FixedUpdate () 
	{

		//check if we are grounded if no, then we are falling
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool ("isGrounded",grounded);

		myAnim.SetFloat ("verticalSpeed",myRB.velocity.y);

		float move = Input.GetAxis ("Horizontal");

		myAnim.SetFloat ("speed",Mathf.Abs (move));
		myRB.velocity = new Vector2 (move * maxSpeed , myRB.velocity.y);

		if (move > 0 && !facingRight) 
		{
			Flip ();
		}
		if (move < 0 && facingRight) 
		{
			Flip ();
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void fireRocket()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			if (facingRight) 
			{
				Instantiate (bullet,gunTip.position,Quaternion.Euler (new Vector3 (0,0,0)));
			}
			if (!facingRight) 
			{
				Instantiate (bullet,gunTip.position,Quaternion.Euler (new Vector3 (0,0,180f)));
			}
		}
	}

	void throwGrenade()
	{
		if (facingRight) 
		{
			Instantiate (grenade,grenadeTip.position,Quaternion.Euler (new Vector3 (0,0,0)));
		}
		if (!facingRight) 
		{
			Instantiate (grenade,grenadeTip.position,Quaternion.Euler (new Vector3 (0,0,180f)));
		}
	}
}
