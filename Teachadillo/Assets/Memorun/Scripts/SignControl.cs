using UnityEngine;
using System.Collections;

public class SignControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs((transform.position.z - GameObject.Find("unitychan").transform.position.z)) < 30) {
			transform.position = new Vector3(transform.position.x, transform.position.y + .01f,transform.position.z);
		}
	}
}
