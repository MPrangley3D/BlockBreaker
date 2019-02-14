using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void LoadLevel(string name)
	{
		if(name == "Level_01")
		{
			Application.LoadLevel("Level_01");
		}
		else if(name == "Quit")
		{
			Application.Quit();
		}
		else if(name == "Win")
		{
			Application.LoadLevel("Win");
		}
		else if(name == "Lose")
		{
			Application.LoadLevel("Lose");
		}
		else if(name == "Start")
		{
			Application.LoadLevel("Start");
		}
	}
	
	public void LoadNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel +1);
	}
	
	public void BrickDestroyed()
	{
		if(Brick.brickCount <= 0)
		{
			LoadNextLevel ();
		}
	}
}
