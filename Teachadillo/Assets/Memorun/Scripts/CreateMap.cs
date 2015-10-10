using UnityEngine;
using System.Collections;
using System.Linq;

public class CreateMap : MonoBehaviour
{
	
	public GameObject Ground;
	public GameObject Obstacle;
	public GameObject[] Portals = new GameObject[4];
	public GameObject[] Gems = new GameObject[4];
	public GameObject SignGems;
	public GameObject SignPortals;
	public GameObject SignCoins;
	public GameObject Coin;
	public int[] spawnrate = new int[2];
	public int obsMode = 2;
	private GameObject check;
	public float groundrate = 70;
	private float counter = .0f;
	private float counter2 = .0f;
	private float counter3 = .0f;
	private int portalscount = 0;
	private bool firstgem = true;
	private bool obs = false;
	private int mode = 2;
	private int groundrowcounter = 0;
	private float time = .0f;
	private GameObject[] lastRow = new GameObject[4];
	private bool newMiddlelevel = true;
	private int zPos = -30;
	private bool holes = false;
	private int PAM = 0;
	public int PAMinverted = 0;
	
	
	//case6
	private int case6Mode = 1;
	private bool firstRow = true;
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
	private int counterOfGround = 0;
	public int nrOfGround = 4;
	
	//Case 4
	private bool cube = true;
	public int nrOfCubesCase4 = 0;
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
	void Start ()
	{	
		for (int i = 0; i<50; i++) {
			CreateGroundRow ();
			if(i == 38){
				CreateGems();
			}
		}
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
	void Update ()
	{
		counter2 += Time.deltaTime;
		time += Time.deltaTime;
		//A starting phase that creates the ground when the unitychan is in the air
		if ((counter2 < 7)) {
			/*if (counter3 >= groundrate) {
				lastRow = CreateGroundRow ();
				counter3 = 0;
				counter = counter2;
			}*/
		} else { // Now in the game loop
			counter += Time.deltaTime;
			//Checks if it is time to create a new row
			if (zPos - GameObject.Find ("unitychan").transform.position.z  < groundrate ) {
				//lastRow = CreateGroundRow();
				counter = 0;




				switch (mode) {
				case 1:
					//choose color
					groundrowcounter++;
					CreateGroundRow ();
					if (groundrowcounter == 10) {
						CreateGems ();
					} else if (groundrowcounter >= 20) {
						
						mode = 2;
						groundrowcounter = 0;
					}
					
					break;
				case 2:

					//Diffrent obsacalelevel
					groundrowcounter++;
					Obstacalelevel (obsMode);
					if (groundrowcounter >= 35) {
						mode = 3;
						PAM = GameObject.Find ("unitychan").GetComponent<PlayerControl> ().PAM;
						obsMode++;
						newMiddlelevel = true;
						if (obsMode >8){
							obsMode = 2;
						}
						
						groundrowcounter = 0;
					}

					break;
				case 3:
		
					//Portal mode
					groundrowcounter++;
					CreateGroundRow ();
					if (PAM == 0) {
						groundrowcounter = 0;
						mode = 4;
						PAMinverted = 0;
					} else {
						if (groundrowcounter == 10) {
							PAMinverted++;
							CreatePortals ();
							PAM--;
							groundrowcounter = 0;
						} 
						
					}
					
					break;
				case 4:
					groundrowcounter++;
					CreateGroundRow ();
					if (groundrowcounter == 10) {
						CreateCoinSign();
					}else if (groundrowcounter > 10 && groundrowcounter< 30) {
						CreateCoins();
					}
					else if (groundrowcounter >= 35) {
						mode = 1;
						groundrowcounter = 0;
					}

					break;
				default:
					
					break;
				}

			/*	switch (mode) {
				case 1:
					//choose color
					groundrowcounter++;
					CreateGroundRow ();
					if (groundrowcounter == 10) {
						CreateGems ();
					} else if (groundrowcounter >= 20) {

						mode = 3;
						groundrowcounter = 0;
					}

					break;
				case 2:
					//Portal mode
					groundrowcounter++;
					CreateGroundRow ();
					if (PAM == 0) {
						groundrowcounter = 0;
						mode = 1;
						PAMinverted = 0;
					} else {
						if (groundrowcounter == 10) {
							PAMinverted++;
							CreatePortals ();
							PAM--;
							groundrowcounter = 0;
						} 

					}
					break;
				case 3:
					//Diffrent obsacalelevel
					groundrowcounter++;
					Obstacalelevel (1);
					//Obstacalelevel (obsMode);
					if (groundrowcounter >= 35) {
						mode = 2;
						PAM = GameObject.Find ("unitychan").GetComponent<PlayerControl> ().PAM;
						obsMode++;
						newMiddlelevel = true;
						if (obsMode >8){
							obsMode = 1;
						}

						groundrowcounter = 0;
					}

					
					break;
				default:
					
					break;
				}*/
			}
		}
	}
	
	void Obstacalelevel (int level)
	{
			
		switch (level) {
		case 1:
			//GroundRows
			CreateGroundRow ();
			break;
		case 2:
			//Level with only walls no holes
			if (counterOfGround >= nrOfGround) {
				int i = Random.Range (0, wallslevel.Length);
				int[] obstacle = wallslevel [i];
				CreateRow (obstacle);
				counterOfGround = 0;
			} else {
				counterOfGround++;
				CreateGroundRow ();
			}
			break;
		case 3:
			//Level with only walls no holes
			if (counterOfGround >= 2) {
				if(holes){
					int i = Random.Range (0, wallslevel.Length);
					int[] obstacle = wallslevel [i];
					CreateRow (obstacle);
					counterOfGround = 0;
					holes = false;
				}else{
					int i = Random.Range (0, holelevel.Length);
					int[] obstacle = holelevel [i];
					CreateRow (obstacle);
					counterOfGround = 0;
					holes = true;
				}
			} else {
				counterOfGround++;
				CreateGroundRow ();
			}
			break;
		case 4:
			//level that makes a oneblock path
			if (newMiddlelevel){
				lastCube = new int[]{-1,-1,0,-1};
				case6Mode = 1;
				newMiddlelevel = false;
				counterOfGround = 0;
				firstRow = true;
			}
			counterOfGround++;
			if (counterOfGround >= 4){
				counterOfGround = 0;
				int[] firstRowGround = new int[]{-1,-1,-1,-1};
				if(case6Mode == 1){
					firstRowGround = new int[]{0,0,-1,-1};
					case6Mode = 2;
				}else if(case6Mode == 2){
					firstRowGround = new int[]{-1,0,-1,-1};
					int l = 1 + Random.Range (0, 3) - 1;
					firstRowGround[l]= 0;
					case6Mode = l + 1;
				}else if(case6Mode == 3){
					firstRowGround = new int[]{-1,-1,0,-1};
					int l = 2 + Random.Range (0, 3) - 1;
					firstRowGround[l]= 0;
					case6Mode = l + 1;
				}else if(case6Mode == 4){
					firstRowGround = new int[]{-1,-1,0,0};
					case6Mode = 3;
				}
				CreateRow(firstRowGround);
				firstRow = true;
			}
			if(firstRow){
				firstRow = false;
			}else{
				switch (case6Mode) {
				case 1:
					CreateRow (hole_0111);
					break;
				case 2:
					CreateRow (hole_1011);
					break;
				case 3:
					CreateRow (hole_1101);
					break;
				case 4:
					CreateRow (hole_1110);
					break;
				default:
					
					break;
				}
			}

			break;
		case 5:
			//double block then hole then double block
			if (newMiddlelevel){
				lastCube = new int[]{-1,-1,0,-1};
				newMiddlelevel = false;
				nrOfCubesCase4 = 0;
				print ("newMiddlelevel");
				//cube = true;
			}
			if (cube) {
				if (nrOfCubesCase4 == 0) {
					nrOfCubesCase4++;
					print (lastCube);
					if (Enumerable.SequenceEqual (lastCube, hole_0111)) {
						lastCube [0] = -1;
						lastCube [1] = 0;
					} else if (Enumerable.SequenceEqual (lastCube, hole_1110)) {
						lastCube [3] = -1;
						lastCube [2] = 0;
					} else {	
						for (int i = 1; i <= 2; i++) {
							if (lastCube [i] == 0) {
								lastCube [i] = -1;
								int l;
								int rnd = Random.Range (0, 2);
								print ("rnd: "+ rnd);
								if(rnd == 0 && i == 1){
									l = 0;
								}else if(rnd == 1 && i == 1){
									l = 2;
								}else if(rnd == 0 && i == 2){
									l = 1;
								}else if(rnd == 1 && i == 2){
									l = 3;
								}else{
									print ("ska inte vara här");
									l= 1;
								}
								print (l);
								print (i+","+l);
								//print(l);
								lastCube [l] = 0;
								break;
							}
						}
					}
				} else if (nrOfCubesCase4 == 1) {
					nrOfCubesCase4++;
					cube = false;

				}else{
					print("BORDE INTE VARA HÄR");
				}
				
				CreateRow (lastCube);
			} else {
				nrOfCubesCase4 = 0;
				CreateRow (hole_1111);
				cube = true;
			}
			
			
			break;
		case 6:
			//Random holes
			int k = Random.Range (0, holelevel.Length);
			int[] obstacle1 = holelevel [k];
			CreateRow (obstacle1);
			counterOfGround = 0;
			counterDoubleCubes++;

			break;
		case 7:
			switch (counterDoubleCubes) {
			case 1:
				CreateRow (hole_1100);
				break;
			case 2:
				CreateRow (hole_1001);
				break;
			case 3:
				CreateRow (hole_0011);
				break;
			case 4:
				CreateRow (hole_1001);
				counterDoubleCubes = 0;
				break;
			default:
				
				break;
			}
			break;
		case 8:

			break;
		case 9:
			switch (counterDoubleCubes) {
			case 1:
				CreateRow (hole_1100);
				break;
			case 2:
				CreateRow (hole_1001);
				break;
			case 3:
				CreateRow (hole_0011);
				break;
			case 4:
				CreateRow (hole_1001);
				counterDoubleCubes = 0;
				break;
			default:
				
				break;
			}
			break;
		case 10:
			if (counter > Random.Range (1, 5)) {
				int i = Random.Range (0, level3.Length);
				int[] obstacle = level3 [i];
				CreateRow (obstacle);
			} else {
				CreateGroundRow ();
			}
			break;
			
			
		default:
			
			break;
		}
		
	}
	
	/*void CreateRow (int[] obstacle)
	{
		zPos = zPos + 2;
		print (zPos);
		for (int j = 0; j<obstacle.Length; j++) {
			
			if (obstacle [j] == -1) {
				Destroy(lastRow[j]);
			}else if (obstacle [j] == 1) {
				float tempPos = lastRow[j].transform.position.z;
				Destroy(lastRow[j]);
				GameObject temp = (GameObject)Instantiate (Obstacle);
				temp.transform.position = new Vector3 (j * 2, obstacle [j], zPos);
				
			}
		}
	}*/
	
	void CreateRow (int[] obstacle)
	{
		GameObject[] temp = new GameObject[4];
		zPos = zPos + 2;
		for (int j = 0; j<obstacle.Length; j++) {
			if (obstacle [j] != -1) {
				if (obstacle [j] != 0) {
					temp [j] = (GameObject)Instantiate (Obstacle);
				} else {
					temp [j] = (GameObject)Instantiate (Ground);
				}
				temp [j].transform.position = new Vector3 (j * 2, obstacle [j], zPos);
			}
		}
	}
	
	public GameObject[] CreateGroundRow()
	{
		GameObject[] temp = new GameObject[] {
			(GameObject)Instantiate (Ground),
			(GameObject)Instantiate (Ground),
			(GameObject)Instantiate (Ground),
			(GameObject)Instantiate (Ground)
		};
		zPos = zPos + 2;
		for (int i = 0; i < temp.Length; i++) {
			temp [i].transform.position = new Vector3 (i * 2, temp [i].transform.position.y, zPos);
		}
		return temp;
		
	}
	
	void CreatePortals ()
	{
		GameObject[] temp = new GameObject[] {
			(GameObject)Instantiate (Portals [0]),
			(GameObject)Instantiate (Portals [1]),
			(GameObject)Instantiate (Portals [2]),
			(GameObject)Instantiate (Portals [3])
		};
		for (int i = 0; i < temp.Length; i++) {
			temp [i].transform.position = new Vector3 (i * 2, temp [i].transform.position.y, zPos);
		}
		//GameObject.Find ("unitychan").GetComponent<PlayerControl> ().PAM
		GameObject sign = new GameObject();
		sign = (GameObject)Instantiate (SignPortals);
		sign.transform.position = new Vector3 (sign.transform.position.x,sign.transform.position.y, zPos);
		
	}
	
	void CreateGems ()
	{
		GameObject[] temp = new GameObject[] {
			(GameObject)Instantiate (Gems [0]),
			(GameObject)Instantiate (Gems [1]),
			(GameObject)Instantiate (Gems [2]),
			(GameObject)Instantiate (Gems [3])
		};
		for (int i = 0; i < temp.Length; i++) {
			temp [i].transform.position = new Vector3 (i * 2, temp [i].transform.position.y, zPos);
		}
		GameObject sign = new GameObject();
		sign = (GameObject)Instantiate (SignGems);
		sign.transform.position = new Vector3 (sign.transform.position.x,sign.transform.position.y, zPos);

		//GameObject sign = new GameObject();
		//sign = (GameObject)Instantiate (SignGems);
		//sign.transform.position = new Vector3 (sign.transform.position.x,sign.transform.position.y, zPos);

	}

	void CreateCoins ()
	{
		GameObject[] temp = new GameObject[] {
			(GameObject)Instantiate (Coin),
			(GameObject)Instantiate (Coin),
			(GameObject)Instantiate (Coin),
			(GameObject)Instantiate (Coin)
		};
		for (int i = 0; i < temp.Length; i++) {
			int rand = Random.Range (0, 4);
			if (rand == 0) {
				temp [i].transform.position = new Vector3 (i * 2, temp [i].transform.position.y, zPos);
			} else if (rand == 1) {
				temp [i].transform.position = new Vector3 (i * 2, 2, zPos);
			} else {
				Destroy (temp [i]);
			}
		}

		
	}

	void CreateCoinSign(){
		GameObject sign = new GameObject();
		sign = (GameObject)Instantiate (SignCoins);
		sign.transform.position = new Vector3 (sign.transform.position.x,sign.transform.position.y, zPos);
	}

	
}
