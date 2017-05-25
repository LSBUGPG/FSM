using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour {
	public Rigidbody physics;
	public float moveForce = 5.0f;

	public void Crouch(bool crouching){
		Debug.Log (crouching);
		transform.localScale = new Vector3(1.0f, crouching? 0.8f : 1.0f, 1.0f);
	}

	void FixedUpdate() {
		physics.AddForce(Vector3.right * Input.GetAxis("Horizontal") * moveForce);
	}
}
