using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private Vector3 moveVector;
	private float speed = 3.3f;
	private float verticalVelocity = 0.0f;
	private float gravity = 12.0f;
	private float jumpForce = 2.9f;

	// Use this for initialization
	void Start () {

		controller = GetComponent<CharacterController> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.transform.position.y < -5f) {

			SceneManager.LoadScene ("Final");
		
		}
	
		moveVector = Vector3.zero;

		if (controller.isGrounded) {

			verticalVelocity = -gravity * Time.deltaTime;
			if(Input.GetButton("Jump")) 
			   	{
					verticalVelocity = jumpForce;
				}	 
			}

		else {

				verticalVelocity -= gravity * Time.deltaTime;

		}

	
		moveVector.x = Input.GetAxisRaw ("Horizontal") * speed;
		moveVector.y = verticalVelocity;
		moveVector.z = speed;
		controller.Move ((moveVector * speed) * Time.deltaTime);
	}

	public void IncreaseSpeed() {

		if (speed <= 0f)
			return;

		speed += 0.10f;

	}

	public void DecreaseSpeed () {

		speed -= 0.10f;
	}
}
