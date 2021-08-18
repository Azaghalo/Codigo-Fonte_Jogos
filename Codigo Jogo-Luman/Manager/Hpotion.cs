using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpotion : MonoBehaviour {

	PlayerHealth playerHealth;
	GameObject player;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	void Update () {
		playerHealth = player.GetComponent<PlayerHealth> ();
		GetComponent<Text> ().text = "" + playerHealth.hPotion; 
	}
}
