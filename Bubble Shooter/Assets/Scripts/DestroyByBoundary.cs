using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {


	[SerializeField]
	Shooter shooter;

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
		shooter.isAShotActive = false;
	}
}
