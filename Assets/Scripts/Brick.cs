using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;

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
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			Debug.Log (breakableCount);
			levelManager.BrickDestroyed ();
			PuffSmoke ();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void PuffSmoke(){
		GameObject smokePuff = Object.Instantiate (smoke, this.transform.position, Quaternion.identity) as GameObject;
		ParticleSystem ps = smokePuff.GetComponent<ParticleSystem> ();
		var main = ps.main;
		main.startColor = this.GetComponent<SpriteRenderer> ().color;
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Sprite at spriteIndex: " + spriteIndex + " not found");
		}
	}
}
