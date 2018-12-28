using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

	public GameObject[] enemies;
	private float spawnTime = 0.8f;
	public Transform[] spawnPoints;



	void Start () {

		InvokeRepeating ("Spawn", spawnTime, spawnTime);

	}
	// Update is called once per frame
	void Update () {

	}

	void Spawn ()
	{
		if (ScoreManager.score < -100)
			SceneManager.LoadScene ("Final");

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		
		Destroy(Instantiate (enemies[Random.Range(0, enemies.Length)], spawnPoints[spawnPointIndex].position + 2 * Vector3.forward, spawnPoints[spawnPointIndex].rotation), 15f);
	}

	public void IncreaseTime() {

		if(spawnTime <= 0.6f)
		spawnTime += 0.1f;
	}

	public void DecreaseTime() {

		if(spawnTime >= 0.1f)
		spawnTime -= 0.1f;
	}

}


