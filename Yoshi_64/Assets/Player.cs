using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Animator anim;
	private CharacterController controller;
	public float speed = 6.0f;
	public float turnSpeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	private int jumping = 0;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator>();
		controller = GetComponent <CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.isGrounded) {
			jumping = 0;
		}

		if (Input.GetKey ("up") || Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("down")) {
			anim.SetInteger ("AnimParam", 1);
		} else {
			anim.SetInteger ("AnimParam", 0);
		}

		if (Input.GetKey ("t")) {
			transform.position = new Vector3(72.5f, 186.2f, -49.4f);
		}
			
		if (Input.GetKeyDown ("space")) {
			jumping = 1;

		}
		if (jumping == 1) {
			transform.Translate (Vector3.up * 35 * Time.deltaTime, Space.World);
		}

		if (controller.isGrounded) {
			moveDirection = -1 * transform.forward * Input.GetAxis ("Vertical") * speed;
		}

		float turn = Input.GetAxis ("Horizontal");
		transform.Rotate (0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move (moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}
}
