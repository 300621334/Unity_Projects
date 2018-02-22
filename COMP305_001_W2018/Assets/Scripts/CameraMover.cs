using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

	public Transform playerPos, cameraPos, midStart, safeMidStart, safeMidEnd, zoomStart;
	public Vector3 cameranitialPos;
	public Camera camera;
	public AnimationCurve curve;

	private float step = 1.0f;


	// Update is called once per frame
	void Update () {

		if(playerPos.transform.position.x > midStart.transform.position.x && 
			!(playerPos.transform.position.x > safeMidStart.transform.position.x && playerPos.transform.position.x < safeMidEnd.transform.position.x))
		{
			Vector3 position = transform.position;//grab current cam pos
			Vector3 newCamPos = new Vector3 (playerPos.transform.position.x, transform.position.y, transform.position.z);//new cam pos will be same as pos of player
			//this.transform.position = Vector3.MoveTowards (transform.position, newCamPos, step);
			position = Vector3.Lerp(position, newCamPos, 3.0f * Time.deltaTime);//get a point fraction of the way between current cam pos & new pos
			transform.position = position;//move cam towards new pos a fraction at a time (per ea frame)
		}

		if (playerPos.transform.position.x > zoomStart.transform.position.x) {
			camera.orthographicSize = 5 - (playerPos.transform.position.x - zoomStart.transform.position.x)*0.2f;

		} 

		if(playerPos.transform.position.x < midStart.transform.position.x) 
		{
			//this.transform.position = Vector3.MoveTowards (transform.position, cameranitialPos, step);
			Vector3 position = transform.position;//grab current cam pos
			position = Vector3.Lerp(transform.position, cameranitialPos, 3.0f * Time.deltaTime);
			transform.position = position;

		}

	}
}
