using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int startinHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damagedImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
	public int restartDelay = 4;
	public int hPotion;
	public GameObject sound;
	public AudioClip drink;
	public AudioClip deathsound;
	public AudioClip[] pain;
	AudioSource healthAudio;
	ParticleSystem healthEffect;
	public GameObject emiter;
	int painIndex;
	int wichone;
	public GameObject botoesTuts;
	TapToMove playerMovement;
	AudioSource walk;
	public GameObject imageObj;



	bool wasHurt = false;
	bool isDead;
	bool damaged;

	void Awake () {
		walk = GetComponent<AudioSource> ();
		currentHealth = startinHealth;
		playerMovement = GetComponent <TapToMove> ();
		healthAudio = sound.GetComponent<AudioSource> ();
		healthEffect = emiter.GetComponent<ParticleSystem> ();
	}

	void Update () {
		if(painIndex % 3 == 0){
			wichone = 1;
		}else if(painIndex % 3 != 0){
			wichone = 0;
		}
		if (damaged) {
			damagedImage.color = flashColor;
		}
		else {
			damagedImage.color = Color.Lerp (damagedImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
		if (currentHealth > 100) {
			currentHealth = 100;
		}
	}
	public void TakeDamage (int amount){
		damaged = true;
		if(!healthAudio.isPlaying){
			painIndex++;
			healthAudio.PlayOneShot (pain[wichone]);
		}
		if(!wasHurt){
			imageObj.SetActive (false);
			walk.volume = 0;
			botoesTuts.SetActive(true);
			Time.timeScale = 0;
			wasHurt = true;
		}
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}
	void Death (){
		isDead = true;
		healthAudio.Stop ();
		healthAudio.PlayOneShot (deathsound);
		playerMovement.enabled = false;
	}
	public void RestoreHealth (int howMuch){
		if(hPotion > 0 && currentHealth < 100){
			healthAudio.PlayOneShot (drink);
			healthEffect.Emit (50);
			currentHealth += howMuch;
			healthSlider.value = currentHealth;
			hPotion -= 1;
		}
	}
}
