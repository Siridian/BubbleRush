using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	[SerializeField]
	private int startingBubbleLines = 3;

	[SerializeField]
	GameObject redBubble = null;
	[SerializeField]
	GameObject blueBubble = null;
	[SerializeField]
	GameObject greenBubble = null;
	[SerializeField]
	GameObject yellowBubble = null;

	private float newBubbleX = 0;
	private float newBubbleZ = 0;
	private int typeSelector = 0;

	[SerializeField]
	Text clockText = null;

	[SerializeField]
	Text victoryText = null;

	[SerializeField]
	GameObject gameOver = null;

	[SerializeField]
	GameObject victory = null;

	public bool isGameOver = false;
	public bool isGameWon = false;

	public int bubbleCount = 0;

	private int timer = 0;

	List<GameObject> existingBubbles = new List<GameObject>();

	public int shotsFired = 0;

	public int shotsBeforeNewWave = 10;

	private int waveNumber = 0;


	// Use this for initialization
	void Start () {

		for (int i = 0; i < startingBubbleLines; i++) {
			if (waveNumber % 2 == 0) {
				for (int j = 0; j < 12; j++) {
					newBubbleX = -5.5f + j;
					newBubbleZ = 7.5f- i*0.9f;
					CreateBubble (newBubbleX, newBubbleZ);
				}
			} else {

				for (int j = 0; j < 11; j++) {
					newBubbleX = -5.0f + j;
					newBubbleZ = 7.5f - i*0.9f;
					CreateBubble (newBubbleX, newBubbleZ);

				}
			}

			waveNumber++;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if(!isGameWon && !isGameOver){
		timer = (int)Time.timeSinceLevelLoad;
		clockText.text = "Time : " + timer;
			if (bubbleCount == 0) {
				victory.SetActive (true);
				isGameWon = true;
				victoryText.text = "You won in " + timer + " seconds !";
			}

		}

		if (shotsFired >= shotsBeforeNewWave) {
			shotsFired -= shotsBeforeNewWave;
			AddNewWave ();
		}
	}

	public void EndGame (){
		isGameOver = true;
		gameOver.SetActive (true);
	}

	public void AddNewWave (){
		foreach (GameObject bubble in existingBubbles) {
			if (bubble != null) {
				float currentZ = bubble.transform.position.z;
				bubble.transform.position = new Vector3 (bubble.transform.position.x, bubble.transform.position.y, currentZ - 0.9f);
			}
		}

		if (waveNumber % 2 == 0) {
			for (int j = 0; j < 12; j++) {
				newBubbleX = -5.5f + j;
				newBubbleZ = 7.5f;
				CreateBubble (newBubbleX, newBubbleZ);
			}
		} else {

			for (int j = 0; j < 11; j++) {
				newBubbleX = -5.0f + j;
				newBubbleZ = 7.5f;
				CreateBubble (newBubbleX, newBubbleZ);

			}
		}

		waveNumber++;
	}

	public void CreateBubble (float posX, float posZ){
		typeSelector = Random.Range (1, 5);
		switch (typeSelector) {

		case 1: 
			Instantiate (redBubble, new Vector3 (posX, 0, posZ), Quaternion.identity);
			bubbleCount++;
			break;

		case 2: 
			Instantiate (blueBubble, new Vector3 (posX, 0, posZ), Quaternion.identity);
			bubbleCount++;
			break;

		case 3: 
			Instantiate (greenBubble, new Vector3 (posX, 0, posZ), Quaternion.identity);
			bubbleCount++;
			break;

		case 4: 
			Instantiate (yellowBubble, new Vector3 (posX, 0, posZ), Quaternion.identity);
			bubbleCount++;
			break;

		case 5:
			break;

		default:
			Debug.Log ("Invalid Bubble Generation");
			break;
		}

	}

	public void AddToExistingBubbles (GameObject bubble){
		existingBubbles.Add (bubble);
		Debug.Log (existingBubbles.Count);
	}
}
