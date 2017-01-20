using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int maxHits;

	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D (Collision2D collider) {
		timesHit++;
		// TODO remove when brick removal win implemented
		SimulateWin();
	}

	void SimulateWin ()
	{
		levelManager.LoadNextLevel();
	}
}
