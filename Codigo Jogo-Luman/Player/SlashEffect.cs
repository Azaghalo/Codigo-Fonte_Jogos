using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : MonoBehaviour {

	TapToMove movimento;
	ParticleSystem slash;
	public GameObject emiter;


	void Start () {
		movimento = GetComponent<TapToMove> ();

		slash = emiter.GetComponent<ParticleSystem> ();
	}
	
	void Update () {
		if(movimento.doubleTap){
			slash.Emit (5);
		}
	}
}
