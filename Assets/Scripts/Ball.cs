﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}

		// Wait for a mouse press to launch
		if ( Input.GetMouseButtonDown(0) ) {
			print("Mouse Clicked, launch ball");
			hasStarted = true;
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
		}
	}

	void OnCollisionEnter2D (Collision2D collider)
	{
		// Impart a random velocity on collision
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.1f), Random.Range(0f, 0.3f));
		if (hasStarted) {
			GetComponent<AudioSource> ().Play ();
			this.GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
