using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorGreen : MonoBehaviour {

	public SpriteRenderer guy;
	public Sprite guyGreen;

	void OnMouseDown()
	{
		guy.sprite = guyGreen;
	}
}
