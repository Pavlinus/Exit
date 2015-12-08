using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	Vector3 moveUp;
	Vector3 moveDown;
	Vector3 moveLeft;
	Vector3 moveRight;
	Vector3[] moveDirections;
	Vector3 curDirection;
	int curIndex;
	float yAxisPos;
	float speed = 1f;

	void Start () {
		moveUp = new Vector3 (0f, 0f, -speed * Time.deltaTime);
		moveDown = new Vector3 (0f, 0f, speed * Time.deltaTime);
		moveLeft = new Vector3 (speed * Time.deltaTime, 0f, 0f);
		moveRight = new Vector3 (-speed * Time.deltaTime, 0f, 0f);

		moveDirections = new Vector3[] {moveUp, moveRight, moveLeft, moveDown};
		curDirection = moveUp;
	}

	void Update () {
		AttemptMove ();
		Move ();
	}

	void Move () {
		transform.position += curDirection;
	}

	void SetDirection () {
		int index = Random.Range (0, 12);
		index = index % 4;
		
		if (index == curIndex) {
			if (curIndex + 1 >= moveDirections.Length) {
				curIndex = 0;
			} else {
				curIndex += 1;
			}
		} else {
			curIndex = index;
		}
		
		curDirection = moveDirections [curIndex];	
	}

	void AttemptMove () {
		Vector3 forward = transform.TransformDirection (Vector3.forward);
		RaycastHit ray;
		int mask = LayerMask.GetMask ("Obstacle");

		if (Physics.Raycast (transform.position, forward, out ray, 0.5f, mask)) {
			SetDirection ();
			Rotate ();
		}
	}

	void Rotate () {
		Vector3 curRotation = transform.rotation.eulerAngles;
		float rotationAngle = GetRotationAngle ();

		Quaternion rotation = Quaternion.Euler (
			new Vector3 (0f, rotationAngle, 0f));
		
		transform.rotation = rotation;
	}

	float GetRotationAngle () {
		float angle = 0f;

		if (curDirection.Equals (moveUp)) {
			angle = -180;
		} else if (curDirection.Equals (moveDown)) {
			angle = 0f;
		} else if (curDirection.Equals (moveLeft)) {
			angle = 90f;
		} else if (curDirection.Equals (moveRight)) {
			angle = -90f;
		}

		return angle;
	}
}
