using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

	public float enemyMaxHealth;

	public GameObject enemyDeathFX;

	public Slider enemySlider;

	public Image lowHealthIndicator;

	public AudioClip boardeath;

	public bool drops;

	public GameObject theDrop;

	float currenthealth;

	public bool checkHealth = false;

	//float knockbackX = 10f,knockbackY=10f;

	// Use this for initialization
	void Start () {
		currenthealth = enemyMaxHealth;
		enemySlider.maxValue = enemyMaxHealth;
		enemySlider.value = currenthealth;
		enemySlider.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void addDamage(float damage)
	{
		currenthealth -= damage;
		//this.gameObject.GetComponentInParent<Rigidbody2D> ().AddForce (new Vector2 (knockbackX, knockbackY), ForceMode2D.Impulse);
		//pushBackEnemy ();
		enemySlider.value = currenthealth;
		enemySlider.gameObject.SetActive (true);
		if (currenthealth < 10f)
			lowHealthIndicator.color = Color.red;
		if (currenthealth <= 0) {
			checkHealth = true;
			enemySlider.gameObject.SetActive (false);
			makeDead ();
		}
	}

	/*void pushBackEnemy()
	{
		if (this.gameObject.GetComponentInParent<Rigidbody2D> ().gameObject.name == "killseBoar") {
			GetComponentInParent<Rigidbody2D> ().AddForce (new Vector2 (knockbackX, -knockbackY), ForceMode2D.Force);
		} else {
			return;
		}
	}*/

	public void makeDead()
	{
		Destroy (gameObject.transform.parent.gameObject);
		AudioSource.PlayClipAtPoint (boardeath,transform.position);
		Instantiate (enemyDeathFX,transform.position,transform.rotation);
		if (drops)
			Instantiate (theDrop, transform.position, transform.rotation);
	}
}
