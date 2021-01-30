using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartText : MonoBehaviour {
    public float GS_move_x = 170.0f; //GS = Game Start  //エンドレスは170.0f
    float timer;
    public bool GS_f;
    public GameObject jump_button;
    public GameObject attack_button;
    bool anime_f = false;
    public static int stage_lv;
    private Text stage_LV_Text;
    public static int num;
    public GameObject stage_sound1;
    public GameObject stage_sound2;
    public GameObject stage_sound3;
    public static int load_cnt;
    int Bonus;
    public GameObject Big_Gold_Skeleton;
    public GameObject Nomal_Mode;
    bool Bonus_finish;
    public static int play_cnt;
    int cnt = 0;
    // Use this for initialization
    void Start () {
        load_cnt = PlayerPrefs.GetInt("load_cnt", 0);
        play_cnt = PlayerPrefs.GetInt("play_cnt", 0);
        if (play_cnt >= 1)  //２回目以降のクエストの時
        {
            Bonus = Random.Range(0, 5);
            Debug.Log("1111");
        }
        if(play_cnt == 0)   //初回起動の時
        {
            Bonus = 0;
        }
        Debug.Log("Bonus = " + Bonus + " && play_cnt = " + play_cnt);
        
        //Bonus = Boss_Endless2.Set_Bonus();
        
        Bonus_finish = Big_s_gold.Set_Bonus_END();

        //Bonus = 1;
        if (Bonus == 1)
        {
            Big_Gold_Skeleton.SetActive(true);
            Nomal_Mode.SetActive(false);
            timer = 0;
            GS_f = false;
            jump_button.SetActive(false);
            attack_button.SetActive(false);
            this.stage_LV_Text = this.GetComponent<Text>();
            this.stage_LV_Text.text = "ボーナスチャレンジスタート！";
        }
        if(Bonus != 1)
        {
            Bonus_finish = false;
            
            if(cnt == 0)
            {
                num = Random.Range(0, 3);
                cnt = 1;
            }
            if (num == 0)
            {
                stage_sound1.SetActive(true);
            }
            if (num == 1)
            {
                stage_sound2.SetActive(true);
            }
            if (num == 2)
            {
                stage_sound3.SetActive(true);
            }
            /*
            if (load_cnt == 1)
            {
                stage_lv = Boss_Endless2.Set_Next_Stage_Lv();
            }
            else
            {
                stage_lv = PlayerPrefs.GetInt("Stage_Lv", 100);
                load_cnt = 1;
                PlayerPrefs.SetInt("load_cnt", load_cnt);
            }
            */
            stage_lv = PlayerPrefs.GetInt("Stage_Lv", 1);
            load_cnt = 1;
            PlayerPrefs.SetInt("load_cnt", load_cnt);

            timer = 0;
            GS_f = false;
            jump_button.SetActive(false);
            attack_button.SetActive(false);
            this.stage_LV_Text = this.GetComponent<Text>();
            this.stage_LV_Text.text = "Lv." + stage_lv + " スタート！";
        }
        Debug.Log("get_num = " + num);
    }
	
	// Update is called once per frame
	void Update () {
        
        Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
        if (pos.x > 0){
            pos.x -= GS_move_x;
        }
        if (pos.x <= 0)
        {
            if(anime_f == false)
            {
                GetComponent<TypefaceAnimator>().Play();
                anime_f = true;
            }
            timer += Time.deltaTime;
        }
        if (timer >= 2.0f){
            GS_move_x = 230.0f;
            pos.x -= GS_move_x;
        }
        if (pos.x <= -6000){
            GS_f = true;
            pos.x = -6000;
            jump_button.SetActive(true);
            attack_button.SetActive(true);
        }
        GetComponent<RectTransform>().anchoredPosition = pos;
    }

    public static int Set_Stage_Lv()
    {
        return stage_lv;
    }

    public static int Set_num()
    {
        return num;
    }

    public static int Set_Load_Cnt()
    {
        return load_cnt;
    }

    public static int Get_Play_Cnt()
    {
        return play_cnt;
    }
}
