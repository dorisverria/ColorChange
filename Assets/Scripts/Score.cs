using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	 
	public Text scoreText;
	public Text levelText;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		scoreText.text = "Points: " + ScoreManager.score.ToString();
		levelText.text = "Level: " + (ScoreManager.difficultyLevel / 10).ToString ();

		if (ScoreManager.score >= ScoreManager.scoreToNextLevel && (ScoreManager.score >= ScoreManager.difficultyLevel))
			LevelUp ();

		else if (ScoreManager.score < ScoreManager.scoreToNextLevel - 10 && ScoreManager.score < ScoreManager.difficultyLevel - 10) 
			LevelDown ();
	}

	void LevelUp () {

		if (ScoreManager.difficultyLevel == ScoreManager.maxDifficultyLevel)
			return;

		ScoreManager.scoreToNextLevel += 10;
		ScoreManager.difficultyLevel+=10;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMotor> ().IncreaseSpeed ();
		for (int i = 0; i< GameObject.FindGameObjectsWithTag("EnemyManager").Length; i++)
		{
			GameObject.FindGameObjectsWithTag ("EnemyManager") [i].GetComponent<Spawner> ().DecreaseTime ();
		}
	}

	void LevelDown() {

		if (ScoreManager.difficultyLevel <= 10)
			return;

		ScoreManager.scoreToNextLevel -= 10;
		ScoreManager.difficultyLevel -= 10;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMotor> ().DecreaseSpeed ();
		for (int i = 0; i< GameObject.FindGameObjectsWithTag("EnemyManager").Length; i++) {
			GameObject.FindGameObjectsWithTag ("EnemyManager") [i].GetComponent<Spawner> ().IncreaseTime ();
		}

	}
}
