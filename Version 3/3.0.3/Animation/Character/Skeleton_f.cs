﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton_f : MonoBehaviour {
    float move_x = -5.0f;
    Collider2D s_Object;
   
    bool space_check_f = false;
    //public Rigidbody2D rb;
    int count;

    GameObject c_wait;   //skeleton_fが入る変数
    Move script;                //moveの名前のスクリプトが入る変数

    private AudioSource sound01;
    SpriteRenderer MainSpriteRenderer;
    public Sprite DebrisbySprite;
    float debris_time;
    int player_hit_f = 0;
    public static bool combo_skeleton_add1 = false;
    // Use this for initialization
    void Start () {
        c_wait = GameObject.Find("c_wait");   //c_waitをオブジェクトの名前から取得して変数に格納する
        script = c_wait.GetComponent<Move>();        //c_waitの中にあるmoveを取得して変数に格納する
        sound01 = GetComponent<AudioSource>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        debris_time = 0;
        count = 0;
    }
	
	// Update is called once per frame
	void Update () {
        combo_skeleton_add1 = false;
        if (count < 3)
        {
            transform.Translate(move_x, 0, 0);
        }
        space_check_f = script.space_check;    //新しく変数を宣言してその中にmoveの変数space_checkを代入する。
        //--------------------------
        if (!GetComponent<SpriteRenderer>().isVisible && transform.position.x <= 0)  
        {
            Destroy(gameObject);
        }
        //--------------------------

        if (count >= 3){
            Destroy(GetComponent<Animator>());
            MainSpriteRenderer.sprite = DebrisbySprite;
            debris_time += Time.deltaTime;
            if (debris_time >= 2.0f)
            {
                debris_time = 0;
                Destroy(gameObject);
            }
        }

    }


    void OnTriggerStay2D(Collider2D c)
    {
        if (c.tag == "Player" && space_check_f == true) //敵にダメージを与えた時
        {
            s_Object = GetComponent<Collider2D>();
            s_Object.isTrigger = false;
            if (count < 3)
            {
                move_x = 5.0f;
            }
            player_hit_f++;
            if (player_hit_f == 1 && count < 3)
            {
                Invoke("Skeske", 1);
                sound01.PlayOneShot(sound01.clip);
                combo_skeleton_add1 = true;
            }
        }
        if (c.tag == "Super_Shot")
        {
            //sound01.PlayOneShot(sound01.clip);
            FindObjectOfType<Score>().AddPoint(20);
            count = 3;
        }
    }

    void Skeske() {
        move_x = -5.0f;
        s_Object.isTrigger = true;
        space_check_f = false;
        count = count + 1;
        player_hit_f = 0;
        if (count >= 3) {
            FindObjectOfType<Score>().AddPoint(20);
        }
    }

    public static bool Get_Combo1()
    {
        return combo_skeleton_add1;
    }
}
