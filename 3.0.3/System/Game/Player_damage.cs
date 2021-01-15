using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_damage : MonoBehaviour
{
    [SerializeField]
    Combo script2;
    [SerializeField]
    SpriteRenderer HeartObj1;
    [SerializeField]
    SpriteRenderer HeartObj2;
    [SerializeField]
    SpriteRenderer HeartObj3;
    [SerializeField]
    AudioSource audioSources;
    [SerializeField]
    Renderer ren;
    int damage_cnt = 0;                 //ダメージを受けた回数
    int vibration_time;             //バイブレーションの実行時間
    public GameObject TextPlus;
    public GameObject ComboTextPlus;
    public AudioClip sound02;
    public bool combo_score_f; //コンボが失敗したかの判定用のフラグ
    bool time_f = false;
    public bool hit_check1 = false;  //敵と自分が当たった時のフラグ（ここ変更点）
    public bool space_check = false;
    Color alpha;
    int time_cnt;
    public float interval;   // 点滅周期
    private float nextTime;
    int you_score;
    int you_highScore;
    string Scene_name;
    bool bless_ff;
    // Start is called before the first frame update
    void Start()
    {
        vibration_time = 0;
        nextTime = Time.time;
        bless_ff = false;
    }

    // Update is called once per frame
    void Update()
    {
        bless_ff = Bless.Get_Bless_f();
        if(bless_ff == true)
        {
            //敵と自分が当たった（ダメージを受けた時）
            hit_check1 = true;
            time_f = true;
            damage_cnt++;
            //sound02.PlayOneShot(sound02.clip);
            audioSources.PlayOneShot(sound02);
            combo_score_f = true;
            TextPlus.SetActive(true);
            ComboTextPlus.SetActive(true);
            script2.Combo_Score();
            if (damage_cnt == 1)
            {
                HeartObj1.color = new Color(0, 0, 0, alpha.a);
            }
            if (damage_cnt == 2)
            {
                HeartObj2.color = new Color(0, 0, 0, alpha.a);
            }
            if (damage_cnt >= 3)
            {
                you_score = Score.getScore();
                you_highScore = Score.GetHighScore();
                // スコアを保存する
                PlayerPrefs.SetInt("Score", you_score);
                Scene_name = PlayerPrefs.GetString("Scene_name");
                if (Scene_name == "Stage01")
                {
                    PlayerPrefs.SetInt("highScore1", you_highScore);
                }
                if (Scene_name == "Stage02")
                {
                    PlayerPrefs.SetInt("highScore2", you_highScore);
                }
                if (Scene_name == "Stage03")
                {
                    PlayerPrefs.SetInt("highScore3", you_highScore);
                }
                PlayerPrefs.Save();
                HeartObj3.color = new Color(0, 0, 0, alpha.a);
                SceneManager.LoadScene("GameOver");
                //SceneManager.LoadScene("Reward");
            }
        }
        if (hit_check1 == true)
        {//敵に当たった時、点滅処理
            if (Time.time > nextTime && time_cnt < 40 && time_f == true)
            {
                ren.enabled = !ren.enabled;
                nextTime += interval;
                time_cnt++;
                if (time_cnt == 40)
                {
                    time_cnt = 0;
                    time_f = false;
                    hit_check1 = false;
                    vibration_time = 0;
                }
            }
        }
        if(hit_check1 == false)
        {
            combo_score_f = false;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //--------------------------
        if (c.tag == "Skeleton_damage_hit" && space_check == false || c.tag == "fire" && space_check == false)
        { //敵と自分が当たった（ダメージを受けた時）
            hit_check1 = true;
            time_f = true;
            damage_cnt++;
            //sound02.PlayOneShot(sound02.clip);
            audioSources.PlayOneShot(sound02);
            combo_score_f = true;
            TextPlus.SetActive(true);
            ComboTextPlus.SetActive(true);
            script2.Combo_Score();
            if (damage_cnt == 1)
            {
                HeartObj1.color = new Color(0, 0, 0, alpha.a);
            }
            if (damage_cnt == 2)
            {
                HeartObj2.color = new Color(0, 0, 0, alpha.a);
            }
            if (damage_cnt >= 3)
            {
                you_score = Score.getScore();
                you_highScore = Score.GetHighScore();
                // スコアを保存する
                PlayerPrefs.SetInt("Score", you_score);
                Scene_name = PlayerPrefs.GetString("Scene_name");
                if (Scene_name == "Stage01")
                {
                    PlayerPrefs.SetInt("highScore1", you_highScore);
                }
                if (Scene_name == "Stage02")
                {
                    PlayerPrefs.SetInt("highScore2", you_highScore);
                }
                if (Scene_name == "Stage03")
                {
                    PlayerPrefs.SetInt("highScore3", you_highScore);
                }
                PlayerPrefs.Save();
                HeartObj3.color = new Color(0, 0, 0, alpha.a);
                SceneManager.LoadScene("GameOver");
                //SceneManager.LoadScene("Reward");
            }
        }
    }
}
