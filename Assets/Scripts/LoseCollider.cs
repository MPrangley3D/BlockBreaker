﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour 
{
	//public AudioClip lose;
	private LevelManager levelManager;
	
	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnTriggerEnter2D(Collider2D trigger)
	{
		print ("Trigger");
		levelManager.LoadLevel ("Lose");
		//AudioSource.PlayClipAtPoint (lose,transform.position);
	}	
	
	
}