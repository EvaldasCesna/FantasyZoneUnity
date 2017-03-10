using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public string level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            LoadLevel();
        }

	}

     public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }
}
