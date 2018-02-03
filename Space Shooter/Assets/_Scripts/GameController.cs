using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazards;
	public Vector3 spawnValues;//to get Y & Z from Asteroid. But X should be Random & bw boundaries
	public int hazardCount;
	public float spawnWait;
	public float spawnStartAfter;
	public float waveWait;



	void Start()
	{
		//spawnWaves ();
		StartCoroutine(spawnWaves ());//waits at YIELD

	}

	//void spawnWaves() //not a Unity builtIn fn so we need to call it explicitly e.g. in Start()
	IEnumerator spawnWaves()
	{
		//wait at start of game before sending asteroids
		yield return new WaitForSeconds (spawnStartAfter);//stops exe at this pt. Aft seconds resumes from next line

		while(true)
		{
			for(int i = 0; i < hazardCount; i++)
			{
			Vector3 spawnPosition = new Vector3 
				(Random.Range(-spawnValues.x,spawnValues.x), //These will appear in Inspector for us to fill in
					spawnValues.y, //Y & Z same as Asteroid
					spawnValues.z
				); 
			
			Quaternion spawnRotation = Quaternion.identity;//=no rotation //new Quaternion();//pos is a v3 value, while rotation is a Quaternion value
			Instantiate (hazards,spawnPosition,  spawnRotation);
			
			yield return new WaitForSeconds (spawnWait);
			}//for loop ends
			yield return new WaitForSeconds(waveWait);
		}
	}
}
