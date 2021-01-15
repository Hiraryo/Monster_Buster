using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo_Plus : MonoBehaviour {

    // スコアに加算するコンボボーナスを表示する
    public Text ComboTextPlus;

    // スコア
    private int comboPlus;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        ComboTextPlus.text = comboPlus.ToString();
    }

    // ポイントの追加
    public void AddComboPoint(int point)
    {
        comboPlus = point;
    }
}
