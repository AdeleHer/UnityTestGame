using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void StartGame() {
        SceneManager.LoadScene("SampleScene");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
