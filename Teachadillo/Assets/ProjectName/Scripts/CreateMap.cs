using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {

	public GameObject Ground;
	public GameObject Obstacle;
	public int[] spawnrate = new int[2]; 
	private GameObject check;
	public float groundrate = .5f;
	private float counter = .0f;

	// Use this for initialization
	void Start () {
		CreateRow ();
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
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
	}
}
