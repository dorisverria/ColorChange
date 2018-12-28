using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceFinal : MonoBehaviour {

	public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = ("Score: " + ScoreManager.score.ToString ());
	}

	public void Click() {

		SceneManager.LoadScene ("Awake");
	}

}
