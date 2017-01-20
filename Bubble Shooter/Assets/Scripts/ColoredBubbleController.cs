using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColoredBubbleController : MonoBehaviour {

	GameObject gC;
	GameController gameController;
	//ajouter à la liste du gamecontroller

	public bool isConnectedToTop = true;


	List<GameObject> adjacentBubbles = new List<GameObject>();

	void Start(){
		gC = GameObject.FindWithTag ("Game Controller");
		gameController = gC.GetComponent<GameController> ();
		gameController.AddToExistingBubbles (gameObject);
	}

	void OnTriggerEnter (Collider other){
		if (gameObject.tag == other.tag) {
			adjacentBubbles.Add (other.gameObject);
		}

	}



	//faire tomber si non connecté au haut de l'écran

	void OnDestroy(){
		foreach (GameObject bubble in adjacentBubbles) {
			if (bubble != null) {
				if (bubble.tag == gameObject.tag) {

					Destroy (bubble);
				}
			}
		}

	}

}
