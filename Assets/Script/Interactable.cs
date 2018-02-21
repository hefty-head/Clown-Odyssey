using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public bool talks;
	public string message;
	public GameObject player;//= GameObject.FindWithTag ("Player");

	public virtual void OnInteract()
	{
		
		Player playerScript = player.GetComponent<Player>();
		if (playerScript.canMove) 
		{
			playerScript.canMove = false;
			Debug.Log ("eat pa");
		} 
		else if (!playerScript.canMove) 
		{
			playerScript.canMove = true;
		}
		//if(Input.GetButtonDown("Cancel"))
		//playerScript.canMove = true;
	}
}
