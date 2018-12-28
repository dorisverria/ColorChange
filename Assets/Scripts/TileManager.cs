using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;
	private float spawnZ = -15.0f;
	private float tileLength = 12.0f;
	private int tilesPerScreen = 4;
	private float safeZone = 19.0f;
	private List<GameObject> activeTiles;
	private int lastPrefabIndex = 0;


	private Transform playerTransform;


	// Use this for initialization
	void Start () {

		activeTiles = new List<GameObject> ();

		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i=0; i<tilesPerScreen; i++)
			SpawnTile();

	
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ - tilesPerScreen * tileLength)) 
		{
			SpawnTile();
			DeleteTile ();
		}
	}

	void SpawnTile (int prefabindex = -1)
	{
		GameObject go;
		go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);
	}

	void DeleteTile ()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);

	}

	int RandomPrefabIndex ()
	{
		if (tilePrefabs.Length <= 1)
			return 0;

		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex) 
		{
			randomIndex = Random.Range (0, tilePrefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}