using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    readonly float leftBorder = -3; //左邊界
    readonly float rightBorder = 3; //右邊界
    readonly float initPositionY = 0;
    readonly int MAX_GROUND_COUNT = 10; //最大地板數量
    readonly int MIN_GROUND_UPON_PLAYER = 5;
    static int groundNumber = -1;
    [Range(2,6)]public float spacingY;
    public List<Transform> grounds;
    public List<List<Transform>> coins;
    public Transform player;


	// Use this for initialization
	void Start () {
        grounds = new List<Transform>();
        coins = new List<List<Transform>>();
        for (int i = 0; i < MAX_GROUND_COUNT; i++)
        {
            SpwanGround();
        }
	}
    public void ControlSpawnGround() {
        int groundsCountUponPlayer = 0;
        foreach (Transform ground in grounds) {
            if (ground.position.y > player.transform.position.y) {
                groundsCountUponPlayer++;
            }
        }
        if (groundsCountUponPlayer < MIN_GROUND_UPON_PLAYER)
        {
            SpwanGround();
            ControlGroundCount();
        }
    }
    public void ControlGroundCount() {  //控制地板數量
        if (grounds.Count > MAX_GROUND_COUNT)
        {
            Destroy(grounds[0].gameObject);
            grounds.RemoveAt(0);
            List<Transform> coinGroup = coins[0];
            foreach (Transform c in coinGroup) {
                Destroy(c.gameObject);
            }
            coins.RemoveAt(0);
        }
    }

    float NewGroundPositionX() {
        if (grounds.Count == 0)
        {
            return 3;
        }
        return Random.Range(leftBorder, rightBorder);
    }

    float NewGroundPositionY() {
        if(grounds.Count == 0)
        {
            return initPositionY;
        }
        int lowerIndex = grounds.Count - 1;
        return grounds[lowerIndex].transform.position.y + spacingY;
    }


    void SpwanGround() {
        float y = NewGroundPositionY();
        GameObject newGround = Instantiate(Resources.Load<GameObject>("Block"));
        newGround.transform.position = new Vector3(NewGroundPositionX(), NewGroundPositionY(), 0);
        grounds.Add(newGround.transform);
        float c_y = (float)(y + 1.5);
        SpwanCoin(c_y);
    }

    void SpwanCoin(float y) {
        List<Transform> tmp_list = new List<Transform>();
        for (int i = 0; i < 6; i++)
        {
            bool isAdd = (Random.value > 0.5f);

            if (isAdd)
            {
                float x = (float)(3 - i - 0.5);
                GameObject newCoin = Instantiate(Resources.Load<GameObject>("coin"));
                newCoin.transform.position = new Vector3(x, y, 0);
                tmp_list.Add(newCoin.transform);
            }
        }
        coins.Add(tmp_list);
    }
	
	// Update is called once per frame
	void Update () {
        ControlSpawnGround();
    }
}
