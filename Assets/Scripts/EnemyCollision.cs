using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	public AudioSource correct;
	public AudioSource incorrect;

	void Start () {
		AudioSource[] audioArray = GetComponents<AudioSource> ();
		correct = audioArray [0];
		incorrect = audioArray [1];

	}


	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy" &&
			other.gameObject.GetComponent<Renderer> ().sharedMaterial == gameObject.GetComponent<Renderer> ().sharedMaterial) 
		{
			ScoreManager.score += 10;
			correct.Play ();
			Destroy (other.gameObject);
		} 

		else
		{
			ScoreManager.score -= 5;
			incorrect.Play ();
		}
}
}