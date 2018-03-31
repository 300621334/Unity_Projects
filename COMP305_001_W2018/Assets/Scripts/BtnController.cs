using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Load new scene

public class BtnController : MonoBehaviour {


	public void btnClk_LoadScene(string sceneName)//Upgrade1 of Cutscenes
	{
		SceneManager.LoadScene (sceneName);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
