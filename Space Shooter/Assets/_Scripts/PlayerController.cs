using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed, tilt;
	public Boundary boundary;
	public Transform gun;//instead of type GameObject, declaring a component type () only fetches that component instead of whole gameObj.
	public GameObject shot;
	public float fireRate;

	private float nextFire;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") && Time.time > nextFire) //input manager has set Fire1 to firing buttons. 
		{
			Instantiate (shot, gun.position, gun.rotation); //if instead of Transform type, gun was declared a GameObject type then we write gun.transform.position etc
			nextFire = Time.time + fireRate;//next shot cannot be fired until time eq to fireRate has past since last fire
		}
	}

	//called just before ea PHYSICS step (not ea frame)
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3 
			(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}





	

}
