using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationCurves : MonoBehaviour  {

	public AnimationCurve curves;
	public float startX, startY, endX, endY , duration, timeOfClick;

	private Vector3 startPos, endPos;
	private bool startMoving = false;

	// Use this for initialization
	void Start () {
		startPos = new Vector3 (startX, startY,0f);
		endPos = new Vector3 (endX, endY,0f);
	}

//	void OnTriggerEnter(Collider otherObj)
//	{
//		startMoving = startMoving?false:true;
//		timeOfClick = Time.time;
//		transform.position = startPos;//bring to startPos
//		gameObject.SetActive(true);
//		Debug.Log (startMoving);
//	}

	void OnMouseDown()
	{
		startMoving = startMoving?false:true;
		timeOfClick = Time.time;
		transform.position = startPos;//bring to startPos
		gameObject.SetActive(true);
		Debug.Log (startMoving);
	}

	// Update is called once per frame
	void Update () {
		if(startMoving)
		{
			float time = Time.time - timeOfClick;
			//float t = time % duration;
			transform.position = Vector3.Lerp (startPos, endPos, curves.Evaluate(time % duration));//when duration=0 returns startPos, when=1 returns endPos

		}

//		if(transform.position == endPos)//reached endPos
//		{
//			startMoving = false;//stop moving
//			Debug.Log (startMoving);
//			//gameObject.SetActive(false);//disable obj so that clk on other objs don't start moving this again
//		}
	}
}
