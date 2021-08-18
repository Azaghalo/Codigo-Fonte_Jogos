using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rock : MonoBehaviour {

	Toupeira topeira;
	GameObject boss;
	public GameObject rock;
	PlayerHealth playerHealth;
	public GameObject animatedMesh;
	ToupeiraHealth vida;
	TapToMove playerMovment;
	GameObject player;
	public int patadaDamage;
	public float attackAgain;
	public float attackFirst;
	float shootTimer;
	public float shootDelay;
	bool inRange;
	public AudioClip pedrada;
	AudioSource rockAudio;
	Animator toupeirAnim;
	int tiros;
	int shotsPerLife = 2;


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		boss = GameObject.FindGameObjectWithTag ("Toupeira");
		vida = boss.GetComponent<ToupeiraHealth> ();
		topeira = boss.GetComponent<Toupeira>();
		playerHealth = player.GetComponent <PlayerHealth> ();
		playerMovment = player.GetComponent <TapToMove> ();
		rockAudio = GetComponent<AudioSource> ();
		toupeirAnim = animatedMesh.GetComponent<Animator> ();
	}
	
	void Update () {
		Shoot ();
		if (topeira.isUnderneath) {
			tiros = 0;
		}
		if (vida.currentHealth <= 225) {
			shotsPerLife = 4;
			shootDelay = 0.3f;
		}

		inRange = false;
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player" && topeira.isOver && playerHealth.currentHealth > 0 && !playerMovment.doubleTap
			&& vida.currentHealth > 0) {
			inRange = true;
			toupeirAnim.SetTrigger ("InRange");
			playerHealth.TakeDamage (patadaDamage);		
		}
	}		
	void Shoot(){
		if (topeira.isOver && playerHealth.currentHealth > 0 && !inRange && tiros < shotsPerLife && topeira.playerIsIn) {
			shootTimer += Time.deltaTime;
			toupeirAnim.SetBool ("IWannaRock", true);
			if (shootTimer > shootDelay) {
				rockAudio.PlayOneShot (pedrada);
				Instantiate (rock, transform.position, transform.rotation);
				tiros ++;
				shootTimer = 0.0f;
				toupeirAnim.SetBool ("IWannaRock", false);
			}
		}
	}
}