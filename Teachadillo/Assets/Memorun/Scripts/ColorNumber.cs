using UnityEngine;
using System.Collections;

public class ColorNumber : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh> ().text = "Color nr " + GameObject.Find ("kitten").GetComponent<PlayerControl> ().PAM;
	}
}
