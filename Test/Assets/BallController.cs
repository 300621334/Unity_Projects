using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float rotationSpeed = 100;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed; //Keys A/D or arrows send Input
		rotation *= Time.deltaTime; //adjust for frame rate variations
		//Rigidbody ball = this;
		//ball.AddRelativeTorque(Vector3.right * rotation);
		Vector3 movement = new Vector3(rotation , 0.0f, 0.0f);
		rb.AddForce(movement);

		print ( movement );
	}
}
