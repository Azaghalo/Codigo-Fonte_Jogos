using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

	PlayerHealth playerHealth;
	GameObject player;
	AudioSource potionAudio;
	Renderer ren;
	Collider potionCollider;
	public AudioClip item;
	Light potionLight;
	GameObject mainCamera;
	Vector3 cameraPos;


	void Start () {
		potionLight = GetComponent<Light> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		potionAudio = GetComponent<AudioSource> ();
		ren = GetComponent<Renderer> ();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		potionCollider = GetComponent<Collider> ();
	}
	void Update(){
		cameraPos = mainCamera.transform.position;
		transform.LookAt (cameraPos);
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player"){
			ren.enabled = false;
			potionCollider.enabled = false;
			potionLight.enabled = false;
			potionAudio.PlayOneShot (item);
			playerHealth.hPotion += 1;
			Destroy (this.gameObject, item.length);
		}
	}
}
