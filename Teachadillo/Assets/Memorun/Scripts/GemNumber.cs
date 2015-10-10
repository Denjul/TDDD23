using UnityEngine;
using System.Collections;

public class GemNumber : MonoBehaviour {
	// Use this for initialization
	void Start () {
		int i = GameObject.Find ("unitychan").GetComponent<PlayerControl> ().PAM;
		i++;
		GetComponent<TextMesh> ().text = "Remember this! Color nr " + i;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
