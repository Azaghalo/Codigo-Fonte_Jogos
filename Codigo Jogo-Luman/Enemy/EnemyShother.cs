using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShother : MonoBehaviour {


	GameObject player;
	PlayerHealth playerHealth;
	RaycastHit hit;
	EnemyHealth health;
	public GameObject rock;
	Vector3 playerPos;
	Animator anim;


	float dist;
	public float maxDist;
	bool inSight;
	public LayerMask layerMask = -1;
	float shootTimer;
	public float shootDelay;
	public AudioClip pedrada;
	AudioSource rockAudio;



	void Start () {
		inSight = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		health = GetComponent<EnemyHealth> ();
		rockAudio = GetComponent<AudioSource> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
		anim = GetComponentInChildren<Animator> ();
	}
	
	void Update () {
		IsSeeing ();
		Shoot ();
		Distancia ();
		playerPos = player.transform.position;
		this.transform.LookAt(playerPos);
	}
	void IsSeeing(){
		if (Physics.Raycast (transform.position, player.transform.position - transform.position, out hit, Mathf.Infinity, layerMask)) {
			if (hit.collider.gameObject == player) {
				inSight = true;
			} 
			else {
				inSight = false;
			}
		}
	}
	void Distancia(){
		dist = Vector3.Distance (player.transform.position, transform.position);
	}
	void Shoot(){
		if (playerHealth.currentHealth > 0 && inSight && health.currentHealth > 0 && dist <= maxDist ) {
			shootTimer += Time.deltaTime;
			anim.SetBool ("Atirando", true);
			if (shootTimer > shootDelay) {
				rockAudio.PlayOneShot (pedrada);
				Instantiate (rock, transform.position, transform.rotation);
				shootTimer = 0.0f;
			}
		}else if(!inSight){
			anim.SetBool ("Atirando", false);
		}
	}
}
