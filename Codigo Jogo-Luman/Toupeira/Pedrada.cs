using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedrada : MonoBehaviour {

	public Rigidbody rock;
	public float force;
	public float limite;
	Vector3 posicaoInicial;
	PlayerHealth playerHealth;
	TapToMove playerMovment;
	GameObject player;
	public int attackDamage;
	public int slowDown;
	public float slowDownTime;




	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		posicaoInicial = transform.position;
		playerHealth = player.GetComponent <PlayerHealth> ();
		playerMovment = player.GetComponent <TapToMove> ();
	}

	void Update () {
		transform.Translate (Vector3.forward * force * Time.deltaTime);
	
		float D =	Vector3.Distance (posicaoInicial, transform.position);

		if( D > limite){

			Destroy (gameObject);

		}
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Player") {
			if (playerHealth.currentHealth > 0 ) {
				playerHealth.TakeDamage (attackDamage);
				StartCoroutine (SlowDown ());
				Destroy (gameObject);
			}
			else{
				Destroy (gameObject);
			}
		}
	}

	IEnumerator SlowDown(){
		playerMovment.doubleTap = false;
		playerMovment.speed = slowDown;
		yield return new WaitForSeconds (slowDownTime);
		playerMovment.speed = playerMovment.defspeed;
	}


}
