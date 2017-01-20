using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {


	[SerializeField]
	GameObject greenShot = null;
	[SerializeField]
	GameObject blueShot = null;
	[SerializeField]
	GameObject redShot = null;
	[SerializeField]
	GameObject yellowShot = null;

	[SerializeField]
	GameObject CurrentRedSprite = null;
	[SerializeField]
	GameObject CurrentBlueSprite = null;
	[SerializeField]
	GameObject CurrentGreenSprite = null;
	[SerializeField]
	GameObject CurrentYellowSprite = null;

	[SerializeField]
	GameObject NextRedSprite = null;
	[SerializeField]
	GameObject NextBlueSprite = null;
	[SerializeField]
	GameObject NextGreenSprite = null;
	[SerializeField]
	GameObject NextYellowSprite = null;

	[SerializeField]
	GameController gameController = null;

	private int loadedShot = 0;
	private int nextShot = 0;

	public bool isAShotActive = false;

	// Use this for initialization
	void Start () {
		loadedShot = Random.Range (1, 5);
		nextShot = Random.Range (1, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
		switch (loadedShot) {

		case 1:
			CurrentGreenSprite.SetActive (true);
			CurrentBlueSprite.SetActive (false);
			CurrentRedSprite.SetActive (false);
			CurrentYellowSprite.SetActive (false);
			break;

		case 2:
			CurrentGreenSprite.SetActive (false);
			CurrentBlueSprite.SetActive(true);
			CurrentRedSprite.SetActive (false);
			CurrentYellowSprite.SetActive (false);
			break;

		case 3:
			CurrentGreenSprite.SetActive (false);
			CurrentBlueSprite.SetActive (false);
			CurrentRedSprite.SetActive (true);
			CurrentYellowSprite.SetActive (false);
			break;

		case 4:
			CurrentGreenSprite.SetActive (false);
			CurrentBlueSprite.SetActive (false);
			CurrentRedSprite.SetActive (false);
			CurrentYellowSprite.SetActive (true);
			break;

		default:
			Debug.Log ("Shot selection error");
			break;
		}

		switch (nextShot) {

		case 1:
			NextGreenSprite.SetActive (true);
			NextBlueSprite.SetActive (false);
			NextRedSprite.SetActive (false);
			NextYellowSprite.SetActive (false);
			break;

		case 2:
			NextGreenSprite.SetActive (false);
			NextBlueSprite.SetActive (true);
			NextRedSprite.SetActive (false);
			NextYellowSprite.SetActive (false);
			break;

		case 3:
			NextGreenSprite.SetActive (false);
			NextBlueSprite.SetActive (false);
			NextRedSprite.SetActive (true);
			NextYellowSprite.SetActive (false);
			break;

		case 4:
			NextGreenSprite.SetActive (false);
			NextBlueSprite.SetActive (false);
			NextRedSprite.SetActive (false);
			NextYellowSprite.SetActive (true);
			break;

		default:
			Debug.Log ("Shot selection error");
			break;
		}

		if (Input.GetKeyDown ("down")){
			int storedValue = nextShot;
			nextShot = loadedShot;
			loadedShot = storedValue;
		}

		if (Input.GetKeyDown ("space") && !isAShotActive && !gameController.isGameOver && !gameController.isGameWon) {

			switch (loadedShot) {

			case 1:
				Instantiate (greenShot, gameObject.transform.position, gameObject.transform.rotation);
				break;

			case 2:
				Instantiate (blueShot, gameObject.transform.position, gameObject.transform.rotation);
				break;

			case 3:
				Instantiate (redShot, gameObject.transform.position, gameObject.transform.rotation);
				break;

			case 4:
				Instantiate (yellowShot, gameObject.transform.position, gameObject.transform.rotation);
				break;

			default:
				Debug.Log ("Shot selection error");
				break;
			}

			loadedShot = nextShot;
			nextShot = Random.Range (1, 5);
		//	isAShotActive = true;
			gameController.shotsFired++;

			if (gameController.shotsFired >= gameController.shotsBeforeNewWave) {
				gameController.shotsFired -= gameController.shotsBeforeNewWave;
				gameController.AddNewWave ();
			}


		}
	}
}
