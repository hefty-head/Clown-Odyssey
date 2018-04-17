using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using UnityEngine;
using UnityEngine.UI;

public class EnemyClass : MonoBehaviour {
	//I basically started writing the whole battle system in here so I guess we'll roll with that
	public string internalName;
	public int health;
	public string name;
	public string introText;
	public string[] actions = { "", "", "", "" };
	public string[] performanceText = { "", "", "", "" }; //This is a lot of variables that i don't think i need. Try and figure out a more efficient and clean way of doing this
	public string[] reactionText = { "", "", "", "" };
	public string spriteName;
	XDocument enemyDoc;
	public IEnumerable<XElement> items;
	//List <XMLData> data = new List <XMLData> ();
	public GameObject ActionSet;
	public Text Action1;
	public Text Action2;
	public Text Action3;
	public Text Action4;
	public Text General;

	public Button btn1;
	public Button btn2;
	public Button btn3;
	public Button btn4;


	public int begin = 0;
	// Use this for initialization

	void Start()
	{
		internalName = "elonmuskrat"; //Figure out how to send this value
		Debug.Log ("give me muskrat or give me death");
		SpriteRenderer rndr = GetComponent<SpriteRenderer>();
		enemyDoc = XDocument.Load ("Assets/Resources/data/enemy-data.xml");
		Debug.Log (enemyDoc);
		items = enemyDoc.Descendants ("enemy").Elements();
		Debug.Log (items);
		foreach (var item in items) {
			Debug.Log ("loopy");
			Debug.Log (internalName);
			if (item.Parent.Attribute ("internalname").Value.ToString () == internalName) {
				health = int.Parse(item.Parent.Element("health").Value);
				name = item.Parent.Element("Name").Value;
				introText = item.Parent.Element("Intro-Text").Value.Trim();
				spriteName = item.Parent.Element("sprite-info").Value.Trim();
				Debug.Log ("introText");
				Debug.Log (spriteName);
				actions[0] = item.Parent.Element("A1Text").Value.Trim();
				actions[1] = item.Parent.Element("A2Text").Value.Trim();
				actions[2] = item.Parent.Element("A3Text").Value.Trim();
				actions[3] = item.Parent.Element("A4Text").Value.Trim();

				performanceText[0] = item.Parent.Element("A1Performance-Text").Value.Trim();
				performanceText[1] = item.Parent.Element("A2Performance-Text").Value.Trim();
				performanceText[2] = item.Parent.Element("A3Performance-Text").Value.Trim();
				performanceText[3] = item.Parent.Element("A4Performance-Text").Value.Trim();

				reactionText[0] = item.Parent.Element("A1Reaction-Text").Value.Trim();
				reactionText[1] = item.Parent.Element("A2Reaction-Text").Value.Trim();
				reactionText[2] = item.Parent.Element("A3Reaction-Text").Value.Trim();
				reactionText[3] = item.Parent.Element("A4Reaction-Text").Value.Trim();
			}
		}

		rndr.sprite = Resources.Load<Sprite> (spriteName);//"Assets/Artwork/sprites/EnemySprites/ElonMuskrat";
		General.text = introText;
		Action1.text = actions [0];
		Action2.text = actions [1];
		Action3.text = actions [2];
		Action4.text = actions [3];

		btn1.onClick.AddListener (action1);

		Debug.Log ("WTF");
		//rndr.color = new Color(200,0,0);
	}

	void Update()
	{
		//There is 10000% a better way to do this btw
		if (begin == 0) {
			if (Input.GetButtonDown ("Submit")) {
				begin = 1;
		
				General.enabled = false;
				Action1.enabled = true;
				Action2.enabled = true;
				Action3.enabled = true;
				Action4.enabled = true;
				ActionSet.SetActive (true);
			}


		} else if (begin == 1) {

		}
	}
	protected virtual void playerAction(int damage, int effectNum)
	{
		switch (effectNum)
		{
			case 0:
				health -= damage; //Might add RPG like modifiers to player so we can have more types of attack
				break;
			case 1:
				//runaway code goes here
				break;
		}
	}

	IEnumerator waitForSubmit()
	{
		
		while (true) {
			while(!Input.GetButtonDown ("Submit")) {
				Debug.Log ("peepee");
				yield return null;
			}
				Debug.Log ("nothing");
		}
	}

	void action1()
	{
		//StartCoroutine (waitForSubmit);
		//Defaults to a generic attack, default form will probably never be used
		Debug.Log("Action 1 call");
		ActionSet.SetActive(false);
		General.enabled = true;
		General.text = performanceText [0];
		waitForSubmit ();
		General.text = reactionText [0];

	}
	protected virtual void action2()
	{

	}
	protected virtual void action3()
	{

	}
	protected virtual void action4()
	{
		//defaults to a runaway action, returns you to previous scene with n success rate
	}

	protected virtual void enemyAction()
	{

	}
}
