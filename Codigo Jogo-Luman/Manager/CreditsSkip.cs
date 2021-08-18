using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsSkip : MonoBehaviour {

	public AnimationClip fadeIn;
	public AudioClip creditsMusic;
	float waitTime;
	bool calledIt;
	bool started;

	void Start(){
		waitTime = creditsMusic.length + 0.5f;
		StartCoroutine (ReturnMain ());
		Time.timeScale = 0;
	}


	void Update () {
		if(Input.GetButtonDown("Cancel")){
			SceneManager.LoadScene ("MainMenu");
		}
		if(!started){
		StartCoroutine(ReturnMain());
		}
		if(!calledIt){
			StartCoroutine(FadeIn());
		}
	}
	IEnumerator FadeIn (){
		calledIt = true;
		yield return new WaitForSecondsRealtime (fadeIn.length);
		Time.timeScale = 1;
	}


	IEnumerator ReturnMain (){
		started = true;
		yield return new WaitForSeconds (waitTime);
		SceneManager.LoadScene ("MainMenu");
	}

}
