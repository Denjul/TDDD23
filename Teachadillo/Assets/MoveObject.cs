using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	public float objectSpeed = -0.2f;
	
	void Update () {
		if (!GameObject.Find ("kitten").GetComponent<PlayerControl> ().hurt) {
			transform.Translate (0, 0, objectSpeed);
		}
	}
}


