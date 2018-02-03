using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countTxt;
	public Text winTxt;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();//grab the sphere
		count = 0;
		setCountTxt ();
		winTxt.text = "";
	}

	// Update is called before any physics calculation
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");//highlight 'Input' & ctrl+singleQuote => will open API ref for Input
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 move = new Vector3 (moveHorizontal, 0.0f, moveVertical); // (x, y, z)
		rb.AddForce (move * speed);
	}
	// Update is called once per frame
	void Update () {
		
	}

	//Once Player enters an obj that's isTrigger=true, a Msg is sent
	void OnTriggerEnter(Collider other)//careful w spelling & caps!!
	{
		//Destroy (other.gameObject);	//DO NOT destroy, just disable obj the player collided with
		if(other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive (false);
			count++;
			setCountTxt ();
		}
	}


	void setCountTxt ()
	{
		countTxt.text = "Count: " + count.ToString();

		if (count >= 8) {
			winTxt.text = "You Win!!!";
		}

	}



	/*Unity caches data of STATIC objs so it don't have to re-calculate them on ea frame. But doesn't cache pos of DYNAMIC objs.
		 * To be dynamic obj must have collider+RigdBody or else they r considered static and extra resources r consumed ea frame to cache them.
		 * So give physics(RigidBody) to rotating PickUps then either unchk gravity(not good coz still could respond to physical forces)
		 * -or- chk isKinemetic (doesn't respond to physical forces BUT can animate w transformet component)
		*/

}
