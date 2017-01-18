using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	// You can now drop the LevelManager GameObject in the UI
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		print ("Trigger");
		levelManager.LoadLevel ("Win");

	}

	void OnCollisionEnter2D (Collision2D collider) {
		print ("Collision");
	}
}
