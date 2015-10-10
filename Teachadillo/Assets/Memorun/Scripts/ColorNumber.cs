using UnityEngine;
using System.Collections;

public class ColorNumber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh> ().text = "What's color nr " + GameObject.Find ("SpawnMap").GetComponent<CreateMap> ().PAMinverted + "?";
	}
	
	// Update is called once per frame
	void Update () {

	}
}
