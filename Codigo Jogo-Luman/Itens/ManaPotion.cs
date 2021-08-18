using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour {


	PlayerMana playerMana;
	GameObject player;
	public AudioClip item;
	AudioSource potionAudio;
	Renderer ren;
	Collider potionCollider;
	Light potionLight;
	GameObject mainCamera;
	Vector3 cameraPos;

	void Start () {
		potionLight = GetComponent<Light> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerMana = player.GetComponent<PlayerMana> ();
		potionAudio = GetComponent<AudioSource> ();
		ren = GetComponent<Renderer> ();
		potionCollider = GetComponent<Collider> ();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update(){
		cameraPos = mainCamera.transform.position;
		transform.LookAt (cameraPos);
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player"){
			ren.enabled = false;
			potionLight.enabled = false;
			potionCollider.enabled = false;
			potionAudio.PlayOneShot (item);
			playerMana.mPotion += 1;
			Destroy (this.gameObject, item.length);
		}
	}
}
