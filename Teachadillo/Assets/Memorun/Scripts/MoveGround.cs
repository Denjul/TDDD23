using UnityEngine;
using System.Collections;

public class MoveGround : MonoBehaviour {

	public float speed = -.2f;
	public bool first = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("kitten").GetComponent<PlayerControl>().first) {
			if(first){
				if (transform.position.z <= -38.5) {
					first = false;
					speed = .0f;
				}
			}
		} 
		else {
			if (transform.position.z <= -38.5) {
				Destroy (this.gameObject);
			}
		}
		transform.Translate (0, 0, speed);
	}
}
