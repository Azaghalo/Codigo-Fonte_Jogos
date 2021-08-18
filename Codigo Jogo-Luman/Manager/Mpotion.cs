using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mpotion : MonoBehaviour {

	PlayerMana playerMana;
	GameObject player;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void Update () {
		playerMana = player.GetComponent<PlayerMana> ();
		GetComponent<Text> ().text = "" + playerMana.mPotion; 
	}
}