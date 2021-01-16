using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bless_spawn_Endless : MonoBehaviour {
    public GameObject Bless;
    public GameObject flash;
    public float interval;
    int count2 = 0;
    int count3 = 0;
    int count4 = 0;
    int count5 = 0;
    float time;

    GameObject Warning;
    //Warning3 script1;

    bool d_f;
    bool flash_f;

    //GameObject d_016_1;
    //Boss_Endless script2;



    bool Boss_Destroy_f1;

    int Max_Range_Lv;
    // Use this for initialization
    void Start()
    {
        Warning = GameObject.Find("Warning");
        Max_Range_Lv = GameStartText.Set_Stage_Lv();
        //script1 = Warning.GetComponent<Warning3>();
        InvokeRepeating("_Bless", 0.1f, interval);
        time = 0;
        flash_f = false;
        Bless.SetActive(false);
        d_f = Boss_Endless2.Set_dragon_posOK();
        //d_016_1 = GameObject.Find("d_016");
        //script2 = d_016_1.GetComponent<Boss_Endless>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flash_f == false)
        {
            if(Max_Range_Lv < 101)
            {
                count2 = Random.Range(0, 131 - Max_Range_Lv);
            }
            if(Max_Range_Lv >= 101 && Max_Range_Lv < 126)
            {
                count3 = Random.Range(101,126);
            }
            if(Max_Range_Lv >= 126 && Max_Range_Lv < 130)
            {
                count4 = Random.Range(0, 50);
            }
            if(Max_Range_Lv >= 130)
            {
                count5 = Random.Range(0, 25);
            }
        }
        Debug.Log("count2 = " + count2);
        if (count2 == 1 ||
            count3 == Max_Range_Lv ||
            count4 == 1 || count4 == 2 || count4 == 3 || count4 == 4 ||
            count5 == 1 || count5 == 2 || count5 == 3 || count5 == 4 || count5 == 5 || count5 == 6)
        {
            flash_f = true;
            //ブレスを吐くフラグが立った時
            time += Time.deltaTime; //時間を計測
            flash.SetActive(true);  //目を光らせるエフェクトを表示
        }
        if (time > 1.5f)
        {
            //時間が1.2秒以上になった時(ブレスを吐き始める)
            flash.SetActive(false); //目を光らせるエフェクトを非表示
            Bless.SetActive(true);  //ブレスを表示
        }
        if (time >= 2.2f)
        {
            //時間が2.2秒以上になった時(ブレスを吐くのをやめる)
            Bless.SetActive(false); //ブレスを非表示
            time = 0;   //時間をリセット
            count2 = 0;
            count3 = 0;
            count4 = 0;
            flash_f = false;    //ブレスを吐くフラグを折る
        }
    }
}
