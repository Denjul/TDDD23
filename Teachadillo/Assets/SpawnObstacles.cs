using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {
	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public float obsspeed;
	float timeElapsed = 0;
	float obsh = 0;
	float randomspawn = (float)0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameObject.Find ("kitten").GetComponent<PlayerControl> ().hurt) {
			timeElapsed += Time.deltaTime;
			GameObject temp;
			if ((int)timeElapsed > randomspawn) {
				timeElapsed = (float)0;
				randomspawn = (float)Random.Range (1, 3);
				obsh = (float)0.5;
				temp = (GameObject)Instantiate (prefab1);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3 (Random.Range (-4, 6) - (float)0.3, pos.y + obsh, 35);
			}
		}
		/*for (int k = 0; k < obstacle.Length && obstacle[k] != null; k++) {
			obstacle[k].transform.position = new Vector3(obstacle[k].transform.position.x,obstacle[k].transform.position.y,obstacle[k].transform.position.z - obsspeed);
		}*/
	}
}
