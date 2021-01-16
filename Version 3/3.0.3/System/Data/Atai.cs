using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atai : MonoBehaviour
{
    public GameObject atai_object = null;   //Textオブジェクト
    public static int atai_num = 0;    //値変数
    int coin_num;
    [SerializeField]
    Text atai_text;
    int atai_sum1;
    int atai_sum2;
    int atai_sum3;
    int atai_sum4;
    int atai_sum5;
    int atai_sum6;
    int atai_sum7;
    int atai_sum8;
    // Start is called before the first frame update
    void Start()
    {
        coin_num = PlayerPrefs.GetInt("coin_num", 0);   //所持金
    }

    // Update is called once per frame
    void Update()
    {
        atai_sum1 = BraveSmash.Atai2();
        atai_sum2 = AeroLast.Atai2();
        atai_sum3 = Boneboomerang.Atai2();
        atai_sum4 = Superspeedplayback.Atai2();
        atai_sum5 = Barrier.Atai2();
        atai_sum6 = Superhumanization.Atai2();
        atai_sum7 = Invisible.Atai2();
        atai_sum8 = Revenge.Atai2();

        /*
        Debug.Log(atai_sum1);
        Debug.Log(atai_sum2);
        Debug.Log(atai_sum3);
        Debug.Log(atai_sum4);
        Debug.Log(atai_sum5);
        Debug.Log(atai_sum6);
        Debug.Log(atai_sum7);
        Debug.Log(atai_sum8);
        */
        atai_num = atai_sum1 + atai_sum2 + atai_sum3 + atai_sum4 + atai_sum5 + atai_sum6 + atai_sum7 + atai_sum8;
        //オブジェクトからTextコンポーネントを取得
        //Text atai_text = atai_object.GetComponent<Text>();
        //テキストの表示を入れ替える
        if (atai_num >= 0)
        {
            atai_text.text = atai_num + " / " + coin_num + "枚";
        }
    }
    public void On_Click_atai()
    {
        coin_num -= atai_num;
        atai_num = 0;
        PlayerPrefs.SetInt("coin_num", coin_num);
        PlayerPrefs.Save();
    }

    public static int Sum_Atai()
    {
        return atai_num;
    }
}