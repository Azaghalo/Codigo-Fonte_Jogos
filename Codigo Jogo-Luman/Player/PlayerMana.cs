using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour {

	public int startinMana = 100;
	public float currentMana;
	public Slider manaSlider;
	public int mPotion;
	public AudioClip drink;
	public GameObject sound;
	AudioSource manaAudio;
	ParticleSystem manaEffect;
	public GameObject emiter;
	TapToMove tapToMove;
	float t;
	float tDoubleTap;
	public float tGoal;	
	public float tGoalDoubleTap;
	public float refilValue;


	void Awake () {
		currentMana = startinMana;
		manaAudio = sound.GetComponent<AudioSource> ();
		manaEffect = emiter.GetComponent<ParticleSystem> ();
		tapToMove = GetComponent<TapToMove> ();
	}


	void Update () {
		if (currentMana < 0) {
			currentMana = 0;
		}
		if (currentMana > 100) {
			currentMana = 100;
		}
		RefillOverTime ();
	}
	public void UseMana (int amout){
			currentMana -= amout;
			manaSlider.value = currentMana;
	}

	public void RestoreMana (int howMuch){

		if(mPotion > 0 && currentMana < 100){
			manaAudio.Pause ();
			manaAudio.PlayOneShot (drink);
			manaAudio.UnPause ();
			manaEffect.Emit (50);
			currentMana += howMuch;
			manaSlider.value = currentMana;
			mPotion -= 1;
			print (mPotion);
		}
	}

	void RefillOverTime (){
		if(!tapToMove.doubleTap){
			tDoubleTap += Time.deltaTime;
			if(tDoubleTap >= tGoalDoubleTap){
				t += Time.deltaTime;
				if(t >= tGoal && currentMana < 100){
					t = 0.0f;
					currentMana += refilValue;
					manaSlider.value = currentMana;
				}
			}
		}
		if (tapToMove.doubleTap) {
			tDoubleTap = 0.0f;
		}
	}
}

