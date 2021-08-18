using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject[] enemy;
	public Transform [] spawnPoints;
	public GameObject boss;
	ToupeiraHealth vida;
	bool coroutineIsOn;
	Toupeira bossMov;


	void Awake () {
		bossMov = boss.GetComponent<Toupeira> ();
		vida = boss.GetComponent<ToupeiraHealth> ();
	}

    void Update () { 
		if(vida.currentHealth <= 150 && !coroutineIsOn && !vida.stopGetSomeHelp && bossMov.playerIsIn){
			StartCoroutine (SpawnBoss());
		}

	}

	IEnumerator SpawnBoss(){
		if(bossMov.playerIsIn && vida.currentHealth > 0){
		coroutineIsOn = true;
		int enemyIndex = Random.Range (0, enemy.Length);
		int enemyIndexDois = Random.Range (0, enemy.Length);
		int enemyIndexTres = Random.Range (0, enemy.Length);

		int spawnIndex = Random.Range (0, spawnPoints.Length);
		int spawnIndexDois = Random.Range (0, spawnPoints.Length);
		int spawnIndexTres = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy[enemyIndex], spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
		Instantiate (enemy[enemyIndexDois], spawnPoints[spawnIndexDois].transform.position, spawnPoints[spawnIndexDois].transform.rotation);
		Instantiate (enemy[enemyIndexTres], spawnPoints[spawnIndexTres].transform.position, spawnPoints[spawnIndexTres].transform.rotation);
		yield return new WaitForSeconds (10);
		StartCoroutine (SpawnBoss ());
		}else{
			yield break;
		}
	}

}
	
