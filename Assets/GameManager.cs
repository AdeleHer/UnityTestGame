using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public static int score;
    public static int oldScore;
    public Text scoreText;
    public GameObject boom;

    // Use this for initialization
    void Start () {
        score = 0;
        oldScore = 0;
        boom.SetActive(false);
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isDead)
        {
            boom.SetActive(true);
            boom.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            player.SetActive(false);
            CameraManager.downspeed = 0;
            sleep(5);
            SceneManager.LoadScene("GameOver");
        }
        if (oldScore < score) {
            UpdateScore();
            oldScore = score;
        }
    }

    IEnumerator sleep(int second) {
        yield return new WaitForSeconds(2);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
