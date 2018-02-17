using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class walkKirby : MonoBehaviour {
	
	private Rigidbody2D rb;
	private Vector2 moveDirection;
	private Vector3 scale;
	private Vector3 pos;
	private Animator anim;
	private SpriteRenderer sRend;

	//public LayerMask LayerMask;
	public float forceY = 1000;
	public float forceX = 500;

//	void OnTriggerEnter(Collider collidee)//OnCollisionEnter
//	{
//		if(collidee.gameObject.CompareTag( "platform"))//if(collidee.collider.tag == "platform") obsolete
//		{
//			//rb.gravityScale = 0;
//			//gameObject.SetActive(false);
//		}
//
//	}


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		scale = transform.localScale;
		//pos = transform.position;//init here bring player back to starting pos
		anim = GetComponent<Animator> ();
		sRend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Move & change face direction
		if (Input.GetKey ("a")) //capital "A" cause err unknown key
		{
			//if(scale.x > 0)scale.x *= -1;
			//transform.localScale = scale;
			//moveDirection = new Vector2 (-1f, 0f);
			//rb.velocity = moveDirection * speed;//fall from platform is slow if 'A' kept pressed. When 'A' released, then gravity takes full effect. .AddFor() solves that
			//rb.AddForce(new Vector2( -force * Time.deltaTime , 0f) );
			sRend.flipX = true;
			rb.velocity = new Vector2 (-forceX * Time.deltaTime, 0f);

		} 
		else if (Input.GetKey ("d")) 
		{
			//if(scale.x < 0)scale.x *= -1;
			//transform.localScale = scale;
			//moveDirection = new Vector2 (1f, 0.0f);
			//rb.velocity = moveDirection * speed;
			//rb.AddForce( new Vector2(force * Time.deltaTime , 0f) );//accelerates
			sRend.flipX = false;
			rb.velocity = new Vector2 (forceX * Time.deltaTime, 0f);


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
	
		pos = transform.position;
		//Jump	
		if(Input.GetKeyDown (KeyCode.Z))
		{
			pos.y += 0.7f;
			transform.position = pos;
			//rb.AddForce(new Vector2(0, forceY * Time.deltaTime));
			//rb.velocity = new Vector2(0, forceY * Time.deltaTime);
			anim.Play ("rollKirby");
			//created a transition from jumpKirby to walkKirby that resumes walking after certain amount of time (see animator window > settings node)
		}
	}
}
