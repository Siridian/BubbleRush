using UnityEngine;
using System.Collections;

public class GameEnder : MonoBehaviour {

	[SerializeField]
	GameController gameController;

	//Le principe est de déclencher le game over si une bulle immobile (et non un tir) atteint le seuil
	//Dans cet état, le game over ne se déclenche jamais
	//En retirant la condition, le game over se déclenche correctement, y compris lorsque les tirs traversent le seuil


	void OnTriggerEnter (Collider other)
	{
		if (other.tag != "Shot") {
			gameController.EndGame ();
			Debug.Log ("Touché");
		}
	}
}
