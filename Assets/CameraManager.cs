using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {

    public static float downspeed;
	// Use this for initialization
	void Start () {
        downspeed = 2;
        InvokeRepeating("SpeedUp", 10, 1);
    }

    void SpeedUp() {
        if (downspeed < 5)
        {
            downspeed = (float)(downspeed + 0.2);
        }
    }
	
	// 預設每秒執行50次
	void FixedUpdate () {
        transform.Translate(0, downspeed * Time.deltaTime, 0);
        if (Player.isDead) {
            CancelInvoke("SpeedUp");
        }
	}
}
