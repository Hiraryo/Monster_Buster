using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo_Endless : MonoBehaviour {

    [SerializeField]
    Player_damage_Endless script;
    // スコアを表示する
    public Text comboText;
    // スコア
    public static int combo;

    GameObject damage_hit;   //Canvasが入る変数
    //Player_damage_Endless script;                //moveの名前のスクリプトが入る変数
    bool combo_point;
    public ParticleSystem Combo_10Hits;
    public GameObject TextPlus;
    public GameObject ComboTextPlus;
    // Use this for initialization
    void Start () {
        combo = GetCombo();
        Combo_10Hits.Stop();
        damage_hit = GameObject.Find("damage_hit");   //Canvasをオブジェクトの名前から取得して変数に格納する
        //script = damage_hit.GetComponent<Player_damage_Endless>();        //Canvasの中にあるmoveを取得して変数に格納する
    }
	
	// Update is called once per frame
	void Update () {
        comboText.text = combo.ToString();
        combo_point = script.combo_score_f;
        if (combo_point == true)
        {
            combo = 0;
            combo_point = false;
        }
    }

    // ポイントの追加
    public void AddPoint(int point)
    {
        combo = combo + point;
        if (combo % 10 == 0 && combo != 0)
        {
            Combo_10Hits.Play();
            FindObjectOfType<Score_Endless>().AddPoint(100 * (combo / 10));
            FindObjectOfType<Combo_Plus>().AddComboPoint(100 * (combo / 10));
            TextPlus.SetActive(true);
            ComboTextPlus.SetActive(true);
        }
    }

    public void Combo_Score(){
        if (combo >= 50)
        {
            FindObjectOfType<Score_Endless>().AddPoint(100);
            FindObjectOfType<Combo_Plus>().AddComboPoint(100);
        }
        if (combo >= 40 && combo < 50)
        {
            FindObjectOfType<Score_Endless>().AddPoint(80);
            FindObjectOfType<Combo_Plus>().AddComboPoint(80);
        }
        if (combo >= 30 && combo < 40)
        {
            FindObjectOfType<Score_Endless>().AddPoint(60);
            FindObjectOfType<Combo_Plus>().AddComboPoint(60);
        }
        if (combo >= 20 && combo < 30)
        {
            FindObjectOfType<Score_Endless>().AddPoint(40);
            FindObjectOfType<Combo_Plus>().AddComboPoint(40);
        }
        if (combo >= 10 && combo < 20)
        {
            FindObjectOfType<Score_Endless>().AddPoint(20);
            FindObjectOfType<Combo_Plus>().AddComboPoint(20);
        }
        if (combo < 10  && combo > 0)
        {
            FindObjectOfType<Score_Endless>().AddPoint(5);
            FindObjectOfType<Combo_Plus>().AddComboPoint(5);
        }
    }

    public static int GetCombo()
    {
        return combo;
    }
}
