using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class EnemyClass : MonoBehaviour {
	//I basically started writing the whole battle system in here so I guess we'll roll with that
	public string internalName;
	public int health;
	public string name;
	public string introText;
	private string[] actions = { "", "", "", "" };
	private string[] performanceText = { "", "", "", "" }; //This is a lot of variables that i don't think i need. Try and figure out a more efficient and clean way of doing this
	private string[] reactionText = { "", "", "", "" }; //These can also be not public lmao
	private int[] damage = { 0, 0, 0, 0 };
	private int[] effects = { 0, 0, 0, 0 };

	private string defeat;

	private string[] enemyPT = { "", "", "", "" };
	private int[] enemyD = { 0, 0, 0, 0 };
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

	private GameObject player;

	public int begin = 0;
	// Use this for initialization

	void Start()
	{
		internalName = InfoTransition.getEnemyName(); //Figure out how to send this value
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

				damage[0] = int.Parse(item.Parent.Element("A1Damage").Value);
				damage[1] = int.Parse(item.Parent.Element("A2Damage").Value);
				damage[2] = int.Parse(item.Parent.Element("A3Damage").Value);
				damage[3] = int.Parse(item.Parent.Element("A4Damage").Value);

				effects[0] = int.Parse(item.Parent.Element("A1Effect").Value);
				effects[1] = int.Parse(item.Parent.Element("A2Effect").Value);
				effects[2] = int.Parse(item.Parent.Element("A3Effect").Value);
				effects[3] = int.Parse(item.Parent.Element("A4Effect").Value);

				enemyPT[0] = item.Parent.Element("EA1PT").Value.Trim();
				enemyPT[1] = item.Parent.Element("EA2PT").Value.Trim();
				enemyPT[2] = item.Parent.Element("EA3PT").Value.Trim();
				enemyPT[3] = item.Parent.Element("EA4PT").Value.Trim();

				enemyD[0] = int.Parse(item.Parent.Element("EA1D").Value);
				enemyD[1] = int.Parse(item.Parent.Element("EA2D").Value);
				enemyD[2] = int.Parse(item.Parent.Element("EA3D").Value);
				enemyD[3] = int.Parse(item.Parent.Element("EA4D").Value);

				defeat = item.Parent.Element("DText").Value.Trim();
			}
		}

		rndr.sprite = Resources.Load<Sprite> (spriteName);//"Assets/Artwork/sprites/EnemySprites/ElonMuskrat";
		General.text = introText;
		Action1.text = actions [0];
		Action2.text = actions [1];
		Action3.text = actions [2];
		Action4.text = actions [3];

		btn1.onClick.AddListener (turn1);
		btn2.onClick.AddListener (turn2);
		btn3.onClick.AddListener (turn3);
		btn4.onClick.AddListener (turn4);

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

	IEnumerator startEnemyTurn()
	{
		//Random rnd = new Random();
		if (health <= 0) {
			//Show defeat text
			General.text = defeat;
			UnityEngine.SceneManagement.SceneManager.LoadScene (InfoTransition.getSceneName());
			Player playerScript = player.GetComponent<Player>();
			float[] position = InfoTransition.getPosition ();
			playerScript.transform.position = new Vector3(position[0], position[1], 0);
	//		playerScript.transform.position.y = position[1];

			
		} else {
			int pickMove = Random.Range (0, 3);
			Debug.Log ("enemy Turn");
			Debug.Log (pickMove);
			Debug.Log (enemyPT [pickMove]);
			General.text = enemyPT [pickMove];
			Text indicator = GameObject.Find ("Damage Indicator").GetComponent<Text> ();
			indicator.text = enemyD [pickMove].ToString ();
			indicator.enabled = true;
			yield return new WaitForSeconds (1);
			indicator.enabled = false;

			while (!Input.GetButtonDown ("Submit")) {
				Debug.Log ("pp");
				yield return null;
			}

			General.enabled = false;
			Action1.enabled = true;
			Action2.enabled = true;
			Action3.enabled = true;
			Action4.enabled = true;
			ActionSet.SetActive (true);
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


	void turn1()
	{

		StartCoroutine ("action1");
	}
	void turn2()
	{

		StartCoroutine ("action2");
	}
	void turn3()
	{

		StartCoroutine ("action3");
	}
	void turn4()
	{

		StartCoroutine ("action4");
	}
		
	private IEnumerator DamageIndicator(int damage)
	{
		Debug.Log ("in damage indicator");
		Text indicator = GameObject.Find("Damage Indicator").GetComponent<Text>();
		indicator.text = damage.ToString();
		indicator.enabled = true;
		yield return new WaitForSeconds(1);
		indicator.enabled = false;
	}
	IEnumerator action1()
	{
		//StartCoroutine (waitForSubmit);
		//Defaults to a generic attack, default form will probably never be used
		Debug.Log("Action 1 call");
		ActionSet.SetActive(false);
		General.enabled = true;
		General.text = performanceText [0];
		while (!Input.GetButtonDown ("Submit")) {
			Debug.Log ("pp");
			yield return null;
		}

		General.text = reactionText [0];
		StartCoroutine( DamageIndicator (damage[0]));
		playerAction (damage [0], effects [0]);
		yield return new WaitForSeconds(1);
		while (!Input.GetButtonDown ("Submit")) {
			Debug.Log ("p3");
			yield return null;
		}
		StartCoroutine(startEnemyTurn ());

	}
	IEnumerator action2()
	{
		//StartCoroutine (waitForSubmit);
		//Defaults to a generic attack, default form will probably never be used
		Debug.Log("Action 2 call");
		ActionSet.SetActive(false);
		General.enabled = true;
		General.text = performanceText [1];
		while (!Input.GetButtonDown ("Submit")) {
			Debug.Log ("pp");
			yield return null;
		}

		General.text = reactionText [1];
		StartCoroutine( DamageIndicator (damage[1]));
		playerAction (damage [1], effects [1]);
		yield return new WaitForSeconds(1);
		while (!Input.GetButtonDown ("Submit")) {
			Debug.Log ("p3");
			yield return null;
		}
		StartCoroutine(startEnemyTurn ());

	}
	IEnumerator action3()
	{
		//StartCoroutine (waitForSubmit);
		//Defaults to a generic attack, default form will probably never be used
		Debug.Log("Action 3 call");
		ActionSet.SetActive(false);
		General.enabled = true;
		General.text = performanceText [2];
		while (!Input.GetButtonDown ("Submit")) {
			Debug.Log ("pp");
			yield return null;
		}

		General.text = reactionText [2];
		StartCoroutine( DamageIndicator (damage[2]));
		playerAction (damage [2], effects [2]);
		yield return new WaitForSeconds(1);
		while (!Input.GetButtonDown ("Submit")) {
			Debug.Log ("p3");
			yield return null;
		}
		StartCoroutine(startEnemyTurn ());

	}
	IEnumerator action4()
	{
		//StartCoroutine (waitForSubmit);
		//Defaults to a generic attack, default form will probably never be used
		Debug.Log("Action 4 call");
		ActionSet.SetActive(false);
		General.enabled = true;
		General.text = performanceText [3];
		while (!Input.GetButtonDown ("Submit")) {
			Debug.Log ("pp");
			yield return null;
		}

		General.text = reactionText [3];
		StartCoroutine( DamageIndicator (damage[3]));
		playerAction (damage [3], effects [3]);
		yield return new WaitForSeconds(1);
		while (!Input.GetButtonDown ("Submit")) {
			Debug.Log ("p4");
			yield return null;
		}
		StartCoroutine(startEnemyTurn ());

	}

	protected virtual void enemyAction()
	{

	}
	IEnumerator waitForSubmit()
	{
		Debug.Log ("Coroutine");
	
		while (!Input.GetButtonDown ("Submit")) {
			Debug.Log ("pp");
			yield return null;
		}
		yield return null;
		Debug.Log ("F");
	}
}
