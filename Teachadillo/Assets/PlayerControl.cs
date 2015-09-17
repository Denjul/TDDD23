using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	CharacterController controller;
	bool isGrounded= false;
	public float vert = Input.GetAxis("Vertical")+10;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.isGrounded) {
			GetComponent<Animation>().Play("Run");
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), vert, 0);  //get keyboard input to move in the horizontal direction
			moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
			moveDirection *= speed;            //increase the speed of the movement by the factor "speed" 
		}

		if (Input.GetButton ("Jump")) {
			GetComponent<Animation>().Stop("Run");
			GetComponent<Animation>().Play("Jump");
			moveDirection.y = jumpSpeed;
		}
		if (controller.isGrounded) {
			isGrounded = true;
		}
		moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity  
		controller.Move(moveDirection * Time.deltaTime); 
	}
}
