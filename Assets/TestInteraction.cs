using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : collide {


	protected override void OnCollide(Collider2D coll)
	{
		Debug.Log ("poop");
	}
}
