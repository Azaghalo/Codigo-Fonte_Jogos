using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour {

	public GameObject lightss;
	public GameObject aliveHud;
	public GameObject deathHud;
	public GameObject playerLight;
	public GameObject cenario;
	public GameObject player;
	PlayerHealth health;
	TapToMove playerMovment;
	public Slider healthSlider;
	Animator annaAnim;
	bool isDead;
	float timer;
	public float delay;
	AudioSource musicPlayer;
	public GameObject deathPlayer;
	public bool died;
	public GameObject olhos;
	Animator olhosAnim;


	void Start () {
		musicPlayer = GetComponent<AudioSource> ();
		playerMovment = player.GetComponent<TapToMove> ();
		health = player.GetComponent<PlayerHealth> ();
		annaAnim = player.GetComponentInChildren<Animator> ();
		olhosAnim = olhos.GetComponent<Animator> ();
	}
	
	void Update () {
		if(health.currentHealth <=0){
			deathPlayer.SetActive (true);
			musicPlayer.enabled = false;
			timer += Time.deltaTime;
			annaAnim.SetBool ("IsDying", true);
			olhosAnim.SetBool ("IsDead", true);
			lightss.SetActive (false);
			playerLight.SetActive (true);
			cenario.SetActive (false);
			lightss.SetActive (false);
			aliveHud.SetActive (false);
			if(timer >= delay){
				deathHud.SetActive (true);
			}
		}
	}
	public void DeathYes(){
		died = true;
		deathPlayer.SetActive (false);
		musicPlayer.enabled = true;
		aliveHud.SetActive (true);
		annaAnim.SetBool ("IsDying", false);
		olhosAnim.SetBool ("IsDead", false);
		player.transform.position = CheckPoints.chekPointPos;
		lightss.SetActive (true);
		health.currentHealth = 100;
		healthSlider.value = health.currentHealth;
		playerMovment.enabled = true;
		playerLight.SetActive (false);
		playerMovment.endPoint = player.transform.position;
		deathHud.SetActive (false);
		cenario.SetActive (true);
		lightss.SetActive (true);
	}
}
