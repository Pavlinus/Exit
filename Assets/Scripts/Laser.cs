using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	public Sprite detected;
	public GameObject laserLight;

	void OnTriggerEnter (Collider collider) {
		if (collider.tag.Equals ("Player")) {

			if (!GameManager.success) {
				if (!GameManager.isGameOver) {
					GetComponent<AudioSource> ().Play ();
				}
				laserLight.GetComponent<SpriteRenderer> ().sprite = detected;
				GameManager.isGameOver = true;
				StartCoroutine (NextScene ());
			}
		}
	}

	IEnumerator NextScene () {
		yield return new WaitForSeconds (2.5f);
		Application.LoadLevel (2);
	}
}
