using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerControl : MonoBehaviour {

	CharacterController controller;
	public int PAM = 0;					//Portals Amount Counter
	private int score = 0;				//Game Score Text
	public Text scoretxt; 				//Score text
	private int combo = 1;				//Combo Counter
	public Text combotxt;				//Combo text
	public Text GameOver;				//GameOver text (GameOver)
	public Text GOtext;					//GameOver text (Press space to continue etc)
	public Text Countdown;				//Countdown text for beginning for game.
	public bool GO = false;				//GameOver
	private bool start = false;			//Starts game when ready
	private Queue gems = new Queue();	//Que for holding gems, keeping track of order
	public Queue portals;				//Que for checking if the right portals are being passed in the game
	private float counter = .0f;		//Counter for gametime

	private Rigidbody rb;				//Rigidbody component
	private Animator anim;				//Animator component
	private CapsuleCollider col;		//Capsule collider component
	private Vector3 MoveDirection;		//Vector for moving
	public float speed = .3f;			//Controller for speed
	private bool isGrounded = false;	//Checks if character is grounded
	private bool inAir = false;			//Checks if character is in Air
	private bool Jumping = false;		//Checks if character is jumping
	private float jumpSpeed = 200.0f;

	// Use this for initialization
	void Start () {
		GameOver.text = "";								//Resets text
		GOtext.text = "";								//Resets text
		Countdown.text = "Ready?";
		MoveDirection = Vector3.zero;					//Initiates moving Vector
		rb = GetComponent<Rigidbody>();					//Gathers rigidbody component from character
		anim = GetComponent<Animator>();				//Gathers Animator component from character
		col = GetComponent<CapsuleCollider>();			//Gathers Capsule collider component from character
		Physics.gravity = new Vector3 (0,-15.25f,0);	//Sets gravity
		setScore (0);
	}

	// Update is called once per frame
	void Update () {
		starting ();
		GameOfLife ();
		if (Physics.Raycast(transform.position, -transform.up, col.height/2)){
				isGrounded = true;
				Jumping = false;
				inAir = false;
		}
		else if (!inAir){
			inAir = true;
			isGrounded = false;
		}
		if (start && !GO) {
			//setScore ();

			Movement ();
		} else {
			if(Input.GetButtonDown("Jump")){
				Application.LoadLevel(Application.loadedLevel);
			}
		}

	} 

	//Starting function, when the game is initiated (Character stands still etc)
	void starting(){
		if (counter < 4.2f) {
			if(counter >= 1.2f){
				if((5-(int)counter)> 1){
					Countdown.text = (4-(int)counter).ToString();
				}
				else{
					Countdown.text = "GO!";
				}
			}
			counter += Time.deltaTime;
		} else {
			anim.SetBool ("Start", true);
			Countdown.text = "";
			start = true;
		}
	}

	void Movement(){
		MoveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal")/4500, MoveDirection.y, .0005f);
		anim.SetInteger("RunDir",(int)Input.GetAxisRaw ("Horizontal")); 
		this.transform.Translate (MoveDirection);

		if (Input.GetButtonDown("Jump") && isGrounded){
			Jumping = true;  
			rb.AddForce((transform.up) * jumpSpeed);
		}
		if (isGrounded) {
			this.transform.Translate ((MoveDirection.normalized * speed) * Time.deltaTime);
			anim.SetBool ("Jump", false);
		}
		else if (Jumping || inAir) {
			this.transform.Translate ((MoveDirection.normalized * speed) * Time.deltaTime);
			anim.SetBool ("Jump", true);
		}
	}

	void setScore(int coin){
		/*int temp = combo;
		if (combo > 4) {
			temp = 4;
		}
		if (gems.Count > 0) {
			temp = temp * gems.Count;
		} else {
			temp = temp * 1;
		}*/
		score = score + coin;
		scoretxt.text = "Score: " + score.ToString ();
		combotxt.text = "Combo: " + combo.ToString();
	}

	void GameOfLife(){
		float ypos = transform.position.y;
		bool waiting = true;
		if (ypos < -1) {
			scoretxt.text = "";
			combotxt.text = "";
			resetvalues();
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
		if (coll.gameObject.name.Equals("Coin(Clone)")) {
			setScore(100);
		}
	}

	void CalcCombo(int temp, int cor){ //Combo counter
		if (temp == cor){
			combo++;
		}
		else{
			combo = 1;
		}
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
