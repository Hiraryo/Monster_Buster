using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_damage_Endless : MonoBehaviour
{
    [SerializeField]
    Combo_Endless script2;
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
    //public static int life_cnt = 3;   //現在のハートの数
    int skill;
    public GameObject HeartObj4;
    public GameObject HeartObj5;
    public GameObject HeartObj6;
    public int life_reset = 0;
    int you_score;
    int you_highScore;
    public static int life_num;
    bool Heart_Add = false;
    public static bool Heart_del;
    bool bless_ff;
    // Start is called before the first frame update
    void Start()
    {
        vibration_time = 0;
        nextTime = Time.time;
        //life = PlayerPrefs.GetInt("Heart", 3);
        skill = PlayerPrefs.GetInt("yukou_button_number", 0);
        if (skill != 4)
        {
            HeartObj4.SetActive(false);
            HeartObj5.SetActive(false);
            HeartObj6.SetActive(false);
        }
        life_reset = PlayerPrefs.GetInt("play_cnt", 0);
        if (life_reset == 0)//エンドレス初回の時
        {
            life_reset = Quest_Endless.Set_life_reset();   
            Debug.Log("life_reset = " + life_reset);
            life_num = 3;
            PlayerPrefs.SetInt("Heart", life_num);
            PlayerPrefs.Save();
        }
        if(life_reset >= 1)//2回目以降の時
        {
            life_num = PlayerPrefs.GetInt("Heart", 3);
        }
        //PlayerPrefs.SetInt("life_reset", life_reset);
        //PlayerPrefs.Save();
        bless_ff = false;
    }

    // Update is called once per frame
    void Update()
    {
        bless_ff = Bless.Get_Bless_f();
        Heart_Add = Skill_Button.GetHeart_Add();
        if(Heart_Add == true)
        {
            GetHeartDate();
            Heart_Add = false;
        }
        Heart_del = false;
        //life_num = Skill_Button.GetHeart();
        Debug.Log("life_num = " + life_num);
        //life_cnt = Skill_Button.HP_restart();
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
        if (skill != 4)
        {
            if (life_num == 1)
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha.a);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha.a);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
            if (life_num == 2)
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha.a);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
            if (life_num == 3)  //スタート時
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
        }
        if (skill == 4)
        {
            if (life_num == 1)
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
            }
            if (life_num == 2)
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
            }
            if (life_num == 3)  //スタート時
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
            }
            if (life_num == 4)
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
            }
            if (life_num == 5)
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
            }
            if (life_num == 6)
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
        }
        if (hit_check1 == false)
        {
            combo_score_f = false;
        }
        if (bless_ff == true)
        {
            GetHeartDate();
            if (life_num > 0)
            {
                life_num -= 1;
            }
            SaveHeartDate();
            Heart_del = true;
            hit_check1 = true;
            time_f = true;
            damage_cnt++;
            //sound02.PlayOneShot(sound02.clip);
            audioSources.PlayOneShot(sound02);
            combo_score_f = true;
            TextPlus.SetActive(true);
            ComboTextPlus.SetActive(true);
            script2.Combo_Score();
            if (life_num <= 0)
            {
                you_score = Score_Endless.getScore();
                you_highScore = Score_Endless.gethighScore();
                // スコアを保存する
                PlayerPrefs.SetInt("Score", you_score);
                PlayerPrefs.SetInt("highScore", you_highScore);
                PlayerPrefs.Save();
                SceneManager.LoadScene("GameOver_Endless");
                //SceneManager.LoadScene("Reward");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //--------------------------
        if (c.tag == "Skeleton_damage_hit" && space_check == false || c.tag == "fire" && space_check == false)
        { //敵と自分が当たった（ダメージを受けた時）
            GetHeartDate();
            if (life_num > 0)
            {
                life_num -= 1;
            }
            SaveHeartDate();
            Heart_del = true;
            hit_check1 = true;
            time_f = true;
            damage_cnt++;
            //sound02.PlayOneShot(sound02.clip);
            audioSources.PlayOneShot(sound02);
            combo_score_f = true;
            TextPlus.SetActive(true);
            ComboTextPlus.SetActive(true);
            script2.Combo_Score();
            if (life_num <= 0)
            {
                you_score = Score_Endless.getScore();
                you_highScore = Score_Endless.gethighScore();
                // スコアを保存する
                PlayerPrefs.SetInt("Score", you_score);
                PlayerPrefs.SetInt("highScore", you_highScore);
                PlayerPrefs.Save();
                SceneManager.LoadScene("GameOver_Endless");
                //SceneManager.LoadScene("Reward");
            }
        }
    }
    
    public static int GetLife()
    {
        return life_num;
    }

    public static bool GetHeartDel()
    {
        return Heart_del;
    }

    public void SaveHeartDate()
    {
        PlayerPrefs.SetInt("Heart", life_num);
        PlayerPrefs.Save();
    }
    public void GetHeartDate()
    {
        life_num = PlayerPrefs.GetInt("Heart", 3);
    }
}
