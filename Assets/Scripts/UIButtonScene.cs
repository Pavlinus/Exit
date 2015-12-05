using UnityEngine;
using System.Collections;

public class UIButtonScene : MonoBehaviour {

	public enum Scenes {
		MAIN_MENU = 0,
		GAME_SCENE,
		EXIT
	}

	public Scenes loadScene;

	void OnClick () {
		switch (loadScene) {
		case Scenes.MAIN_MENU:
			Application.LoadLevel (0);
			break;

		case Scenes.GAME_SCENE:
			Application.LoadLevel (1);
			break;

		case Scenes.EXIT:
			Application.Quit ();
			break;
		}
	}
}
