using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarpInteract : Interactable {


	public override void OnInteract()
	{

		Debug.Log ("Warp activated");
		GameManager.instance.SaveState();
		string sceneName = "test2";
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
		//if(Input.GetButtonDown("Cancel"))
		//playerScript.canMove = true;
	}
}
