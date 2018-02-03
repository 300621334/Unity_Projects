using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorBlue : MonoBehaviour {
	public SpriteRenderer guy;
	public Sprite guyBlue;

	void OnMouseDown() //must have a Collider, doesn't have to be a Trigger-collider for simple click
	{
		Debug.Log("clicked");
		guy.sprite = guyBlue;
	}
		
}
