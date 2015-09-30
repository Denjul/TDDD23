using UnityEngine;
using System.Collections;
using System;

public class PlayerControl : MonoBehaviour {

	CharacterController controller;
	public bool isGrounded = false;
	public bool first = true;
	public float speed = 10.0f;
	public float jumpSpeed = 6.0f;
	public float gravity = 30.0f;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.isGrounded) {
			run();
		}

		if (Input.GetButton ("Jump") && isGrounded) {
			jump();
		}

		fall ();

		if (controller.isGrounded) {
			isGrounded = true;
			first = false;
		}
	}

	void run(){
		GetComponent<Animation> ().Play ("Run");
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);  //get keyboard input to move in the horizontal direction
		moveDirection = transform.TransformDirection (moveDirection);  //apply this direction to the character
		moveDirection *= speed;  //increase the speed of the movement by the factor "speed" 
	}

	void jump(){
		isGrounded = false;
		GetComponent<Animation> ().Stop ("Run");
		GetComponent<Animation> ().Play ("Jump");
		moveDirection.y = jumpSpeed;
	}

	void fall(){
		moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity  
		controller.Move (moveDirection * Time.deltaTime); 
	}

	void OnTriggerEnter(Collider coll){
	
	}
}
