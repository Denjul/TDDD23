using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {
	// Use this for initialization
	public float speed = .2f;

	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if(!GameObject.Find("kitten").GetComponent<PlayerControl>().hurt){
			float offset = Time.time * speed;                             
			GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, -offset); 
		}
	}
}
