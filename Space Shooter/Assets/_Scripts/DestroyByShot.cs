using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByShot : MonoBehaviour {
	
	public GameObject explosion, playerExplodes;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "boundary")
		{
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);
		if(other.tag == "Player")
		{
			Instantiate (playerExplodes, other.transform.position, other.transform.rotation);
		}
		//Debug.Log (other.name); //to see which obj caused asteroid to disappear as soon as game started
		Destroy (other.gameObject); //wipe out the shot. or even player.
		Destroy (gameObject);//destroy asteroid itself
	}
}
