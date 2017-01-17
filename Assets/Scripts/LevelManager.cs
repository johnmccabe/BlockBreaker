﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name) {
		Debug.Log ("Level load requested for: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest () {
		Debug.Log ("QuitRequest called");
		Application.Quit ();
	}

}
