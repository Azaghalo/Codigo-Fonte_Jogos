using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySlashSound : MonoBehaviour {

	TapToMove playerMovment;	
	public AudioClip slash;
	AudioSource slashAudio;
	public GameObject player;


	void Start () {
		slashAudio = GetComponent<AudioSource> ();
        playerMovment = player.GetComponent<TapToMove>();
    }

    void Update () {
		if (playerMovment.doubleTap && !slashAudio.isPlaying && !playerMovment.tocou) {
            playerMovment.tocou = true;
			slashAudio.PlayOneShot (slash, 0.5f);
		}
	}
}
