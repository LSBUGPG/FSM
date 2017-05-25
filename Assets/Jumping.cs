using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {
	public Rigidbody physics;
	public float force = 5.0f;

	void Jump() {
		physics.AddForce(Vector3.up * force, ForceMode.Impulse);
	}
}
