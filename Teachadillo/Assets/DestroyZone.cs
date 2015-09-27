using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		DestroyObject (coll.gameObject);
	}

}
