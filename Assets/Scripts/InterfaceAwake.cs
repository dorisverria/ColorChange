using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceAwake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ScoreManager.score = 0;
		ScoreManager.difficultyLevel = 1;
		ScoreManager.scoreToNextLevel = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Click() {
		SceneManager.LoadScene ("Scene1");
}
}
