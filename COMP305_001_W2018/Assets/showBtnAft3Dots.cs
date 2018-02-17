using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showBtnAft3Dots : MonoBehaviour {

	public GameObject btn;


	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		var clones = GameObject.FindGameObjectsWithTag ("yellowPoint");
		if(clones.Length >= 3)
		{
			gameObject.SetActive (true);
		}

	}
}
