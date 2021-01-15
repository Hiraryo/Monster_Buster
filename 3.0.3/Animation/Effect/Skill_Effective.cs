using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Effective : MonoBehaviour
{
    public GameObject Yukou_1;
    public GameObject Yukou_2;
    public GameObject Yukou_3;
    public GameObject Yukou_4;
    public GameObject Yukou_5;
    public GameObject Yukou_6;
    public GameObject Yukou_7;
    public GameObject Yukou_8;
    int yukou_button_number = 0;    //初期段階では有効状態なし
    // Start is called before the first frame update
    void Start()
    {
        yukou_button_number = PlayerPrefs.GetInt("yukou_button_number", 0);
        if (yukou_button_number == 0)
        {
            Yukou_1.SetActive(false);
            Yukou_2.SetActive(false);
            Yukou_3.SetActive(false);
            Yukou_4.SetActive(false);
            Yukou_5.SetActive(false);
            Yukou_6.SetActive(false);
            Yukou_7.SetActive(false);
            Yukou_8.SetActive(false);
        }
        if (yukou_button_number == 1)   //ブレイブスマッシュ
        {
            Yukou_1.SetActive(true);
            Yukou_2.SetActive(false);
            Yukou_3.SetActive(false);
            Yukou_4.SetActive(false);
            Yukou_5.SetActive(false);
            Yukou_6.SetActive(false);
            Yukou_7.SetActive(false);
            Yukou_8.SetActive(false);
        }
        if (yukou_button_number == 2)   //エアロストラスト
        {
            Yukou_1.SetActive(false);
            Yukou_2.SetActive(true);
            Yukou_3.SetActive(false);
            Yukou_4.SetActive(false);
            Yukou_5.SetActive(false);
            Yukou_6.SetActive(false);
            Yukou_7.SetActive(false);
            Yukou_8.SetActive(false);
        }
        if (yukou_button_number == 3)   //骨ブーメラン(未使用)
        {
            Yukou_1.SetActive(false);
            Yukou_2.SetActive(false);
            Yukou_3.SetActive(true);
            Yukou_4.SetActive(false);
            Yukou_5.SetActive(false);
            Yukou_6.SetActive(false);
            Yukou_7.SetActive(false);
            Yukou_8.SetActive(false);
        }
        if (yukou_button_number == 4)   //超速再生
        {
            Yukou_1.SetActive(false);
            Yukou_2.SetActive(false);
            Yukou_3.SetActive(false);
            Yukou_4.SetActive(true);
            Yukou_5.SetActive(false);
            Yukou_6.SetActive(false);
            Yukou_7.SetActive(false);
            Yukou_8.SetActive(false);
        }
        if (yukou_button_number == 5)   //バリア(未使用)
        {
            Yukou_1.SetActive(false);
            Yukou_2.SetActive(false);
            Yukou_3.SetActive(false);
            Yukou_4.SetActive(false);
            Yukou_5.SetActive(true);
            Yukou_6.SetActive(false);
            Yukou_7.SetActive(false);
            Yukou_8.SetActive(false);
        }
        if (yukou_button_number == 6)   //超人化
        {
            Yukou_1.SetActive(false);
            Yukou_2.SetActive(false);
            Yukou_3.SetActive(false);
            Yukou_4.SetActive(false);
            Yukou_5.SetActive(false);
            Yukou_6.SetActive(true);
            Yukou_7.SetActive(false);
            Yukou_8.SetActive(false);
        }
        if (yukou_button_number == 7)   //インビジブル
        {
            Yukou_1.SetActive(false);
            Yukou_2.SetActive(false);
            Yukou_3.SetActive(false);
            Yukou_4.SetActive(false);
            Yukou_5.SetActive(false);
            Yukou_6.SetActive(false);
            Yukou_7.SetActive(true);
            Yukou_8.SetActive(false);
        }
        if (yukou_button_number == 8)   //リベンジ
        {
            Yukou_1.SetActive(false);
            Yukou_2.SetActive(false);
            Yukou_3.SetActive(false);
            Yukou_4.SetActive(false);
            Yukou_5.SetActive(false);
            Yukou_6.SetActive(false);
            Yukou_7.SetActive(false);
            Yukou_8.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yukou_button_1()
    {
        yukou_button_number = 1;
        Yukou_1.SetActive(true);
        Yukou_2.SetActive(false);
        Yukou_3.SetActive(false);
        Yukou_4.SetActive(false);
        Yukou_5.SetActive(false);
        Yukou_6.SetActive(false);
        Yukou_7.SetActive(false);
        Yukou_8.SetActive(false);
        PlayerPrefs.SetInt("yukou_button_number", yukou_button_number);
        PlayerPrefs.Save();
    }

    public void Yukou_button_2()
    {
        yukou_button_number = 2;
        Yukou_1.SetActive(false);
        Yukou_2.SetActive(true);
        Yukou_3.SetActive(false);
        Yukou_4.SetActive(false);
        Yukou_5.SetActive(false);
        Yukou_6.SetActive(false);
        Yukou_7.SetActive(false);
        Yukou_8.SetActive(false);
        PlayerPrefs.SetInt("yukou_button_number", yukou_button_number);
        PlayerPrefs.Save();
    }

    public void Yukou_button_3()
    {
        yukou_button_number = 3;
        Yukou_1.SetActive(false);
        Yukou_2.SetActive(false);
        Yukou_3.SetActive(true);
        Yukou_4.SetActive(false);
        Yukou_5.SetActive(false);
        Yukou_6.SetActive(false);
        Yukou_7.SetActive(false);
        Yukou_8.SetActive(false);
        PlayerPrefs.SetInt("yukou_button_number", yukou_button_number);
        PlayerPrefs.Save();
    }

    public void Yukou_button_4()
    {
        yukou_button_number = 4;
        Yukou_1.SetActive(false);
        Yukou_2.SetActive(false);
        Yukou_3.SetActive(false);
        Yukou_4.SetActive(true);
        Yukou_5.SetActive(false);
        Yukou_6.SetActive(false);
        Yukou_7.SetActive(false);
        Yukou_8.SetActive(false);
        PlayerPrefs.SetInt("yukou_button_number", yukou_button_number);
        PlayerPrefs.Save();
    }

    public void Yukou_button_5()
    {
        yukou_button_number = 5;
        Yukou_1.SetActive(false);
        Yukou_2.SetActive(false);
        Yukou_3.SetActive(false);
        Yukou_4.SetActive(false);
        Yukou_5.SetActive(true);
        Yukou_6.SetActive(false);
        Yukou_7.SetActive(false);
        Yukou_8.SetActive(false);
        PlayerPrefs.SetInt("yukou_button_number", yukou_button_number);
        PlayerPrefs.Save();
    }

    public void Yukou_button_6()
    {
        yukou_button_number = 6;
        Yukou_1.SetActive(false);
        Yukou_2.SetActive(false);
        Yukou_3.SetActive(false);
        Yukou_4.SetActive(false);
        Yukou_5.SetActive(false);
        Yukou_6.SetActive(true);
        Yukou_7.SetActive(false);
        Yukou_8.SetActive(false);
        PlayerPrefs.SetInt("yukou_button_number", yukou_button_number);
        PlayerPrefs.Save();
    }

    public void Yukou_button_7()
    {
        yukou_button_number = 7;
        Yukou_1.SetActive(false);
        Yukou_2.SetActive(false);
        Yukou_3.SetActive(false);
        Yukou_4.SetActive(false);
        Yukou_5.SetActive(false);
        Yukou_6.SetActive(false);
        Yukou_7.SetActive(true);
        Yukou_8.SetActive(false);
        PlayerPrefs.SetInt("yukou_button_number", yukou_button_number);
        PlayerPrefs.Save();
    }

    public void Yukou_button_8()
    {
        yukou_button_number = 8;
        Yukou_1.SetActive(false);
        Yukou_2.SetActive(false);
        Yukou_3.SetActive(false);
        Yukou_4.SetActive(false);
        Yukou_5.SetActive(false);
        Yukou_6.SetActive(false);
        Yukou_7.SetActive(false);
        Yukou_8.SetActive(true);
        PlayerPrefs.SetInt("yukou_button_number", yukou_button_number);
        PlayerPrefs.Save();
    }

    public void Yukou_kaijo_button()
    {
        yukou_button_number = 0;
        Yukou_1.SetActive(false);
        Yukou_2.SetActive(false);
        Yukou_3.SetActive(false);
        Yukou_4.SetActive(false);
        Yukou_5.SetActive(false);
        Yukou_6.SetActive(false);
        Yukou_7.SetActive(false);
        Yukou_8.SetActive(false);
        PlayerPrefs.SetInt("yukou_button_number", yukou_button_number);
        PlayerPrefs.Save();
    }
}
