using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{

	private LevelManager levelManager;

	public AudioClip crack;
	public AudioClip invuln;
	public AudioClip kill;
	public int maxHits;
	public int timesHit;
	public Sprite[] hitSprites;
	public static int brickCount = 0;
	private bool isBreakable; 
	
	// Use this for initialization
	void Start () 
	{
		//print (brickCount);
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "Breakable");
		if(isBreakable)
		{
			brickCount++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(isBreakable)
		{
			HandleHits ();
		}
		else
		{
			AudioSource.PlayClipAtPoint (invuln,transform.position);
		}
	}
	
	void HandleHits()
	{
		timesHit++;
		if(timesHit >= maxHits)
		{
			brickCount--;
			Destroy (gameObject);
			levelManager.BrickDestroyed ();
			AudioSource.PlayClipAtPoint (kill,transform.position);
			//print (brickCount);
		}
		else
		{
			LoadSprites();
			AudioSource.PlayClipAtPoint (crack,transform.position);
		}
	}
	
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex])
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			print ("Error: No Sprite to Load!!");
		}
	}
	
	void SimulateWin()
	{
		levelManager.LoadNextLevel();
	}
}
