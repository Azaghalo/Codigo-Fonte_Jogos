using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Pause : MonoBehaviour {

	public GameObject menu;
	public GameObject player;
	AudioSource playerSound;
	AudioSource pauseAudio;
	Image spriteMus;
	public Sprite onMus;
	public Sprite offMus;
	public GameObject sound;
	public GameObject certezaSair;
	public GameObject certezaMenu;
	public GameObject background;
    public AudioClip button1;
    public AudioClip button2;
    public GameObject soundEmitter;
    AudioSource soundPlace;


    void Awake(){
		spriteMus = sound.GetComponent<Image> ();
		playerSound = player.GetComponent<AudioSource> ();
		pauseAudio = GetComponent<AudioSource> ();
        soundPlace = soundEmitter.GetComponent<AudioSource>();
    }
    public void Sair () {
		if (certezaSair.activeSelf) {
            soundPlace.PlayOneShot(button1);
            certezaSair.SetActive (false);
			background.SetActive (false);
		} else {
            soundPlace.PlayOneShot(button1);
            certezaSair.SetActive (true);
			background.SetActive (true);
		}
	}
	public void IrMenu () {
		if (certezaMenu.activeSelf) {
            soundPlace.PlayOneShot(button1);
            background.SetActive (false);
			certezaMenu.SetActive (false);
		} else {
            soundPlace.PlayOneShot(button1);
            background.SetActive (true);
			certezaMenu.SetActive (true);
		}
	}
	public void MainMenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainMenu");
        soundPlace.PlayOneShot(button1);
    }
    public void Fechar(){
        soundPlace.PlayOneShot(button1);
        Application.Quit ();
	}
	public void PauseGame(){
        soundPlace.PlayOneShot(button2);
        playerSound.volume = (0);
		menu.SetActive (true);
		Time.timeScale = 0;
	}

	public void ResumeGame(){
        soundPlace.PlayOneShot(button2);
        playerSound.volume = (0.3f);
		menu.SetActive (false);
		Time.timeScale = 1;
	}

	public void StopMusic(){
		if(pauseAudio.isPlaying){
            soundPlace.PlayOneShot(button2);
            spriteMus.sprite = onMus;
			pauseAudio.Stop ();
		}else{
            soundPlace.PlayOneShot(button2);
            spriteMus.sprite = offMus;
			pauseAudio.Play ();
		}
	}
}