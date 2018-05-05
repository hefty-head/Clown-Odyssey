using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InfoTransition {

	private static string enemyName, currentScene;
	private static float[] playerPosition = {0,0};
	private static int inBattle;
	public static string getEnemyName()
	{
		Debug.Log ("called getEnemyName() in info trans");
		return enemyName;
	}

	public static void setEnemyName(string value)
	{
		Debug.Log ("called setEnemyName() in info trans");
		enemyName = value;
	}

	public static string getSceneName()
	{
		Debug.Log ("called getSceneName() in info trans");
		return currentScene;
	}

	public static void setSceneName(string value)
	{
		Debug.Log ("called setSceneName() in info trans");
		currentScene = value;
	}

	public static void setPosition(float x, float y)
	{
		Debug.Log ("called setPos() in info trans");
		playerPosition[0] = x;
		playerPosition[1] = y;
	}

	public static float[] getPosition()
	{
		Debug.Log ("called setPos() in info trans");
		return playerPosition;
	}

	public static void setInBattle(int inB)
	{
		inBattle = inB;
	}
	public static int getInBattle()
	{
		return inBattle;
	}

}
