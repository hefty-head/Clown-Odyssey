using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : collide {

	protected override void OnCollide (Collider2D coll)
	{
		if (coll.name == "Player") {
			//Debug.Log ("W");
			GameManager.instance.SaveState();
			string sceneName = "test2";
			UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
		}
	}
}
