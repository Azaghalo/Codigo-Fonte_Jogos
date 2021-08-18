using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public GameObject hPotion;
	public GameObject mPotion;
	public bool isDead;
	bool isSinking;
	BoxCollider boxCollider;
	AudioSource enemyAudio;
	public AudioClip death;
	public AudioClip pain;
	Animator anim;

	void Awake () {
		boxCollider = GetComponent<BoxCollider>();
		currentHealth = startingHealth;
		enemyAudio = GetComponent<AudioSource> ();
		anim = GetComponentInChildren<Animator> ();
	}
	
	void Update () {
		if (isSinking == true) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage (int amout){
		if (isDead == true) {
			return;
		}
		enemyAudio.PlayOneShot (pain);
		currentHealth -= amout;
		if (currentHealth <= 0) {
			Death ();
		}
	}

	void Death(){
		enemyAudio.Stop ();
		enemyAudio.PlayOneShot (death);
		isDead = true;
		boxCollider.isTrigger = true;
		AppearPotion ();
		Destroy (gameObject, 1.1f);
		anim.SetTrigger ("Dead");
	}

	void AppearPotion(){
		int ran = Random.Range (1, 10);
		int ranp = Random.Range (1, 10);
		if(ran >= 7 && ranp >= 5){
			StartCoroutine (DropH ());
		}else if(ran >= 7 && ranp <= 5){
			StartCoroutine (DropM ());
		}
	}
	void StartSinking (){
		GetComponent<Rigidbody> ().isKinematic = true;
		isSinking = true;
	}

	IEnumerator DropM(){
		yield return new WaitForSeconds (1f);
		Instantiate (mPotion, transform.position, transform.rotation);
	}
	IEnumerator DropH(){
		yield return new WaitForSeconds (1f);
		Instantiate (hPotion, transform.position, transform.rotation);
	}

}