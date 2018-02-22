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
			//camera follow player's X-position
			Vector3 newCamPos = new Vector3 (playerPos.transform.position.x, transform.position.y, transform.position.z);
			this.transform.position = Vector3.MoveTowards (transform.position, newCamPos, step);
		}

		if (playerPos.transform.position.x > zoomStart.transform.position.x) {
			camera.orthographicSize = 5 - (playerPos.transform.position.x - zoomStart.transform.position.x)*0.25f;

		} 

		if(playerPos.transform.position.x < midStart.transform.position.x) 
		{
			this.transform.position = Vector3.MoveTowards (transform.position, cameranitialPos, step);
		}

	}
}
