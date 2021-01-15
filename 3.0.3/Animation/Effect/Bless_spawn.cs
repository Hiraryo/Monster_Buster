using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bless_spawn : MonoBehaviour {
    [SerializeField]
    Warning script1;
    public GameObject Bless;
    public GameObject flash;
    public float interval;
    int count2;
    float time;

    GameObject Warning;
    //Warning script1;

    bool d_f;
    bool flash_f;
    // Use this for initialization
    void Start()
    {
        Warning = GameObject.Find("Warning");
        //script1 = Warning.GetComponent<Warning>();
        InvokeRepeating("_Bless", 0.1f, interval);
        time = 0;
        flash_f = true;
    }

    // Update is called once per frame
    void Update()
    {
        d_f = script1.dragon_f;

        if (flash_f == true){   //ブレスを吐くフラグが立った時
            time += Time.deltaTime; //時間を計測
            flash.SetActive(true);  //目を光らせるエフェクトを表示
        }
        if (time > 1.2f){   //時間が1.2秒以上になった時(ブレスを吐き始める)
            flash.SetActive(false); //目を光らせるエフェクトを非表示
            Bless.SetActive(true);  //ブレスを表示
        }
        if (time > 2.2f){   //時間が2.2秒以上になった時(ブレスを吐くのをやめる)
            Bless.SetActive(false); //ブレスを非表示
            time = 0;   //時間をリセット
            flash_f = false;    //ブレスを吐くフラグを折る
        }
    }
    void _Bless()
    {
        if (d_f == true)
        {
            count2 = Random.Range(0, 5);
            if (count2 == 4)
            {
                Update();
                flash_f = true; //ブレスを吐くフラグを立てる
            }
        }
    }
}
