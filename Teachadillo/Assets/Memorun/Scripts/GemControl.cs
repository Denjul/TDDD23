﻿using UnityEngine;
using System.Collections;

public class GemControl : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		Destroy (this.gameObject);
	}
}
