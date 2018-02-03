using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;//being PUBLIC this will show in inspector & u need to drag-drop Player obj into box beside it
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	// LateUpdate is called once per frame BUT AFTER all items have been processed in Update() so we know player has moved for that frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}

	// Update is called once per frame
	void Update () {
	}
}
