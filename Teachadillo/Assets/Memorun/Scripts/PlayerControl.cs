using UnityEngine;
using System.Collections;
using System;

public class PlayerControl : MonoBehaviour {

	CharacterController controller;
	public bool isGrounded = false;
	public int PAM = 0;
	private Queue gems = new Queue();
	private Queue portals = new Queue();
	private float counter = .0f;
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

		counter += Time.deltaTime;
		if (controller.isGrounded) {
			run();
		}

		if (Input.GetButton ("Jump") && isGrounded) {
			jump();
		}
		if (counter > 7) {
			fall ();
		}

		if (controller.isGrounded) {
			isGrounded = true;
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

	void gpcheck(Collider coll){ //Gem and Portal check
		if (coll.gameObject.name.Equals("GemRed")) {
			gems.Enqueue(1);
			portals = gems;
			print("Red");
			PAM = gems.Count;
		}
		if (coll.gameObject.name.Equals("GemGreen")) {
			gems.Enqueue(2);
			portals = gems;
			PAM = gems.Count;
		}
		if (coll.gameObject.name.Equals("GemBlue")) {
			gems.Enqueue(3);
			portals = gems;
			PAM = gems.Count;
		}
		if (coll.gameObject.name.Equals("GemYellow")) {
			gems.Enqueue(4);
			portals = gems;
			PAM = gems.Count;
		}
		if (coll.gameObject.name.Equals("PortalRed")) {
			int temp = (int)portals.Dequeue();
			if (temp == 1){
				print("Red");
			}
		}
		if (coll.gameObject.name.Equals("PortalGreen")) {
			int temp = (int)portals.Dequeue();
			if (temp == 1){
				print("Green");
			}
		}
		if (coll.gameObject.name.Equals("PortalBlue")) {
			int temp = (int)portals.Dequeue();
			if (temp == 1){
				print("Blue");
			}
		}
		if (coll.gameObject.name.Equals("PortalYellow")) {
			int temp = (int)portals.Dequeue();
			if (temp == 1){
				print("Yellow");
			}
		}
	}


	void OnTriggerEnter(Collider coll){
		gpcheck (coll);
	}
}
