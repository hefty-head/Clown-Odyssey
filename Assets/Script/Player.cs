using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	// Use this for initialization
	public bool canMove = true;
	public bool inBattle = false;
	private Vector3 moveDelta;
	private BoxCollider2D boxCollider;
	private RaycastHit2D hit;
    private Animator animator;
	private int encounterLimiter = 0;
	public int health = 100;
	//Define list for inventory
	private void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		DontDestroyOnLoad (this);
        animator = GetComponent<Animator>();
	}

	public void leaveBattle()
	{
		inBattle = false;
		Debug.Log (inBattle);
		Debug.Log ("ESTEEP");
	}
	private void randomEncounter()
	{
		//This function facilitates random encounters. I'd rather do overworld encounters, but for the sake of time we in this shit
		Debug.Log("Being random encounter function");
		if (encounterLimiter != 40) {
			encounterLimiter++; //This is the best tool to control encounter rate for some reason
			return;
		}
		int encounterGen = Random.Range (0, 100);
		Debug.Log (encounterGen);	
		int encounterRate = 20; // set high for testing sake
		if (encounterGen < encounterRate) {
			Player playerScript = this.GetComponent<Player> ();
			GameManager.instance.SaveState();
			string sceneName = "battlescene";
			inBattle = true;
			InfoTransition.setEnemyName ("elonmuskrat"); //This will be changed to randomly draw from a document with encounter data
			Scene scene = SceneManager.GetActiveScene ();
			InfoTransition.setSceneName (scene.name);
			InfoTransition.setPosition(playerScript.transform.position.x,playerScript.transform.position.y);
			UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
		}
		encounterLimiter = 0;
	}
	// Update is called once per frame
	private void Update () {
		// reset move delta
		if(SceneManager.GetActiveScene().name != "battlescene")
			inBattle = false;
		if (!canMove || inBattle)
			return;
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		moveDelta = new Vector3 (x, y, 0);
        if (Input.GetKey("a") || Input.GetKey("d")||Input.GetKey("w")||Input.GetKey("s"))
            animator.SetInteger("State", 1);
        else
            animator.SetInteger("State", 0);

		//swap direction for right/left
		if (moveDelta.x > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
			Debug.Log ("Is this where the random encounter should be");
			randomEncounter ();
		} else if (moveDelta.x < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
			Debug.Log ("Is this where the random encounter should be");
			randomEncounter ();
		}
		if (moveDelta.y != 0) {
			Debug.Log ("Is this where the random encounter should be");
			randomEncounter ();
		}
		hit = Physics2D.BoxCast (transform.position, boxCollider.size, 0, new Vector2 (0, moveDelta.y), Mathf.Abs (moveDelta.y * Time.deltaTime), LayerMask.GetMask ("Actor", "Blocking"));
		if(hit.collider == null || hit.collider.tag == "Trigger")
			transform.Translate (0,moveDelta.y * Time.deltaTime, 0);
		hit = Physics2D.BoxCast (transform.position, boxCollider.size, 0, new Vector2 ( moveDelta.x,0), Mathf.Abs (moveDelta.x * Time.deltaTime), LayerMask.GetMask ("Actor", "Blocking"));
		if(hit.collider == null || hit.collider.tag == "Trigger")
			transform.Translate (moveDelta.x * Time.deltaTime, 0,0);
		

	}
	public void mutateCanMove()
	{
		canMove = !canMove;
	}
}
