using UnityEngine;
using System.Collections;
using System.Linq;

public class CreateMap : MonoBehaviour {
	
	public GameObject Ground;
	public GameObject Obstacle;
	public GameObject[] Portals = new GameObject[4];
	public GameObject[] Gems = new GameObject[4];
	public int[] spawnrate = new int[2]; 
	private GameObject check;
	public float groundrate = .18f;
	private float counter = .0f;
	private float counter2 = .0f;
	private float counter3 = .0f;
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
	
	public int mode = 1;
	private int counterOfGround = 0;
	public int nrOfGround = 4;
	
	//Case 4
	private bool cube = true;
	public int nrOfCubesCase4 = 2;
	int[] lastCube = new int[]{-1,-1,0,-1};
	
	//Case 5
	int[] doubleCube = new int[]{-1,-1,0,0};
	private int counterDoubleCubes = 0;
	
	
	/*Levels*/
	int[][] level1;
	int[][] level2;
	int[][] level3;
	int[][] level4;
	int[][] wallslevel;
	int[][] holelevel;
	
	
	// Use this for initialization
	void Start () {
		CreateGroundRow();
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
			hole_1110,
			hole_1101,
			hole_1011,
			hole_0111,
			hole_1111
			
			
		};
		
		wallslevel = new int[][] 
		{
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
			
		};
		holelevel = new int[][] 
		{
			hole_0001,
			hole_0010,
			hole_0100,
			hole_1000,
			hole_1100,
			hole_0110,
			hole_0011,
			hole_1010,
			hole_0101,
			hole_1001,
			hole_0110
		};
		
		
	}
	
	// Update is called once per frame
	void Update () {
		counter2 += Time.deltaTime;
		counter3 += Time.deltaTime;
		if ((counter2 < 7)) {
			if(counter3 >= groundrate){
				CreateGroundRow();
				counter3 = 0;
			}
		} else {
			counter += Time.deltaTime;
			if (counter >= groundrate) {
				switch (mode)
				{
				case 1:
					if (counter > Random.Range (1, 5)) {
						int i = Random.Range (0,level3.Length);
						int[] obstacle = level3[i];
						CreateRow(obstacle);
						counter = 0;
					}else{
						CreateGroundRow();
						counter = 0;
					}
					break;
				case 2:
					if(counterOfGround >= nrOfGround){
						int i = Random.Range (0,wallslevel.Length);
						int[] obstacle = wallslevel[i];
						CreateRow(obstacle);
						counterOfGround = 0;
						counter = 0;
					}else{
						counterOfGround++;
						CreateGroundRow();
						counter = 0;
					}
					break;
				case 3:
					int k = Random.Range (0,holelevel.Length);
					int[] obstacle1 = holelevel[k];
					CreateRow(obstacle1);
					counterOfGround = 0;
					counter = 0;
					break;
				case 4:
					if (cube){
						if(nrOfCubesCase4>=1){
							nrOfCubesCase4 = 0;
							if (Enumerable.SequenceEqual(lastCube, hole_0111)){
								print("hej1");
								lastCube[0] = -1;
								lastCube[1] = 0;
							}else if(Enumerable.SequenceEqual(lastCube, hole_1110)){
								print("hej2");
								lastCube[3] = -1;
								lastCube[2] = 0;
							}else{
								print("hej3");	
								for(int i = 1; i <3; i++){
									if (lastCube[i] == 0){
										print("hej4");
										lastCube[i] = -1;
										int l = i+Random.Range(0,3) - 1;
										//print(l);
										lastCube[l]= 0;
									}
								}
							}
						}else{
							nrOfCubesCase4++;
							cube = false;
						}
						
						CreateRow(lastCube);
					}else{
						CreateRow(hole_1111);
						cube = true;
					}
					counter = 0;
					
					
					break;
				case 5:
					counterDoubleCubes++;
					switch (counterDoubleCubes)
					{
					case 1:
						CreateRow(hole_1100);
						break;
					case 2:
						CreateRow(hole_1001);
						break;
					case 3:
						CreateRow(hole_0011);
						break;
					case 4:
						CreateRow(hole_1001);
						counterDoubleCubes = 0;
						break;
					default:
						
						break;
					}
					break;
						
					
					/*	if (nrOfDoubleCubes >= 2){
						if((Enumerable.SequenceEqual(lastdoubleCube, hole_0011)) || 
						   (Enumerable.SequenceEqual(lastdoubleCube, hole_1100))){
							lastdoubleCube = new int[]{-1,0,0,-1};
						}else{
							if(Random.Range(0,2) == 1){
								lastdoubleCube = new int[]{0,0,-1,-1};
							}else{
								lastdoubleCube = new int[]{-1,-1,0,0};
							}
						}
						nrOfDoubleCubes = 0;
					}else{
						nrOfDoubleCubes++;
					}
					CreateRow(lastdoubleCube);
					counter = 0;*/

					case 6:
						if(counterOfGround > Random.Range(5,10)){
							CreatePortals();
							counterOfGround = 0;
						}
						else{
							CreateGroundRow();
							counterOfGround++;
						}
						counter = 0;
						
						break;
						
				default:
					
					break;
				}
			}
		}
	}
	
	void CreateRow(int[] obstacle){
		GameObject[] temp = new GameObject[4];
		for (int j = 0; j<obstacle.Length; j++) {
			if (obstacle[j] != -1) {
				if (obstacle [j] != 0) {
					temp [j] = (GameObject)Instantiate (Obstacle);
				} else {
					temp [j] = (GameObject)Instantiate (Ground);
				}
				temp [j].transform.position = new Vector3 (j * 2, obstacle [j], 40);
			}
		}
	}
	/*
	void CreateRow(int[] i){
		GameObject[] temp = new GameObject[]{(GameObject)Instantiate(Ground),(GameObject)Instantiate(Ground),(GameObject)Instantiate(Ground),(GameObject)Instantiate(Ground)};
		if (obs) {
			int obstcale = Random.Range (0,level3.Length);
			int[] i = level3[obstcale];
			for(int j = 0; j<i.Length; j++){
				if(i[j] != 0){
					temp[j] = (GameObject)Instantiate(Obstacle);
				}
				else{
					temp[j] = (GameObject)Instantiate(Ground);
				}
				temp [j].transform.position = new Vector3 (temp[j].transform.position.x,i[j] , 40);
			}
			obs = false;
		}
		check = temp[0];
		for(int i = 0; i < temp.Length; i++){
			temp[i].transform.position = new Vector3 (i*2, temp[i].transform.position.y, 40);
		}
	}*/
	
	void CreateGroundRow(){
		GameObject[] temp = new GameObject[]{(GameObject)Instantiate(Ground),(GameObject)Instantiate(Ground),(GameObject)Instantiate(Ground),(GameObject)Instantiate(Ground)};
		for(int i = 0; i < temp.Length; i++){
			temp[i].transform.position = new Vector3 (i*2, temp[i].transform.position.y, 40);
		}
	}

	void CreatePortals(){
		GameObject[] temp = new GameObject[]{(GameObject)Instantiate(Portals[0]),(GameObject)Instantiate(Portals[1]),(GameObject)Instantiate(Portals[2]),(GameObject)Instantiate(Portals[3])};
		for(int i = 0; i < temp.Length; i++){
			temp[i].transform.position = new Vector3 (temp[i].transform.position.x, temp[i].transform.position.y, 40);
		}
	}
	
}
