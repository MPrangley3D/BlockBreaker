using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	static SoundManager instance = null;
	
	void Awake()
	{
		if(instance != null)
		{
			Destroy (gameObject);
			print ("Killing Duplicate BG Music Player");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
