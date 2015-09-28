using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {

	public GameObject Ground;
	public GameObject Obstacle;
	public int[] spawnrate = new int[2]; 
	private GameObject check;
	public float groundrate = .5f;
	private float counter = .0f;
	private bool hole = false;
	private bool obs = false;

	// Use this for initialization
	void Start () {
		CreateRow ();
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > Random.Range (1, 5)) {
			obs = true;
			counter = 0;
		}
		if (counter > Random.Range (1, 5)) {
			hole = true;
			counter = 0;
		}
		if (check.transform.position.z <= groundrate) {
			CreateRow ();
		}
	}
		
	void CreateRow(){
		GameObject[] temp = new GameObject[]{(GameObject)Instantiate (Ground),(GameObject)Instantiate (Ground),(GameObject)Instantiate (Ground),(GameObject)Instantiate (Ground)};
		check = temp[0];
		for(int i = 0; i < temp.Length; i++){
			temp[i].transform.position = new Vector3 (i*2, 0, 40);
		}
		if(hole){
			int i = Random.Range (0,4);
			temp[i].transform.position = new Vector3 (temp[i].transform.position.x, -20, 40);
			hole = false;
		}
		if (obs) {
			int i = Random.Range (0,4);
			temp [i].transform.position = new Vector3 (temp[i].transform.position.x, 1, 40);	
			obs = false;
		}
	}
}
