using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollisionManager : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("rocket"))
        {
            Player.isDead = true;
        }
    }
}
