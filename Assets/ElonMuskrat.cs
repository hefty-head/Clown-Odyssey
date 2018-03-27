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

		rndr.sprite = Resources.Load<Sprite> ("enemy_ElonMuskrat");//"Assets/Artwork/sprites/EnemySprites/ElonMuskrat";
		General.text = introText;
		Action1.text = actions [0];
		Action2.text = actions [1];
		Action3.text = actions [2];
		Action4.text = actions [3];
		
		//rndr.color = new Color(200,0,0);
	}

	void Update()
	{
		//There is 10000% a better way to do this btw
		if (begin == 0) {
			if(Input.GetButtonDown("Submit"))
				begin = 1;
		} else {
			General.enabled = false;
			Action1.enabled = true;
			Action2.enabled = true;
			Action3.enabled = true;
			Action4.enabled= true;
			ActionSet.SetActive(true);



		}
	}

	protected override void action1()
	{
		
	}
}
