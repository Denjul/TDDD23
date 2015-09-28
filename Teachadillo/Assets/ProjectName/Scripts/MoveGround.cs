using UnityEngine;
using System.Collections;

public class MoveGround : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, speed);
		if (transform.position.z <= -38.5) {
			Destroy (this.gameObject);
		}
	}
}
