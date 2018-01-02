using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	//distance between ball and player
	private Vector3 distance;

	void Start () {
		distance = transform.position - player.transform.position;
	}

	void LateUpdate () {
		transform.position = distance + player.transform.position;
	}
}
