using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class EndLevel : MonoBehaviour {


	public GameObject gate;
	public GameObject fade;
	public AnimationClip fadeAnim;
	Animator gateAc;
	public GameObject player;
	public Transform endPointDos;
	TapToMove playerMov;
	Animator playerAC;
	public GameObject anna;


	void Start(){
		gateAc = gate.GetComponent<Animator> ();
		playerMov = player.GetComponent<TapToMove> ();
		playerAC = anna.GetComponent<Animator> ();
	}


	void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Player"){
			playerMov.isthere = true;
			gateAc.SetTrigger ("OpenThisShit");
			StartCoroutine(EndLvl());
		}
	}
	IEnumerator EndLvl (){
		yield return new WaitForSeconds (1);
		playerAC.SetBool ("IsRunning", true);
		playerMov.endPoint = endPointDos.transform.position;
		fade.SetActive (true);
		yield return new WaitForSeconds (fadeAnim.length + 0.5f);
		SceneManager.LoadScene ("Credits");

	}

}
