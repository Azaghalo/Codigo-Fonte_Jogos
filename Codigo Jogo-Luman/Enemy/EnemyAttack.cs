using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	TapToMove playerAttack; 
	bool playerInRange;
	float timer;
	AudioSource inimigoAudio;
	public AudioClip charge;
	Animator porcoAnim;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		playerAttack = player.GetComponent <TapToMove> ();
		inimigoAudio = GetComponent<AudioSource> ();
		porcoAnim = GetComponentInChildren<Animator> ();
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject == player && enemyHealth.currentHealth > 0){
			playerInRange = true;
			porcoAnim.SetBool ("ToAtack", true);
		}
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject == player) {
			playerInRange = false;
			porcoAnim.SetBool ("ToAtack", false);
		}
	}

	void Update () {
		enemyHealth = GetComponent<EnemyHealth> ();
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && playerHealth.currentHealth > 0 && playerAttack.doubleTap == false) {
			Attack ();
		}
	}

	void Attack (){
		timer = 0f;
		if (!inimigoAudio.isPlaying && playerHealth.currentHealth > 0 ) {
			inimigoAudio.PlayOneShot (charge);
			playerHealth.TakeDamage (attackDamage);
			porcoAnim.SetBool ("InRange", true);
		}
	}
}
