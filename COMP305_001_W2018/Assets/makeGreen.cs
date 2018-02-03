using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class makeGreen : MonoBehaviour {

	public GameObject guy;
	public Button btn; 
	public Sprite green, blue, red;

	void Start()
	{
		btn.onClick.AddListener (OnClick);
	}


	void OnClick()
	{
		green = guy.GetComponent<Sprite> ();
		green = blue;
	}
}
