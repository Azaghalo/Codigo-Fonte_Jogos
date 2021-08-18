using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosGate : MonoBehaviour {

	BoxCollider bossGate;
	public GameObject mainCamera;
	public GameObject bossCamera;
	public GameObject bossSlider;
	public GameObject boss;
	Toupeira bossScript;
	Vector3 startScale;
	public GameObject deathScreen;
	DeathScreen deathscreanScript;


	void Start () {
		bossScript = boss.GetComponent<Toupeira> ();
		bossGate = GetComponent<BoxCollider> ();
		startScale = gameObject.transform.localScale;
		deathscreanScript = deathScreen.GetComponent<DeathScreen> ();
	}
	void OnTriggerEnter(){


	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			bossGate.isTrigger = false;
			gameObject.transform.localScale = new Vector3 (8, 1, 1);
			mainCamera.SetActive (false);
			bossCamera.SetActive (true);
			bossSlider.SetActive (true);
			bossScript.playerIsIn = true;
		}
	}


	void Update () {
		if (deathscreanScript.died) {
			bossGate.isTrigger = true;
			bossScript.playerIsIn = false;
			gameObject.transform.localScale = startScale;
			mainCamera.SetActive(true);
			bossCamera.SetActive(false);
			bossSlider.SetActive(false);
			deathscreanScript.died = false;
		}
	}
}
