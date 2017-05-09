using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    public Rigidbody physics;
    public float moveForce = 5.0f;
    public float crouchingMoveForce = 5.0f;
    public float jumpForce = 5.0f;

    public enum State
    {
        Walking,
        Crouching,
        Jumping
    }

    public State state = State.Walking;

	
	void FixedUpdate () {

        switch (state)
        {
            case State.Walking:
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                if (Input.GetButton("Jump"))
                {
                    physics.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    state = State.Jumping;
                }
                else if (Input.GetAxis("Vertical") < 0.0f)
                {
                    state = State.Crouching;
                }
                else
                {
                    physics.AddForce(Vector3.right * Input.GetAxis("Horizontal") * moveForce);
                }
                break;
            case State.Crouching:
                transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
                if (Input.GetAxis("Vertical") == 0.0f)
                {
                    state = State.Walking;
                }
                else
                {
                    physics.AddForce(Vector3.right * Input.GetAxis("Horizontal") * crouchingMoveForce);
                }
                break;
            case State.Jumping:
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Surface") && state == State.Jumping)
        {
            state = State.Walking;
        }
    }

}
