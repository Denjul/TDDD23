using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {
	// Use this for initialization
	void Start () {
		int i = Random.Range (0, 1000);
		transform.Rotate (Vector3.forward * i);
	}
		void Update() {
			transform.Rotate(Vector3.forward * Time.deltaTime*80);
		}
	}
