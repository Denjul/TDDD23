using UnityEngine;
using System.Collections;

public class EnviormentMove : MonoBehaviour {
	//GameObject kitten;
	// Use this for initialization
	public int distance= 3;
	void Start () {
		//kitten = GameObject.Find ("kitten");
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Tr(0,0,GameObject.Find("kitten").transform.position.z - 3);
		//transform.Translate (0, 0,GameObject.Find ("kitten").transform.position.z -3 , Space.World);
		//transform.position.z = GameObject.Find ("kitten").transform.position.z - 3;
		transform.position = new Vector3(transform.position.x, transform.position.y, GameObject.Find ("unitychan").transform.position.z - distance);

			
	
	
}
}
