using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Explosion to disappear after a time
public class DestroyByTime : MonoBehaviour {

	public float lifeTime;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeTime); //destroy explosion objs after this much time
	}
}
