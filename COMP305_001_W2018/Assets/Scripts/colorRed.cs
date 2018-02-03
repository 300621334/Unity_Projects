using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorRed : MonoBehaviour {

	public SpriteRenderer guy;
	public Sprite guyRed;

	void OnMouseDown()
	{
		guy.sprite = guyRed;
	}
}
