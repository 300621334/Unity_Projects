using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //allows serializable
using Random = UnityEngine.Random;//there's a Random in System namespace as well

public class BoardManager : MonoBehaviour 
{
	[Serializable]
	public class Count
	{
		public int min, max;
		public Count(int min, int max)
		{
			min = min;
			max = max;
		}
	}
	public int columns = 8;
	public int rows = 8;
	public Count wallCount = new Count (5, 9);//min/max hurdle walls 
	public Count foodCount = new Count (1, 5);
	public GameObject exit;
	public GameObject[] floorTiles;//to choose from various Prefabs
	public GameObject[] foodTiles;
	public GameObject[] wallTiles;
	public GameObject[] enemyTiles;
	public GameObject[] outerWallTiles;

	private Transform boardHolder;//to be able to collapse all floor objs in hierarchy
	private List<Vector3> innerGridPos = new List<Vector3>();//to track tiles pos & see if obj has occupied them or not

	public void SetUpScene(int difficultyLevel)//public bcoz will be called by game manager
	{
		BoardSetup ();//setup floor
		initList();//setup # of cols & rows of tiles
		spawnObjs(wallTiles, wallCount.min, wallCount.max);
		spawnObjs(foodTiles, wallCount.min, wallCount.max);
		int enemyCount = Math.Log(difficultyLevel, 2f);//2, 4, 6... enemies w ea level
		spawnObjs(enemyTiles, enemyCount, enemyCount);
		Instantiate (exit, new Vector3(columns-1, rows-1, 0f), Quaternion.identity);


	}






	void initList()//set up tiles
	{
		innerGridPos.Clear ();//empty the inner-grid that will contain food & enemies

		//nested for loops to fill tiles in cols & rows
		for(int x=1;x<columns-1;x++)//zero # will be a buffer one tile wide all around the tiles we set below
		{
			for(int y=1;y<rows-1;y++)
			{
				innerGridPos.Add (new Vector3 (x,y,0f));
			}

		}
	}

	void BoardSetup()//setup floor
	{
		boardHolder = new GameObject ("Board").transform;//create obj with name "Board"
		for(int x=-1;x<columns+1;x++)//negative bcoz boarder tiles will be OUTSIDE active game area (outside zero# buffer tiles)
		{
			for(int y=-1;y<rows+1;y++)
			{
				GameObject layoutFloor = floorTiles[Random.Range(0, floorTiles.Length)];//choose floor tiles randomly
				if(x==-1||x==columns||y==-1||y==rows)//chk if extreme border then layoutFloor takes outerWallTile
				{
					layoutFloor = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
				}
				GameObject instance = Instantiate (layoutFloor, new Vector3(x,y,0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(boardHolder);
			}

		}
	}

	Vector3 RandomPosition()//to spawn objs randomly
	{
		int randomIndex = Random.Range (0, innerGridPos.Count);//choose an index upto the # of inner grid pos
		Vector3 randomPos = innerGridPos[randomIndex];
		innerGridPos.RemoveAt (randomIndex);//avoid 2 obj at same pos by removing availability of that pos
		return randomPos;
	}

	void spawnObjs(GameObject[] tileArray, int min, int max)//spawn given # of obt bw min/max
	{
		int howManyObjsToSpawn = Random.Range (min, max+1); //+1 bcoz it chooses 1 less than max
		for (int i = 0; i < howManyObjsToSpawn; i++) 
		{
			Vector3 randPos = RandomPosition ();//returns 1 pos & also removes that from available innerGridPos so that only 1 obj is spawned on that pos
			GameObject chosenTile = tileArray[Random.Range(0, tileArray.Length)];//pick 1 tile
			Instantiate(chosenTile, randPos, Quaternion.identity);
			
		}
	}


}
