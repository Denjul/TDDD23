using UnityEngine;
using System.Collections;

public class GemControl : MonoBehaviour {

	public float speed = -10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z <= -38.5) {
			Destroy (this.gameObject);
		}
		transform.Translate (0, 0, Time.deltaTime*speed);
	
	}

	void OnTriggerEnter(Collider coll){
		Destroy (this.gameObject);
	}
}
