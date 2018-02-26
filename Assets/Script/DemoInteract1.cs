using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInteract1 : Interactable {
	private int numMessages = 2;
	public override void OnInteract()
	{

		Player playerScript = player.GetComponent<Player>();
		if (playerScript.canMove && numMessages == 2)
		{
			playerScript.canMove = false;
			Debug.Log ("demo");
			txt.text = "I'm a sprite from an earlier build. You'll likely see a cleaner version of me animated with the next build";
			canvas.SetActive (true);
			numMessages-=2;


		}
		else if (numMessages == 1)
		{
			txt.text = "DemoSpeech 2";
			numMessages--;
		}
		else if (!playerScript.canMove && numMessages == 0) 
		{
			canvas.SetActive (false);
			playerScript.canMove = true;
			numMessages = 2;
		}
		//if(Input.GetButtonDown("Cancel"))
		//playerScript.canMove = true;
	}
}
