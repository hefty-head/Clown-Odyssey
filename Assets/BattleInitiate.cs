using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInitiate : collide{

	protected override void OnCollide (Collider2D coll)
	{
		if (coll.name == "Player") {
			Debug.Log ("Battle activated");
			GameManager.instance.SaveState();
			string sceneName = "battlescene.unity";
			UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
		}
	}
}
