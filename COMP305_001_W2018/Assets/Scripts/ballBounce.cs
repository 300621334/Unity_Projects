using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBounce : MonoBehaviour {

	private Rigidbody2D rbBall;
	private Vector2 moveDir;
	private Vector3 scaleBall;
	private Vector3 position;
	private Animator animation;

	//public LayerMask layerMask;
	public float speedBall = 5;

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
		if (Input.GetKey (KeyCode.F)) //Hold down 'A'
		{
			if(scaleBall.x > 0)scaleBall.x *= -1;
			transform.localScale = scaleBall;
			moveDir = new Vector2 (-1f, 0f);
			//rb.velocity = moveDir * speedBall;//fall from platform is slow if 'A' kept pressed. When 'A' released, then gravity takes full effect. .AddFor() solves that
			rbBall.AddForce( moveDir * speedBall);
			//Debug.Log (moveDir.ToString());
		} 
		else if (Input.GetKey (KeyCode.H)) 
		{
			if(scaleBall.x < 0)scaleBall.x *= -1;
			transform.localScale = scaleBall;
			moveDir = new Vector2 (1f, 0.0f);
			//rb.velocity = moveDir * speedBall;
			rbBall.AddForce (moveDir * speedBall);

		} 
		else if (Input.GetKeyUp (KeyCode.F)) //Release 'A'
		{
			transform.localScale = scaleBall;
			moveDir = new Vector2 (0f, 0.0f);
			rbBall.velocity = moveDir * 0f;
		} 
		else if (Input.GetKeyUp (KeyCode.H)) 
		{
			transform.localScale = scaleBall;
			moveDir = new Vector2 (0f, 0.0f);
			rbBall.velocity = moveDir * 0f;
		} 

		position = transform.position;
		//Jump	
		if(Input.GetKeyDown (KeyCode.V))
		{
			position.y += 0.5f;
			transform.position = position;
			//animation.Play ("rollKirby");
			//created a transition from jumpKirby to walkKirby that resumes walking after certain amount of time (see animator window > settings node)
		}
	}
}
