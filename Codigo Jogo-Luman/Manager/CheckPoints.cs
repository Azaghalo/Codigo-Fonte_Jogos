using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

	public static Vector3 chekPointPos;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player"){
			chekPointPos = transform.position;
		}
	}

}
