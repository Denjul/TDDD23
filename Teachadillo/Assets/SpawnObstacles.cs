using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {
	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public float obsspeed;
	GameObject[] obstacle = new GameObject[10];
	float timeElapsed = 0;
	float obsh = 0;
	float randomspawn = (float)0;
	int i = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		if ((int)timeElapsed == randomspawn) {
			timeElapsed = (float)0;
			randomspawn = (float)Random.Range(1,3);
			if(obstacle[i] == null){
				obsh = (float)0.5;
				obstacle[i] = (GameObject)Instantiate(prefab1);
			}
			else{
				obsh = 0;
			}
			Vector3 pos = obstacle[i].transform.position;
			obstacle[i].transform.position = new Vector3(Random.Range(-4, 6)-(float)0.3, pos.y + obsh , 35);
			i = (i + 1) % 10;
		}
		for (int k = 0; k < obstacle.Length && obstacle[k] != null; k++) {
			obstacle[k].transform.position = new Vector3(obstacle[k].transform.position.x,obstacle[k].transform.position.y,obstacle[k].transform.position.z - obsspeed);
		}
	}
}
