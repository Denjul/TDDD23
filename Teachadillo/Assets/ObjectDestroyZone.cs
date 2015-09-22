using UnityEngine;
using System.Collections;
using System;

public class ObjectDestroyZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter(Collider coll){
		Destroy(coll.gameObject);
	}
}
