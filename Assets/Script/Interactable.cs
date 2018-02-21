using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

	public bool talks;
	private int numMessages = 2;
	public string message;
	public GameObject player;//= GameObject.FindWithTag ("Player");
	public GameObject canvas;
	public Text txt;
	public virtual void OnInteract()
	{
		
		Player playerScript = player.GetComponent<Player>();
		if (playerScript.canMove && numMessages == 2)
		{
			playerScript.canMove = false;
			txt.text = "Eat pant asshole";
			canvas.SetActive (true);
			numMessages--;


		}
		else if (numMessages == 1)
		{
			txt.text = "Q to the bourgeoisie";
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
