﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour 
{
    
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //得点テキスト
    private GameObject scoreText;
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        this.scoreText.GetComponent<Text>().text = "Score:" + score;

    }

    private void OnCollisionEnter(Collision collision)
    {
        string yourTag = collision.gameObject.tag;
        if (yourTag == "SmallStarTag")
        {
            score += 10;
        }
        else if (yourTag == "LargeStarTag")
        {
            score += 50;
        }
        else if (yourTag == "SmallCloudTag")
        {
            score += 20;
        }
        else if (yourTag == "LargeCloudTag")
        {
            score += 100;
        }
    }
    
}