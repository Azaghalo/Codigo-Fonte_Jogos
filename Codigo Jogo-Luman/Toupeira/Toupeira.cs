using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toupeira : MonoBehaviour {

	GameObject player;
	Transform target;
	public Transform[] holes;
	public PlayerHealth vidaJogador;
	Animator toupeirAnim;

	bool isUnder;
	public bool isUnderneath;
	public bool isOver;
	public bool playerIsIn;

	public float sinkTime = 0.5f;
	public float subemergeDelay;
	public float moveDelay = 2f;
	public float emergeDelay;


	float underTime;
	float upperTime;
	float moveTime;




	void Start(){
		isUnder = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		toupeirAnim = GetComponentInChildren<Animator> ();
	}
	void Update(){
		if(playerIsIn){
		Appear ();
		GoUnder ();
		GoOver ();
		transform.LookAt (player.transform.position);
		}
	}
	void GoUnder(){
		if (transform.position.y <= -1f) {
			isUnderneath = true;
			isOver = false;
		}
		if (isUnderneath) {
			moveTime += Time.deltaTime;
			underTime = 0f;
			Vector3 up = new Vector3 (transform.position.x, 1f, transform.position.z);
			upperTime += Time.deltaTime;
			toupeirAnim.SetBool ("HelloWorld", true);
			if (upperTime >= emergeDelay) {
				toupeirAnim.SetBool ("HelloWorld", false);
				transform.position = Vector3.Lerp (transform.position, up, sinkTime);
			}
		}
	}
	void GoOver (){
		if (transform.position.y == 1f) {
			upperTime = 0f;
			isUnderneath = false;
			isOver = true;
		}
		if (isOver) {
			moveTime = 0f;
			Vector3 down = new Vector3 (transform.position.x, -1f, transform.position.z);
			underTime += Time.deltaTime;
			if (underTime >= subemergeDelay) {
				transform.position = Vector3.Lerp (transform.position, down, sinkTime );
				isUnder = true;
			}
		}
	}
	void Appear () {
		if (vidaJogador.currentHealth >= 0 && transform.position.y <= -1f && isUnder) {
			int holesIndex = Random.Range (0, holes.Length);
			transform.position = new Vector3 (holes [holesIndex].position.x, holes [holesIndex].position.y, holes [holesIndex].position.z);
			isUnder = false;
		}
		
	}
}
