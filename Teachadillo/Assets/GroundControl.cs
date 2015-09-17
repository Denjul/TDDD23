using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		float speed = .5f;
		float offset = Time.time * speed;                             
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset); 
	}
}
