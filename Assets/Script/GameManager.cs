using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	public static GameManager instance;
	private void Awake()
	{
		if (GameManager.instance != null)
		{
			Destroy (gameObject);
			return;
		}
		instance = this;
		SceneManager.sceneLoaded += LoadState;
		DontDestroyOnLoad (this);//could be gameobject 
		//you should initialize these values in a loading scene so you don't have to worry about conflicts. This should be done with all objects that must persist between scenes
	}
	//Game resources
	public List<Sprite> playerSprites;
	public List<int> xpTable;

	//References
	public Player player;
	public FloatingTextManager floatingText;

	public int money;
	public int experience;

	public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
	{
		floatingText.Show (msg, fontSize, color, position, motion, duration);
	}

	public void SaveState()
	{
		string s = "";
		s += money.ToString() + "|";
		s += experience.ToString();
		//could also set things like location for saving purposes
		PlayerPrefs.SetString ("SaveState", s);
		Debug.Log ("save");

	}

	public void LoadState(Scene s, LoadSceneMode load)
	{
		if (!PlayerPrefs.HasKey ("SaveState"))
			return; //If no save is found, return without loading
		string[] data = PlayerPrefs.GetString ("SaveState").Split('|');
		money = int.Parse(data [0]);
		experience = int.Parse(data [1]);
		Debug.Log ("load");
	}
}
