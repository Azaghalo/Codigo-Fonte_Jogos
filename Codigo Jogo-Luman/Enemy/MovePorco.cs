using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePorco : MonoBehaviour {
	GameObject player;
	PlayerHealth playerHealth;
	NavMeshAgent nav;
	RaycastHit hit;
	Vector3 startingPoint;
	EnemyHealth health;
	Animator porcoAnim;
	ToupeiraHealth tpHealth;
	public GameObject topeira;


	bool alive;
	float dist;
	public float maxDist;
	bool inSight;
	public LayerMask layerMask = -1;

	void Awake () {
		tpHealth = topeira.GetComponent<ToupeiraHealth> ();
		alive = true;
		startingPoint = transform.position;
		inSight = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		nav = GetComponent <NavMeshAgent> ();
		health = GetComponent<EnemyHealth> ();
		porcoAnim = GetComponentInChildren<Animator> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void Update () {
		PlayerAlive ();
		IsSeeing ();
		Distancia ();
		Acao ();
		if(health.isDead){
			nav.SetDestination (transform.position);
		}
	}
	void Distancia(){
		dist = Vector3.Distance (player.transform.position, transform.position);
	}
	void Acao(){
		if(inSight == true && dist <= maxDist && alive == true && !tpHealth.stopGetSomeHelp){
			nav.SetDestination (player.transform.position);
			porcoAnim.SetBool ("InRange", true);
		}
		else if(inSight == false || !alive || tpHealth.stopGetSomeHelp){
			nav.SetDestination (startingPoint);
		}
		if(transform.position == startingPoint){
			porcoAnim.SetBool ("InRange", false);
			if(tpHealth.stopGetSomeHelp){
				Destroy (gameObject);
			}
		}
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

	void PlayerAlive(){
		if (playerHealth.currentHealth > 0) {
			alive = true;
		} 
		else if (playerHealth.currentHealth <= 0){
			alive = false;
		}
	}
}

