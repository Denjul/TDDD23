using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {
	public GameObject obstacle;
	float timeElapsed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
	if ((int)timeElapsed == 1) {
			timeElapsed = 0;
			GameObject temp = (GameObject)Instantiate(obstacle);
			Vector3 pos = temp.transform.position;
			temp.transform.position = new Vector3(Random.Range(-4, 6)-(float)0.3, pos.y + (float)0.5 , pos.z);
		}
	}
}
