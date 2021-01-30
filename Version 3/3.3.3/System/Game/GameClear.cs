using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameClear : MonoBehaviour {

    bool text_f;
    int cnt;
    float time;
    int score;
    int you_highScore;

    public GameObject canvas;
    public Score scoreScript;
    public GameObject Score_Label;
    public GameObject Coin_Label;
    // スコアを表示する
    public Text scoreText_Result;
    // コインを表示する
    public Text coinText_Result;
    public GameObject Massage_Box;
    public GameObject next_text;
    bool button_f;
    bool next_scene;
    int score_zero;
    int coin_zero;
    int coin_num;   //所持金
    [SerializeField]
    Text bairitu_text;
    int bairitu;
    string Scene_name;
    // Use this for initialization
    void Start () {
        text_f = false;
        cnt = 0;
        time = 0;
        coin_num = PlayerPrefs.GetInt("coin_num", 0);
        score = Score.getScore();
        //score = 1450;   //デバック用
        score_zero = 0;
        coin_zero = 0;
        canvas.SetActive(false);
        Massage_Box.SetActive(false);
        next_text.SetActive(false);
        button_f = false;
        next_scene = false;
        //AdMobManager.instance.DestroyBanner();
        //AdMobManager.instance.RequestInterstitial();
        you_highScore = Score.GetHighScore();
        Scene_name = PlayerPrefs.GetString("Scene_name");
        if (Scene_name  == "Stage01")
        {
            PlayerPrefs.SetInt("highScore1", you_highScore);
            bairitu = 10;
        }
        if (Scene_name == "Stage02")
        {
            PlayerPrefs.SetInt("highScore2", you_highScore);
            bairitu = 30;
        }
        if (Scene_name == "Stage03")
        {
            PlayerPrefs.SetInt("highScore3", you_highScore);
            bairitu = 50;
        }
        PlayerPrefs.Save();
    }

	// Update is called once per frame
	void Update () {
        Vector2 pos = transform.localScale;

        if (cnt < 2){
            if (pos.x <= 10 && pos.x > -10 && text_f == false)
            {
                pos.x -= 1.0f;
            }

            if (pos.x >= -10 && pos.x < 10 && text_f == true)
            {
                pos.x += 1.0f;
            }
        }
        if (pos.x >= 10){
            text_f = false;
            cnt++;
        }
        if (pos.x <= -10){
            text_f = true;
        }
        transform.localScale = pos;

        if (cnt >= 2){
            time += Time.deltaTime;
            if (time >= 2.0f){
                canvas.SetActive(true);
                Massage_Box.SetActive(true);
                Massage_Box.transform.DOScale(endValue: new Vector2(7f, 4f), duration: 1.0f);
                //ウィンドウが最大まで大きくなった時
                if (button_f == false)
                {
                    if (Massage_Box.transform.localScale.x >= 6.0 && Massage_Box.transform.localScale.y >= 3.0)
                    {
                        Score_Label.transform.DOLocalMove(endValue: new Vector2(1, 0), duration: 1.0f);
                        // スコアを表示する
                        scoreText_Result.text = score_zero.ToString();
                        //Debug.Log(Score_Label.transform.localPosition.x);
                        if (Score_Label.transform.localPosition.x <= 3.0)
                        {
                            if (score_zero != score)
                            {
                                score_zero += 5;
                            }
                        }
                        //カウントが獲得スコアに達した時
                        if (score_zero == score)
                        {
                            Coin_Label.transform.DOLocalMove(endValue: new Vector2(1, 0), duration: 1.0f);
                            // スコアを表示する
                            coinText_Result.text = coin_zero.ToString();
                            bairitu_text.text = "x " + bairitu;
                            if (Coin_Label.transform.localPosition.x <= 3.0)
                            {
                                if (coin_zero != score * bairitu)
                                {
                                    coin_zero += 50;
                                }
                            }
                            if (coin_zero == score * bairitu)
                            {
                                next_text.SetActive(true);
                                next_scene = true;
                            }
                        }
                    }
                }
                if (button_f == true)
                {
                    bairitu_text.text = "x " + bairitu;
                    scoreText_Result.text = score_zero.ToString();
                    Score_Label.transform.localPosition = new Vector2(1,0);
                    coinText_Result.text = coin_zero.ToString();
                    Coin_Label.transform.localPosition = new Vector2(1, 0);
                    score_zero = score;
                    coin_zero = score * bairitu;
                    next_text.SetActive(true);
                    next_scene = true;
                }
            }
        }
    }

    public void OnClick()
    {
        coin_num += coin_zero;
        PlayerPrefs.SetInt("coin_num", coin_num);
        PlayerPrefs.Save();
        Debug.Log("OK");
        button_f = true;
        if (next_scene == true)
        {
            //AdMobManager.instance.viewInterstitial();
            SceneManager.LoadScene("Home");
        }
    }
}
