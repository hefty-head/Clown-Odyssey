using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

	// Use this for initialization
	public bool canMove = true;
	private Vector3 moveDelta;
	private BoxCollider2D boxCollider;
	private RaycastHit2D hit;
    private Animator animator;

	private void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		DontDestroyOnLoad (this);
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update () {
		// reset move delta
		if (!canMove)
			return;
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		moveDelta = new Vector3 (x, y, 0);
        if (Input.GetKey("a") || Input.GetKey("d")||Input.GetKey("w")||Input.GetKey("s"))
            animator.SetInteger("State", 1);
        else
            animator.SetInteger("State", 0);

		//swap direction for right/left
		if (moveDelta.x > 0)
			transform.localScale = new Vector3(1,1,1);
		else if (moveDelta.x < 0)
			transform.localScale = new Vector3(-1,1,1);
		
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
