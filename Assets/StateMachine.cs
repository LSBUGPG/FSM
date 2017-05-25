using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
	public Walking walking;
	public Crouching crouching;
	public Jumping jumping;
	public bool touchingFloor = false;

	void Update () {
		bool crouch = Input.GetAxis ("Vertical") < 0;
		walking.enabled = !crouch && touchingFloor;
		crouching.SendMessage ("Crouch", crouch);
		crouching.enabled = crouch && touchingFloor;
		if (Input.GetButtonDown ("Jump") && crouching.enabled) {
			jumping.SendMessage("Jump");
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.CompareTag ("Surface")) {
			touchingFloor = true;
		}
	}

	void OnCollisionExit(Collision collision) {
		if (collision.collider.CompareTag ("Surface")) {
			touchingFloor = false;
		}
	}
}
