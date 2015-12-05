using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public ParticleSystem particles;

	void OnTriggerEnter (Collider collider) {
		if (collider.tag.Equals ("Player")) {
			if (!GameManager.isGameOver) {
				GameManager.success = true;

				particles.playOnAwake = true;
				particles.Play ();

				GetComponent<AudioSource> ().Play ();
				StartCoroutine (NextScene ());
			}
		}
	}

	IEnumerator NextScene () {
		yield return new WaitForSeconds (3.5f);
		Application.LoadLevel (2);
	}
}
