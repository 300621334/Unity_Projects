using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoy : MonoBehaviour {

	private Rigidbody2D rbBall;
	private Vector2 moveDir;
	private Vector3 scaleBall;
	private Vector3 position;
	private Animator animation;

	public float speedBoy = 5;

	// Use this for initialization
	void Start () {
		rbBall = GetComponent<Rigidbody2D> ();
		scaleBall = transform.localScale;
		//position = transform.position;//init here bring player back to starting pos
		animation = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		//Move & change face direction
		if (Input.GetKey (KeyCode.J)) //Hold down 'F'
		{
			if(scaleBall.x > 0)scaleBall.x *= -1;
			transform.localScale = scaleBall;
			moveDir = new Vector2 (-1f, 0f);
			//rb.velocity = moveDir * speedBoy;//fall from platform is slow if 'A' kept pressed. When 'A' released, then gravity takes full effect. .AddFor() solves that
			rbBall.AddForce( moveDir * speedBoy);
			//Debug.Log (moveDir.ToString());
		} 
		else if (Input.GetKey (KeyCode.L)) 
		{
			if(scaleBall.x < 0)scaleBall.x *= -1;
			transform.localScale = scaleBall;
			moveDir = new Vector2 (1f, 0.0f);
			//rb.velocity = moveDir * speedBoy;
			rbBall.AddForce (moveDir * speedBoy);

		} 
		else if (Input.GetKeyUp (KeyCode.J)) //Release 'F'
		{
			transform.localScale = scaleBall;
			moveDir = new Vector2 (0f, 0.0f);
			rbBall.velocity = moveDir * 0f;
		} 
		else if (Input.GetKeyUp (KeyCode.L)) 
		{
			transform.localScale = scaleBall;
			moveDir = new Vector2 (0f, 0.0f);
			rbBall.velocity = moveDir * 0f;
		} 

		position = transform.position;
		//Jump	
		if(Input.GetKeyDown (KeyCode.M))
		{
			position.y += 0.5f;
			transform.position = position;
			//animation.Play ("rollKirby");
			//created a transition from jumpKirby to walkKirby that resumes walking after certain amount of time (see animator window > settings node)
		}
	}
}
