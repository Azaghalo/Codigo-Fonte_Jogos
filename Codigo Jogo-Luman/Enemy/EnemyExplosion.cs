using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	TapToMove playerMov;
	public GameObject explosion;
	bool perto;
	float timer;
	public float bumbumTimer;
	AudioSource explosionSFX;
	public	AudioClip bumbumSFX;
	Animator anim;



	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		playerMov = player.GetComponent <TapToMove> ();
		enemyHealth = GetComponent<EnemyHealth> ();
		explosionSFX = GetComponent<AudioSource> ();
		perto = false;
		anim = GetComponentInChildren<Animator> ();


	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject == player && enemyHealth.currentHealth > 0 && !playerMov.doubleTap ){
			perto = true;
			explosionSFX.Play ();
			anim.SetBool ("InRange", true);
		}
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject == player) {
			perto = false;
			explosionSFX.Stop ();
			timer = 0;
			anim.SetBool ("InRange", false);
		}
	}
	void Update(){
		if(perto && playerHealth.currentHealth > 0){
			timer += Time.deltaTime;
			if(timer >= bumbumTimer){
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}

	}
}
