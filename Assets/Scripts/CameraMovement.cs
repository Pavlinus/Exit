using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	GameObject player;
	float distanceFromPlayer = 3f;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		Move ();
	}

	void Move () {
		transform.position = new Vector3 (transform.position.x,
		                                  transform.position.y,
		                                  player.transform.position.z + distanceFromPlayer);
	}
}
