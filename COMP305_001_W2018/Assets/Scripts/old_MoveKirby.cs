using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKirby : MonoBehaviour {

	private Rigidbody2D rb;
	//private float inputAxisX;
	private Vector2 moveDirection;
	//private Animator animator;
	Vector3 scale;

	public float speed = 1;
	//public Sprite spriteJump, spriteMove;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//animator = this.GetComponent<Animator>();
		scale = transform.localScale;
	}

	void FixedUpdate()
	{
		

		//inputAxisX = Input.GetAxis ("Horizontal");
		//moveDirection = new Vector2 (inputAxisX, 0.0f);
		//transform.rotation = Quaternion.LookRotation (moveDirection, Vector2.left);

		if (Input.GetKey (KeyCode.A)) //Hold down 'A'
		{
			if(scale.x > 0)scale.x *= -1;
			transform.localScale = scale;
			moveDirection = new Vector2 (-1f, 0f);
			rb.velocity = moveDirection * speed;
		} 
		else if (Input.GetKey (KeyCode.D)) 
		{
			if(scale.x < 0)scale.x *= -1;
			transform.localScale = scale;
			moveDirection = new Vector2 (1f, 0.0f);
			rb.velocity = moveDirection * speed;
		} 
		else if (Input.GetKeyUp (KeyCode.A)) //Release 'A'
		{
			transform.localScale = scale;
			moveDirection = new Vector2 (0f, 0.0f);
			rb.velocity = moveDirection * 0f;
		} 
		else if (Input.GetKeyUp (KeyCode.D)) 
		{
			transform.localScale = scale;
			moveDirection = new Vector2 (0f, 0.0f);
			rb.velocity = moveDirection * 0f;
		} 

		/*
		//ALTERNATE using .flipX...
		//gameObject.GetComponent<SpriteRenderer>().sprite = spriteMove;

		if (Input.GetKey (KeyCode.A)) //Hold down 'A'
		{
			if(scale.x > 0)this.GetComponent<SpriteRenderer>().flipX = true;
			moveDirection = new Vector2 (-1f, 0.0f);
			rb.velocity = moveDirection * speed;
		} 
		else if (Input.GetKey (KeyCode.D)) 
		{
			if(scale.x < 0)this.GetComponent<SpriteRenderer>().flipX = true;
			moveDirection = new Vector2 (1f, 0.0f);
			rb.velocity = moveDirection * speed;
		} 
		else if (Input.GetKeyUp (KeyCode.A)) //Release 'A'
		{
			transform.localScale = scale;
			moveDirection = new Vector2 (0f, 0.0f);
			rb.velocity = moveDirection * 0f;
		} 
		else if (Input.GetKeyUp (KeyCode.D)) 
		{
			transform.localScale = scale;
			moveDirection = new Vector2 (0f, 0.0f);
			rb.velocity = moveDirection * 0f;
		} 
		*/


	

		//this works BUT animatiion flutters
		 /*	if(inputAxisX < 0.0f)
		{
			scale.x *= -1;
			transform.localScale = scale;
		}*/
			
		//From Roben's code.....
		//		if (inputAxisX > 0)
//		{
//			animator.SetInteger("Direction", 3);
//		}
//		else if (inputAxisX < 0)
//		{
//			animator.SetInteger("Direction", 1);
//		}

		//rb.velocity = moveDirection * speed;
	}

	void Update () {
		
	}
}
