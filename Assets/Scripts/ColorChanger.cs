using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorChanger : MonoBehaviour {

	public Material[] materials = new Material[4];
	int delay = 3;


	void Start()
	{
		InvokeRepeating ("ChangeColor", delay, delay);
	}

	void ChangeColor()
	{
		gameObject.GetComponent<Renderer> ().material = materials [Random.Range (0, materials.Length)];
	}
}
