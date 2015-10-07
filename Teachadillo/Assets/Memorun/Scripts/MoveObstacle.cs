using UnityEngine;
using System.Collections;

public class MoveObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	
	// Update is called once per frame
	void Update () {
		/*if (transform.position.z <= -38.5) {
			Destroy (this.gameObject);
		}*/
		if (transform.position.y >= 0){
			transform.Translate (-transform.up *10* Time.deltaTime);
		}
	}
}
