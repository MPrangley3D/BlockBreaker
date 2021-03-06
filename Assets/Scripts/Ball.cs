﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	private Paddle paddle;	
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () 
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!hasStarted)
		{
			
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if(Input.GetMouseButtonDown(0))
			{
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (Random.Range (-2f, 2f), 10f);
			} 
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 tweak = new Vector2 (Random.Range (0f, 1f), Random.Range (0f, 1f));
		this.rigidbody2D.velocity += tweak; 
		
		if(hasStarted)
		{
			if(collision.gameObject.tag == "Paddle")
			{
				if(Input.GetMouseButton(0))
				{
					print("GRAB!");
					hasStarted = false;
				}
			}
		}
	}
	
}