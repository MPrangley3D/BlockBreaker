using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour 
{
	
	public AudioClip boing;
	private bool hasStarted = false;
	public bool autoPlay = false;
	private Ball ball;
	
	void Start()
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	
	void Update () 
	{
		if(!autoPlay)
		{
			MoveWithMouse ();
		}
		else
		{
			Autoplay();
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			hasStarted = true;
		} 
		
		if(Input.GetKeyDown("space"))
		{	
			if(!autoPlay)
			{
				autoPlay = true;
			}
			else
			{
				autoPlay = false;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(hasStarted)
		{
			AudioSource.PlayClipAtPoint (boing,transform.position);	
		}
	}
	
	void MoveWithMouse()
	{	
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x/Screen.width*16;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 1f, 15f);
		this.transform.position = paddlePos;
	}	
	
	void Autoplay()
	{	
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		Vector3 BallPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (BallPos.x, 1f, 15f);
		this.transform.position = paddlePos;
	}	
}