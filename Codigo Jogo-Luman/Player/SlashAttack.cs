using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlashAttack : MonoBehaviour {

	public int damagePerHit;

	ToupeiraHealth toupeira;
	EnemyHealth enemyHealth;
	TapToMove tapToMove;

	void Awake(){
		tapToMove = GetComponentInParent<TapToMove> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy" && tapToMove.doubleTap) {
			enemyHealth = other.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) {
				enemyHealth.TakeDamage (damagePerHit);
			}
		}else if(other.gameObject.tag == "Toupeira" && tapToMove.doubleTap){
			toupeira = other.GetComponent<ToupeiraHealth> ();
			if (toupeira != null) {
				toupeira.TakeDamage (damagePerHit);
			}
		}
	}
}