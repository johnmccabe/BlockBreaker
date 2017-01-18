using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		print ("Trigger");
	}

	void OnCollisionEnter2D (Collision2D collider) {
		print ("Collision");
	}
}
