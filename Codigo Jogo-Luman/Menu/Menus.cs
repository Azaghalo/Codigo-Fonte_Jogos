using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {


	public GameObject certeza;
    public GameObject soundEmitter;
    AudioSource sound;
    public AudioClip firtButton;
    public AudioClip secondButton;
	public GameObject explosion;
	public Transform explosionSpawm;
	AudioSource music;
	public GameObject fadeIn;

    void Start(){
		music = GetComponent<AudioSource> ();
        sound = soundEmitter.GetComponent<AudioSource>();
    }


    public void Sair () {
		if (certeza.activeSelf) {
            sound.PlayOneShot(firtButton);
			certeza.SetActive (false);
		} else {
            sound.PlayOneShot(secondButton);
            certeza.SetActive (true);
		}
	}
	public void Iniciar(){
		music.Stop ();
        sound.PlayOneShot(firtButton);
		StartCoroutine (StartGame());
	}
	public void Fechar(){
        sound.PlayOneShot(firtButton);
        Application.Quit ();
	}
    public void Creditos(){
		SceneManager.LoadScene ("Credits");
        sound.PlayOneShot(firtButton);
    }

	IEnumerator StartGame(){
		yield return new WaitForSeconds (0.5f);
		Instantiate (explosion, explosionSpawm.transform.position, explosionSpawm.transform.rotation);
		yield return new WaitForSeconds (1);
		fadeIn.SetActive (true);
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("batalha_Alpha");
	}

}
