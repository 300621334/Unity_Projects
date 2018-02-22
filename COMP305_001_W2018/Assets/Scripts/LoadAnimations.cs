using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAnimations : MonoBehaviour {

	public GameObject animWalk, animRoll, animBlink;

	// Use this for initialization
	void Start () {
		Instantiate(animRoll,  new Vector3(0f, 0.3f , 0f), Quaternion.identity);
		Instantiate(animWalk,  new Vector3(0f, 0f , 0f), Quaternion.identity);
		Instantiate(animBlink, new Vector3(0f, -0.3f , 0f), Quaternion.identity);


	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<SpriteRenderer> ().sprite = animWalk;
	}
}
