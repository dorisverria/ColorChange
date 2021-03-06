﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour {

	public float delta = 5.0f;  // Amount to move left and right from the start point
	public float speed = 2.0f; 
	private Vector3 startPos;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = startPos;
		v.z += delta * Mathf.Sin (Time.time * speed);
		transform.position = v;
	}
}
