using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Superspeedplayback : MonoBehaviour
{
    public static int atai_num = 0;    //値変数
    public int skil_num;    //1Lv上げるのに必要なコイン枚数
    int coin_num;
    int lv = 1;
    int mae_lv = 1;
    bool push = false;
    bool push2 = false;
    float time = 0;
    int sum_coin = 0;
    //[SerializeField]
    //Text atai_text;
    [SerializeField]
    Text skil_lv;
    [SerializeField]
    Text next_coin;
    public int bairitu;
    int next_coin_num = 0;
    string coin_txt_je;
    // Start is called before the first frame update
    void Start()
    {
        atai_num = 0;
        coin_num = PlayerPrefs.GetInt("coin_num", 0);   //所持金
        lv = PlayerPrefs.GetInt("lv_4", 1);
        mae_lv = lv;
        if (Application.systemLanguage == SystemLanguage.Japanese)  //英語の時
        {
            coin_txt_je = "次のレベルまでに必要なコイン枚数：";
        }
        /*
        if (Application.systemLanguage != SystemLanguage.Japanese)  //日本語の時
        {
            coin_txt_je = "次のレベルまでに必要なコイン枚数：";
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        coin_num = PlayerPrefs.GetInt("coin_num", 0);   //所持金
        sum_coin = Atai.atai_num;
        time += Time.deltaTime;
        next_coin_num = (lv + 1) * bairitu;
        next_coin.text = coin_txt_je + next_coin_num + "枚";
        if (push && time >= 1.5f)
        {
            if (lv < 100 && sum_coin + next_coin_num < coin_num)
            {
                next_coin_num = (lv + 1) * bairitu;
                next_coin.text = coin_txt_je + next_coin_num + "枚";
                atai_num += next_coin_num;  //変更
                lv++;
                //skil_num += bairitu;
            }
            /*
            //所持金を超えた場合、超過分を引く
            if (sum_coin > coin_num)
            {
                atai_num -= skil_num;
                lv--;
            }
            */
        }
        if (push2 && time >= 1.5f)
        {
            if (mae_lv < lv)
            {
                next_coin_num = lv * bairitu;
                next_coin.text = coin_txt_je + next_coin_num + "枚";
                //skil_num -= bairitu;
                lv--;
                atai_num -= next_coin_num;  //変更
            }
        }
        //テキストの表示を入れ替える
        if (lv == 100)
        {
            skil_lv.text = "MAX";
            next_coin.text = "";
        }
        else
        {
            skil_lv.text = "Lv. " + lv + " / 100";
        }

    }

    public void On_Click_atai()
    {
        coin_num -= atai_num;
        atai_num = 0;
        //PlayerPrefs.SetInt("coin_num", coin_num);
        PlayerPrefs.SetInt("lv_4", lv);
        PlayerPrefs.Save();
        mae_lv = lv;
    }

    public void On_Click_Plus1_Down()
    {
        push = true;
        if (lv < 100 && sum_coin + next_coin_num < coin_num)
        {
            next_coin_num = (lv + 1) * bairitu;
            next_coin.text = coin_txt_je + next_coin_num + "枚";
            atai_num += next_coin_num;  //変更
            lv++;
            //skil_num += bairitu;
        }
        /*
        //所持金を超えた場合、超過分を引く
        if (sum_coin > coin_num)
        {
            atai_num -= skil_num;
            lv--;
        }
        */


    }
    public void On_Click_Plus1_Up()
    {
        push = false;
        time = 0f;
    }
    public void On_Click_minus1_Down()
    {
        push2 = true;
        if (mae_lv < lv)
        {
            next_coin_num = lv * bairitu;
            next_coin.text = coin_txt_je + next_coin_num + "枚";
            //skil_num -= bairitu;
            lv--;
            atai_num -= next_coin_num;  //変更
        }
    }
    public void On_Click_minus1_Up()
    {
        push2 = false;
        time = 0f;
    }
    public static int Atai2()
    {
        return atai_num;
    }
}
