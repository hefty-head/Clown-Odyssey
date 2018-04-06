using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InfoTransition {

	private static string enemyName, currentScene;
	private static float[] playerPosition = {0,0};

	public static string getEnemyName()
	{
		return enemyName;
	}

	public static void setEnemyName(string value)
	{
		enemyName = value;
	}

	public static string getSceneName()
	{
		return currentScene;
	}

	public static void setSceneName(string value)
	{
		currentScene = value;
	}

	public static void setPosition(float x, float y)
	{
		playerPosition[0] = x;
		playerPosition[1] = y;
	}

	public static float[] getPosition()
	{
		return playerPosition;
	}

}
