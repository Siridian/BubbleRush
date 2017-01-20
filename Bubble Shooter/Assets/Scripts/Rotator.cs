using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	[SerializeField]
	GameController gameController;

	[SerializeField]
	private float rotationSpeed = 5;

	Rigidbody rb;



	void Start () {
		rb = GetComponent<Rigidbody> ();
	}


	void FixedUpdate () {
		
		if (!gameController.isGameOver && !gameController.isGameWon){
			float rotateY = Input.GetAxisRaw ("Horizontal");
			Vector3 movement = new Vector3 (0.0f, rotateY, 0.0f);
			rb.angularVelocity = movement * rotationSpeed;

			//Trouver une manière de clamper la rotation à -85, 85
		}

	}


}
