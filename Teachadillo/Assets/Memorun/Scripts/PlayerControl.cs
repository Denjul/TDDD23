using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerControl : MonoBehaviour {

	CharacterController controller;
	public bool isGrounded = false;
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
	public float speed = 10.0f;
	public float jumpSpeed = 6.0f;
	public float gravity = 30.0f;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		GameOver.text = "";
		GOtext.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		GameOfLife ();
		setScore ();
		counter += Time.deltaTime;
		if (controller.isGrounded) {
			run();
		}

		if (Input.GetButton ("Jump") && isGrounded) {
			if(GameOver.text.Equals("GAME OVER!")){
				GameOver.text = "";
				print("RESTART");
				Application.LoadLevel(Application.loadedLevel);
				GO = false;
			}
			else{
				jump();
			}
		}
		if (counter > 14) {
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
