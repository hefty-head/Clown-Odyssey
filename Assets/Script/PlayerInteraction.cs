using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour{

	public GameObject currentObject = null;


	void Update()
	{
		if (Input.GetButtonDown ("Submit") && currentObject) 
		{
			//Do something with object
			currentObject.SendMessage("OnInteract"); //this should be changed, it's an expensive call
		}


	}
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log (coll.transform.parent.tag);
		if(coll.transform.parent.tag == "Interactable")
		{
			Debug.Log("my ass");
			currentObject = coll.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		Debug.Log (coll.transform.parent.tag);
		if(coll.transform.parent.tag == "Interactable")
		{
			if (coll.gameObject == currentObject) 
			{
				currentObject = null;
			}
		}
	}
}
