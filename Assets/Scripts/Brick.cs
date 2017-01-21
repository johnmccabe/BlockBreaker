using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;

	private bool isBreakable;
	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D (Collision2D collider)
	{
//		bool isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed ();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites[spriteIndex];
		}
	}
}
