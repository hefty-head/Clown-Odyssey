using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : collide {

	private int touch = 0;
	protected override void OnCollide(Collider2D coll)
	{
		Debug.Log ("poop");
		if (touch == 0) 
		{
			GameManager.instance.ShowText ("poopla", 35, Color.red, transform.position, Vector3.up * 50, 5.0f);
			touch = 1;
		}
	}
}
