using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public GameObject player;
	PlayerMana playerMana;
	PlayerHealth playerHealth;
	public int hPAmount;
	public int mPAmount;
	public int curHealth;

	void Awake(){
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerMana = player.GetComponent<PlayerMana> ();
	}


	void Update () {
		hPAmount = playerHealth.hPotion;
		mPAmount = playerMana.mPotion;
	}
}

