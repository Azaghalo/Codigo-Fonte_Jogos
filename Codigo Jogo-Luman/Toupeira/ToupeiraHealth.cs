using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ToupeiraHealth : MonoBehaviour {

	public int startinHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	Toupeira movement;
	bool isDead;
	public GameObject player;
	bool calledIt;
	TapToMove playerMov;
	public bool stopGetSomeHelp;

	void Awake () {
		playerMov = player.GetComponent<TapToMove> ();
		movement = GetComponent <Toupeira> ();
		currentHealth = startinHealth;
	}
	void Update () {
		if (currentHealth <= 0) {
			Death ();
		}
	}
	public void TakeDamage (int amount){
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}
	void Death (){
		isDead = true;
		movement.enabled = false;
		if(!calledIt){
			StartCoroutine (Retreat ());
		}
	}

	IEnumerator Retreat(){
		Vector3 down = new Vector3 (transform.position.x, -5f, transform.position.z);
		yield return new WaitForSeconds (2);
		transform.position = Vector3.Lerp (transform.position, down, 0.1f);
		playerMov.finished = true;
		calledIt = true;
	}

}