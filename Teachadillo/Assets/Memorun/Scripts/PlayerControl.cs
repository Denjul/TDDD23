using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerControl : MonoBehaviour {

	CharacterController controller;
	public int PAM = 0;
	private int score = 0; //Game Score
	public Text scoretxt;
	private int combo = 1; //Combo
	public Text combotxt;
	public Text GameOver;
	public Text GOtext;
	public bool GO = false;
	private Queue gems = new Queue();
	public Queue portals;
	private float counter = .0f;
	public float gravity = 30.0f;

	private Rigidbody rb;
	private Animator anim;
	private CapsuleCollider col;
	private Vector3 MoveDirection = Vector3.zero;
	private Vector3 JumpDirection = Vector3.zero;
	public float speed = .5f;
	private bool isGrounded = false;
	private bool inAir = false;
	private bool Jumping = false;
	public float jumpSpeed = 150.0f;
	private float airControl = 1;

	// Use this for initialization
	void Start () {
		GameOver.text = "";
		GOtext.text = "";
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		col = GetComponent<CapsuleCollider>();
	}
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (Physics.Raycast(transform.position, -transform.up, col.height/2 + 2)){
				isGrounded = true;
				Jumping = false;
				inAir = false;
		}
		else if (!inAir){
			inAir = true;
			JumpDirection = MoveDirection;
		}
		if (counter > 4) {
					Movement();
		}

	} 

	void Movement(){
		AnimControl ();
		MoveDirection = new Vector3 ((Input.GetAxisRaw ("Horizontal")*Time.deltaTime)/13, MoveDirection.y, .003f);
		this.transform.Translate (MoveDirection);

		if (Input.GetButtonDown("Jump") && isGrounded){
			Jumping = true;    
			JumpDirection = MoveDirection;
			rb.AddForce((transform.up) * jumpSpeed);
		}
		if (isGrounded) {
			this.transform.Translate ((MoveDirection.normalized * speed) * Time.deltaTime);
		}
		else if (Jumping || inAir) {
			this.transform.Translate ((JumpDirection * speed * airControl) * Time.deltaTime);
		}
	}

	void AnimControl(){
		GetComponent<Animation> ().Play ("RUN00_F");
	}


	void setScore(){
		int temp = combo;
		if (combo > 4) {
			temp = 4;
		}
		if (gems.Count > 0) {
			temp = temp * gems.Count;
		} else {
			temp = temp * 1;
		}
		score = score + temp;
		scoretxt.text = "Score: " + score.ToString ();
		combotxt.text = "Combo: " + combo.ToString();
	}

	void GameOfLife(){
		float ypos = controller.transform.position.y;
		bool waiting = true;
		if (ypos < -1) {
			scoretxt.text = "";
			combotxt.text = "";
			resetvalues();
			//GameObject.Find("Audio Source").GetComponent<AudioSource>().Stop();
			GO = true;
			GameOver.text = "GAME OVER!";
			GOtext.text = "Jump! to play again.\r\nPress escape to exit...";
		}
	}

	void resetvalues(){
		score = 0;
		combo = 0;
		counter = 0;
		PAM = 0;
		gems.Clear();
	}

	void gpcheck(Collider coll){ //Gem and Portal check
		if (coll.gameObject.name.Equals("GemRed(Clone)")){
			CalcGem(1);
		}
		if (coll.gameObject.name.Equals("GemGreen(Clone)")) {
			CalcGem(2);
		}
		if (coll.gameObject.name.Equals("GemBlue(Clone)")) {
			CalcGem(3);
		}
		if (coll.gameObject.name.Equals("GemYellow(Clone)")) {
			CalcGem(4);
		}
		if (coll.gameObject.name.Equals("PortalRed(Clone)")) {
			CalcCombo((int)portals.Dequeue(),1);
		}
		if (coll.gameObject.name.Equals("PortalGreen(Clone)")) {
			CalcCombo((int)portals.Dequeue(),2);
		}
		if (coll.gameObject.name.Equals("PortalBlue(Clone)")) {
			CalcCombo((int)portals.Dequeue(),3);
		}
		if (coll.gameObject.name.Equals("PortalYellow(Clone)")) {
			CalcCombo((int)portals.Dequeue(),4);
		}
	}

	void CalcCombo(int temp, int cor){ //Combo counter
		if (temp == cor){
			combo++;
		}
		else{
			combo = 1;
		}
		PAM--;
	}

	void CalcGem(int temp){ //Handle gem and portal que, also count amount of gems collected.
		gems.Enqueue(temp);
		portals = new Queue(gems);
		PAM = portals.Count;
	}


	void OnTriggerEnter(Collider coll){
		gpcheck (coll);
	}
}
