using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDemoMark : Interactable {
	private int numMessages = 4;
	public override void OnInteract()
	{

		Player playerScript = player.GetComponent<Player>();
		if (playerScript.canMove && numMessages == 4)
		{
			playerScript.canMove = false;
			Debug.Log ("demo");
			txt.text = "The tiles are slightly spread apart because of a bug with how unity handles the tilemaps";
			canvas.SetActive (true);
			numMessages--;


		}
		else if (numMessages == 3)
		{
			txt.text = "I'm not really sure why it happens, but the fix is to extend the tiles over one pixel on each side";
			numMessages--;
		}
		else if (numMessages == 2)
		{
			txt.text = "This is an issue that will be fixed with the next build";
			numMessages--;
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
