using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW_Anim_Controller	 : MonoBehaviour {
	public float FloorLevel, speed;//Blend Tree doesn't show int param in drop-down so keep em float!!	
	Rigidbody2D rb;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//rb.velocity = Vector2==================================


		pos = transform.position;
		pos.x += Input.GetAxis ("Horizontal") * speed;
		transform.position = pos;
	}
}
