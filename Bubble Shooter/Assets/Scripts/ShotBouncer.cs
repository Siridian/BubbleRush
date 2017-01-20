using UnityEngine;
using System.Collections;

public class ShotBouncer : MonoBehaviour {

	void OnTriggerEnter(Collider other){

		other.attachedRigidbody.velocity = Vector3.Reflect (other.attachedRigidbody.velocity, Vector3.right);

	}
}