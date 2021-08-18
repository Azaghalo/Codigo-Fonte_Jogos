using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLife : MonoBehaviour {



	public int expDmg;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	public int friendlyFire;
	SphereCollider myCollider;

	void Awake () {
		myCollider = GetComponent<SphereCollider> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	void Start () {

		Destroy (gameObject, 1.5f);
	}
	void OnTriggerEnter (Collider other){
		if (other.gameObject == player){
			playerHealth.TakeDamage (expDmg);
			myCollider.enabled = false;
		}else if(other.gameObject.tag == "Enemy") {
			enemyHealth = other.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) {
				enemyHealth.TakeDamage (friendlyFire);
			}
		}
	}
}
