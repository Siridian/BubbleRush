using UnityEngine;
using System.Collections;

public class RedShotContact : MonoBehaviour {

	[SerializeField]
	GameObject createdBubble;

	Shooter shooter = null;

	[SerializeField]
	GameObject explosion = null;

	GameObject gC;
	GameController gameController;

	void Start(){
		GameObject shotSpawn = GameObject.FindWithTag ("ShotSpawn");
		shooter = shotSpawn.GetComponent<Shooter>();
		gC = GameObject.FindWithTag ("Game Controller");
		gameController = gC.GetComponent<GameController> ();
	}

	void OnTriggerEnter (Collider other){


			if (other.tag == "Red Bubble") {
				Instantiate (explosion, other.transform.position, Quaternion.identity);
				Instantiate (explosion, gameObject.transform.position, Quaternion.identity);
				Destroy (other.gameObject);
				Destroy (gameObject);
				gameController.bubbleCount--;
				shooter.isAShotActive = false;

			} else if (other.tag == "Blue Bubble" || other.tag == "Green Bubble" || other.tag == "Yellow Bubble"){
				Instantiate (createdBubble, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity );
				gameController.bubbleCount++;
				shooter.isAShotActive = false;
				Destroy (gameObject);
			}

		}

}
