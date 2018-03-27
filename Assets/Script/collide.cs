using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collide : MonoBehaviour {
	public ContactFilter2D filter;
	private BoxCollider2D boxCollider;
	private Collider2D[] hits = new Collider2D[10];

	protected virtual void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}
	protected virtual void Update()
	{
		Debug.Log ("can i get uhhh");
		boxCollider.OverlapCollider (filter, hits);
		//stores overlap in hits

		for (int i = 0; i < hits.Length; i++) 
		{
			if (hits [i] == null)
				continue;

			Debug.Log ("fuhh");
			OnCollide (hits[i]);

			hits [i] = null;
			//cleans array for next check
		}

	}

	protected virtual void OnCollide(Collider2D coll)
	{
		Debug.Log (coll.name);
	}
}
	