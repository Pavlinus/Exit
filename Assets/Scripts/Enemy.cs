using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	float rotationSpeed = 25f;

	void Start () {
	
	}

	void Update () {
		Rotate ();
	}

	/// <summary>
	/// Rotation on Y axis
	/// </summary>
	void Rotate () {
		Vector3 curRotation = transform.rotation.eulerAngles;
		Quaternion rotation = Quaternion.Euler (
			new Vector3 (0f, curRotation.y + rotationSpeed * Time.deltaTime, 0f));

		transform.rotation = rotation;
	}
}
