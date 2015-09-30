using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {

	public GameObject Ground;
	public GameObject Obstacle;
	public int[] spawnrate = new int[2]; 
	private GameObject check;
	public float groundrate = .5f;
	private float counter = .0f;
	private bool obs = false;
	/*WALLS*/
	
	//One block
	private int[] wall_1000 = new int[]{1,0,0,0};
	private int[] wall_0100 = new int[]{0,1,0,0};
	private int[] wall_0010 = new int[]{0,0,1,0};
	private int[] wall_0001 = new int[]{0,0,0,1};
	
	//Twoblocks
	private int[] wall_1100 = new int[]{1,1,0,0}; 
	private int[] wall_0110 = new int[]{0,1,1,0};
	private int[] wall_0011 = new int[]{0,0,1,1};
	private int[] wall_1010 = new int[]{1,0,1,0};
	private int[] wall_0101 = new int[]{0,1,0,1};
	private int[] wall_1001 = new int[]{1,0,0,1};
	
	//Threeblocks
	private int[] wall_1110 = new int[]{1,1,1,0};
	private int[] wall_1101 = new int[]{1,1,0,1};
	private int[] wall_1011 = new int[]{1,0,1,1};
	private int[] wall_0111 = new int[]{0,1,1,1}; 
	
	//Fourblocks
	private int[] wall_1111 = new int[]{1,1,1,1}; 
	
	//-----------------------------------------
	
	/*Holes*/
	//One block
	private int[] hole_1000 = new int[]{-1,0,0,0};
	private int[] hole_0100 = new int[]{0,-1,0,0};
	private int[] hole_0010 = new int[]{0,0,-1,0};
	private int[] hole_0001 = new int[]{0,0,0,-1};
	
	//Twoblocks
	private int[] hole_1100 = new int[]{-1,-1,0,0}; 
	private int[] hole_0110 = new int[]{0,-1,-1,0};
	private int[] hole_0011 = new int[]{0,0,-1,-1};
	private int[] hole_1010 = new int[]{-1,0,-1,0};
	private int[] hole_0101 = new int[]{0,-1,0,-1};
	private int[] hole_1001 = new int[]{-1,0,0,-1};
	
	//Threeblocks
	private int[] hole_1110 = new int[]{-1,-1,-1,0};
	private int[] hole_1101 = new int[]{-1,-1,0,-1};
	private int[] hole_1011 = new int[]{-1,0,-1,-1};
	private int[] hole_0111 = new int[]{0,-1,-1,-1}; 
	
	//Fourblocks
	private int[] hole_1111 = new int[]{-1,-1,-1,-1}; 
	
	
	/*Levels*/
	int[][] level1;
	int[][] level2;
	int[][] level3;
	int[][] level4;
	
	
	// Use this for initialization
	void Start () {
		CreateRow ();
		/*Levels*/
		level1 = new int[][] 
		{
			wall_0001,
			wall_0010,
			wall_0100,
			wall_1000,
			hole_0001,
			hole_0010,
			hole_0100,
			hole_1000
		};
		
		level2 = new int[][] 
		{
			wall_0001,
			wall_0010,
			wall_0100,
			wall_1000,
			hole_0001,
			hole_0010,
			hole_0100,
			hole_1000,
			
			wall_1100,
			wall_0110,
			wall_0011,
			wall_1010,
			wall_0101,
			wall_1001,
			wall_0110,
			hole_1100,
			hole_0110,
			hole_0011,
			hole_1010,
			hole_0101,
			hole_1001,
			hole_0110
			
		};
		level3 = new int[][] 
		{
			wall_0001,
			wall_0010,
			wall_0100,
			wall_1000,
			hole_0001,
			hole_0010,
			hole_0100,
			hole_1000,
			
			wall_1100,
			wall_0110,
			wall_0011,
			wall_1010,
			wall_0101,
			wall_1001,
			wall_0110,
			
			wall_1110,
			wall_1101,
			wall_1011,
			wall_0111,
			wall_1111,
			hole_1110,
			hole_1101,
			hole_1011,
			hole_0111,
			hole_1111
			
			
		};
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("kitten").GetComponent<PlayerControl> ().first) {
			if (check.transform.position.z <= groundrate) {
				CreateRow ();
			}	
		} 
		else {
			counter += Time.deltaTime;
			if (counter > Random.Range (1, 5)) {
				obs = true;
				counter = 0;
			}
			if (check.transform.position.z <= groundrate) {
				CreateRow ();
			}
		}
	}
		
	void CreateRow(){
		GameObject[] temp = new GameObject[]{(GameObject)Instantiate (Ground),(GameObject)Instantiate (Ground),(GameObject)Instantiate (Ground),(GameObject)Instantiate (Ground)};
		check = temp[0];
		for(int i = 0; i < temp.Length; i++){
			temp[i].transform.position = new Vector3 (i*2, 0, 40);
		}
		if (obs) {
			int obstcale = Random.Range (0,level3.Length);
			int[] i = level3[obstcale];
			for(int j = 0; j<i.Length; j++){
				temp [j].transform.position = new Vector3 (temp[j].transform.position.x,i[j] , 40);
			}
			obs = false;
		}
	}
}
