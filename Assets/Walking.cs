using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {
	public Rigidbody physics;
	public float moveForce = 10.0f;

	void FixedUpdate() {
		physics.AddForce(Vector3.right * Input.GetAxis("Horizontal") * moveForce);
	}
}
