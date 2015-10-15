using UnityEngine;
using System.Collections;

public class PortalsRemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.z - GameObject.Find ("unitychan").transform.position.z) < 0) {
			Destroy(this.gameObject);
		}
	}
}
