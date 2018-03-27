using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyClass : MonoBehaviour {

	public int health;
	public string name;
	public string introText;
	public string[] actions = { "", "", "", "" };
	public GameObject ActionSet;
	public Text Action1;
	public Text Action2;
	public Text Action3;
	public Text Action4;
	public Text General;
	public int begin = 0;
	// Use this for initialization

	protected virtual void start()
	{
	}
	protected virtual void action1()
	{
		//Defaults to a generic attack, probably will never be used
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
}
