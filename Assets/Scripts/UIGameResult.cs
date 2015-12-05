using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGameResult : MonoBehaviour {
	public GameObject successGroup;
	public GameObject failGroup;

	void Start () {
		UILabel[] labels = GetComponentsInChildren<UILabel> ();

		if (GameManager.success) {
			labels = successGroup.GetComponentsInChildren<UILabel> ();
		} else {
			labels = failGroup.GetComponentsInChildren<UILabel> ();
		}

		foreach (UILabel label in labels) {
			label.transform.position = new Vector3 (
				label.transform.position.x,
				label.transform.position.y,
				0f);
		}
	}
}
