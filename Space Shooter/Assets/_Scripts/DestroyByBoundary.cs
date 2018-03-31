using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Anything that LEAVES (OnTriggerExit) to outside of boundary is wiped out
public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
