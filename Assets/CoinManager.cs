using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("rocket"))
        {
            GameManager.score += 20;
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
