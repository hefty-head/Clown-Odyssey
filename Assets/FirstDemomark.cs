using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDemomark : Interactable {
	private int numMessages = 4;
	public override void OnInteract()
	{

		Player playerScript = player.GetComponent<Player>();
		if (playerScript.canMove && numMessages == 4)
		{
			playerScript.canMove = false;
			Debug.Log ("demo");
			txt.text = "This demo is mostly a showing of the tiles we have so far";
			canvas.SetActive (true);
			numMessages--;


		}
		else if (numMessages == 3)
		{
			txt.text = "It's divided into two distinct areas for the tiles we have";
			numMessages--;
		}
		else if (numMessages == 2)
		{
			txt.text = "As far as systems are concerned, basically everything except the battle system is completed";
			numMessages--;
		}
		else if (numMessages == 1)
		{
			txt.text = "This isn't a lot, but having this base completed will let us build much faster over the next quarter. Enjoy!";
			numMessages--;
		}
		else if (!playerScript.canMove && numMessages == 0) 
		{
			canvas.SetActive (false);
			playerScript.canMove = true;
			numMessages = 4;
		}
		//if(Input.GetButtonDown("Cancel"))
		//playerScript.canMove = true;
	}
}
