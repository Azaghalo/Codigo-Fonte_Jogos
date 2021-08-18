using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {


	public GameObject MuvsTuts;
	public GameObject botoesTuts;
	public GameObject player;
	AudioSource walkSoun;
	public GameObject imageObj;
	public GameObject intrus;


	void Start(){
		walkSoun = player.GetComponent<AudioSource> ();
	}


	public void SairTutsBots(){
		imageObj.SetActive (true);
		walkSoun.volume = 0.3f;
		botoesTuts.SetActive(false);
		Time.timeScale = 1;
	}
	public void SairTutsMuvs(){
		MuvsTuts.SetActive(false);
	}
	public void SairTutsIntrus(){
		intrus.SetActive(false);
		MuvsTuts.SetActive(true);
	}
	

}
