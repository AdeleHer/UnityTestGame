using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour {

    public Text scoreText;
    // Use this for initialization
    void Start () {
        scoreText.text = "總分: " + GameManager.score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
