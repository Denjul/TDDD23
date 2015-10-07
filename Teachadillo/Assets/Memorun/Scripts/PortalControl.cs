using UnityEngine;
using System.Collections;

public class PortalControl : MonoBehaviour {
	
	public float speed = 10;
	public bool maploaded = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z <= -38.5) {
			Destroy (this.gameObject);
		}
		transform.Translate (0, Time.deltaTime*speed, 0);
	}
}

//|| GameObject.Find ("kitten").GetComponent<PlayerControl>().GO