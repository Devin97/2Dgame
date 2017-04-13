using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.CodeDom;
using System.Reflection.Emit;

public class playerHealth : MonoBehaviour {

	public float fullhealth;

	playerController check;

	public restartGame theGameManager;

	public GameObject deathFX;

	public Transform spawnPoint;

	public Transform fallSpawnPoint;

	public GameObject varCamera;

	public Text gameOverScreen;

	float currentHealth;

	public Slider healthSlider;

	public Image damageScreen;

	public Image lowhealthIndicatorScreen;

	public AudioClip[] SoundEffect;
	public AudioClip randomlySelectedAudio;
	public AudioClip playerFallSound;
	public AudioClip playerDeathSound;

	Animator lowHealthIndicatorAnim;

	private AudioSource setClip;

	bool damaged = false;
	bool isLow = false;

	Color damageColor = new Color(0f,0f,0f,0.5f);
	float smoothColor = 5f;

	public Image sliderFillColor;

	float endY;
	float soundEffectFalling;
	public int lives;
	float nextFall = 0f,fallRate = 2.5f;
	// Use this for initialization
	void Start () {
		check = GetComponent<playerController> ();
		varCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		lowHealthIndicatorAnim =  lowhealthIndicatorScreen.GetComponent<Animator> ();
		currentHealth = fullhealth;
		setClip = GetComponent<AudioSource> ();
		healthSlider.maxValue = fullhealth;
		healthSlider.value = fullhealth;
		endY = -20.00f;
		soundEffectFalling = -7f;
	}
	// Update is called once per frame
	void Update () { 
		/*if (currentHealth < 50f){
			StartCoroutine (blink ());
		}*/
		if (transform.position.y < soundEffectFalling) {
			AudioSource.PlayClipAtPoint (playerFallSound,transform.position);
		}

		if (damaged) {
			damageScreen.color = damageColor;
		} else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
		}

		if (sliderFillColor.color != Color.red) {
			isLow = false;
			lowHealthIndicatorAnim.SetBool ("indicate", isLow);
		}

		damaged = false;
		//StartCoroutine (fallDeath ());
		fallDeath ();
	}

	void fallDeath()
	{
		if (transform.position.y < endY  && nextFall < Time.time) {
			/*this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			yield return new WaitForSeconds (2f);
			transform.position = fallSpawnPoint.position;
			currentHealth -= 20f;
			healthSlider.value = currentHealth;
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;*/
			healthSlider.gameObject.SetActive (false);
			makeDead ();
			nextFall = fallRate + Time.time;
		} 
	}

	public void addDamage(float damage)
	{
		if (damage <= 0)
			return;
		currentHealth -= damage;
		healthSlider.value = currentHealth;
		damaged = true;
		randomlySelectedAudio = SoundEffect[Random.Range(0, SoundEffect.Length)];
		setClip.clip = randomlySelectedAudio;
		setClip.volume = 1f;
		setClip.Play ();
		//AudioSource.PlayClipAtPoint (randomlySelectedAudio,transform.position);
		if (currentHealth < 50f) {
			sliderFillColor.color = Color.red;
		} else if(currentHealth > 50f){
			sliderFillColor.color = Color.green;
		}

		if (sliderFillColor.color == Color.red) {
			isLow = true;
			lowHealthIndicatorAnim.SetBool ("indicate", isLow);
		} 
		if (currentHealth <= 0) {
			makeDead ();
			AudioSource.PlayClipAtPoint (playerDeathSound,transform.position);
			healthSlider.gameObject.SetActive (false);
		}
	}

	public void addhealth(float healthAmount)
	{
		currentHealth += healthAmount;
		if (currentHealth > fullhealth)
			currentHealth = fullhealth;
		healthSlider.value = currentHealth;
		if (healthSlider.value > 50f)
			sliderFillColor.color = Color.green;
	}

  	public void makeDead()
	{
		if (lives == 0) {
			Destroy (gameObject);
			damageScreen.color = damageColor;

			Animator gameOverAnimator = gameOverScreen.GetComponent<Animator> ();
			gameOverAnimator.SetTrigger ("gameOver");

			theGameManager.restartTheGame ();
			return;
		}
		Instantiate (deathFX, transform.position, transform.rotation);
		//transform.tag = "Untagged";
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		varCamera.GetComponent<cameraFollow> ().enabled = false;
		transform.tag = "NotPlayer";
		check.enabled = false;
		StartCoroutine (respawnPlayer ());
	}
		
	 IEnumerator respawnPlayer()
	{
		lives--;
		yield return new WaitForSeconds (2);
		this.transform.position = spawnPoint.position;
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		varCamera.GetComponent<cameraFollow> ().enabled = true;
		transform.tag = "Player";
		check.enabled = true;
		currentHealth = fullhealth;
		healthSlider.value = healthSlider.maxValue;
		sliderFillColor.color = Color.green;
		healthSlider.gameObject.SetActive (true);
	} 
	/*IEnumerator blink()
	{
		healthSlider.gameObject.SetActive (false);
		yield return new WaitForSeconds(0.1f);
		healthSlider.gameObject.SetActive (true);
	}*/
}
