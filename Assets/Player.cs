using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float forceX;    //水平推力
    Rigidbody2D playerRigidBody2D;
    readonly float toLeft = -0.2f;
    readonly float toRight = 0.2f;
    readonly float stop = 0;
    float directionX;

    public static bool isDead;

	// Use this for initialization
	void Start () {
        isDead = false;
        playerRigidBody2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
        //     Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0));
        //     //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        //     playerRigidBody2D.transform.position = new Vector3(touchedPos.x, playerRigidBody2D.transform.position.y, 0);
        // }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
           directionX = toLeft;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
           directionX = toRight;
        }
        else {
           directionX = stop;
        }
        Vector2 newDirection = new Vector2(directionX, 0);
        playerRigidBody2D.AddForce(newDirection * forceX);
    }
}
