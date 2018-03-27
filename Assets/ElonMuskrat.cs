using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElonMuskrat : EnemyClass {

	int health = 100;
	string name = "MuskRat";
	string introText = "I just got verbal government approval to turn you inside out!";
	string[] actions = {"Cambridge Analytica Scandal", "Remove photons from the room", "Stroke his ego", "tiptoe away"};

	void Start()
	{
		Debug.Log ("give me muskrat or give me death");
		SpriteRenderer rndr = GetComponent<SpriteRenderer>();

		rndr.sprite = Resources.Load<Sprite> ("enemy_ElonMuskrat");;//"Assets/Artwork/sprites/EnemySprites/ElonMuskrat";
		General.text = introText;
		//rndr.color = new Color(200,0,0);
	}

	protected override void action1()
	{
		
	}
}
