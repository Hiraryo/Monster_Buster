﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn_skel4_1 : MonoBehaviour {
    
    public GameObject obj;
    int var;
    int cnt;
    public float interval;
    public static double skeleton_count = 10;
    public bool warning_f1;
    GameObject GameStart;
    GameStartText script;

    bool GameStart_f;

    //GameObject d_016;
    //Boss_Endless script2;

    bool Boss_Endless_f1;

    public bool Endless_f1; //スケルトンが一定数出現すると、ボスを出現させる為に一旦停止フラグ(false : 一定数に達していない, true : 一定数に達した為スケルトン出現を停止)
    int stage_lv;
    public static int load_cnt;
    public GameObject parent;
    // Use this for initialization
    void Start () 
    {
        load_cnt = Set_Load_Cnt();
        stage_lv = GameStartText.Set_Stage_Lv();
        skeleton_count = Skel4_num();
        /*
        if (load_cnt == 0)
        {
            skeleton_count = 10;
            load_cnt = 1;
        }
        if (load_cnt == 1)
        {
            skeleton_count = Skel4_num();
        }
        */
        skeleton_count += stage_lv * 0.1;
        GameStart = GameObject.Find("GameStart");
        script = GameStart.GetComponent<GameStartText>();
        warning_f1 = false;
        cnt = 0;
        InvokeRepeating("SpawnObj", 0.1f, interval);
        //d_016 = GameObject.Find("d_016");
        //script2 = d_016.GetComponent<Boss_Endless>();
        Endless_f1 = false;
    }

    // Update is called once per frame
    void SpawnObj()
    {
        //if (GameStart_f == true && Boss_Endless_f1 == true)
        if (GameStart_f == true && Endless_f1 == false)
        {
            var = Random.Range(3, 5);
            if (var == 4)
            {
                Update();
                cnt++;
                Instantiate(obj, transform.position, Quaternion.identity, parent.transform);
            }
        }
    }
    void Update()
    {
        GameStart_f = script.GS_f;
        //Boss_Endless_f1 = script2.Boss_Endless_f;
        if (cnt >= skeleton_count)   //ここの値を変えると、それぞれのスケルトンの出てくる数を制限可能。(今はそれぞれのスケルトンが5体まで出て、その後は出てこない)
        {
            warning_f1 = true;
            Endless_f1 = true;
            //Destroy(gameObject);
        }
    }

    public static double Skel4_num()
    {
        return skeleton_count;
    }
    public static int Set_Load_Cnt()
    {
        return load_cnt;
    }
}
	

