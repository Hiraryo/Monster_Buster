using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss_Endless2 : MonoBehaviour
{

    Collider2D Doragon;

    public GameObject litlle;
    public int Boss_HP;
    float litlle_time;
    bool little_f;

    private float nextTime;
    public float interval;   // 点滅周期
    int time_cnt;

    bool time_f = false;

    GameObject Warning;
    Warning3 script1;

    public GameObject Fire;

    private AudioSource sound01;
    public GameObject boss_sound;

    public bool Boss_Endless_f;

    public bool Endless_f1_Warning_Boss;
    public bool Endless_f2_Warning_Boss;
    public bool Endless_f3_Warning_Boss;
    public bool Endless_f4_Warning_Boss;

    [SerializeField]
    Fade fade = null;

    Color alpha;
    GameObject BossObj;
    //int num;
    public GameObject stage_fade;
    public Collider2D c_wait_isTrigger;
	public static bool fire_start_position_f = false;
	public static float fire_start_position_x;
	public static float fire_start_position_y;
    public int life;
    public static bool boss_sound_play;
    int you_score;
    int life_num;
    int save_combo;
    int count_time;
    public static int Get_Stage_lv;
    int Get_play_cnt;
    public static bool dragon_f;
    public static int Bonus;
    int get_num;
    // Use this for initialization
    void Start()
    {
        Bonus = 0;
        litlle.SetActive(false);
        litlle_time = 0;
        little_f = false;
        dragon_f = false;
        nextTime = Time.time;

        Warning = GameObject.Find("Warning");
        script1 = Warning.GetComponent<Warning3>();

        Fire.SetActive(false);
        boss_sound.SetActive(false);
        sound01 = GetComponent<AudioSource>();

        BossObj = GameObject.Find("d_016");
        //num = Random.Range(1, 4);
        boss_sound_play = false;
        //stage_fade.transform.position = new Vector3(80,2.3f,0);
        get_num = GameStartText.Set_num();
    }

    // Update is called once per frame
    void Update()
    {
        life_num = Player_damage_Endless.GetLife();
        bool d_f = Warning3.Set_dragon_eye();
        //スケルトンの出現制御のフラグ(Warning3.csより参照)
        Endless_f1_Warning_Boss = script1.Endless_f1_Warning;
        Endless_f2_Warning_Boss = script1.Endless_f2_Warning;
        Endless_f3_Warning_Boss = script1.Endless_f3_Warning;
        Endless_f4_Warning_Boss = script1.Endless_f4_Warning;
        Boss_Endless_f = false;
        if (d_f == true && transform.localPosition.x > 14.0f || transform.localPosition.y > 2.0f)
        {
            transform.Translate(-1.0f, -1.0f,0);
            c_wait_isTrigger.isTrigger = false;
        }
        if (transform.localPosition.x <= 14.0f || transform.localPosition.y <= 2.0f)
		{
            Fire.SetActive(true);
            boss_sound.SetActive(true);
            boss_sound_play = true;
			fire_start_position_f = true;
			fire_start_position_x = Fire.transform.position.x;
			fire_start_position_y = Fire.transform.position.y;
            dragon_f = true;
        }
        if (little_f == true){
            litlle_time += Time.deltaTime;
            if (litlle_time >= 2.0f)
            {
                litlle.SetActive(false);
                litlle_time = 0;
                little_f = false;
            }
        }
        if (Time.time > nextTime && time_cnt < 40 && time_f == true)
        {
            Renderer ren = gameObject.GetComponent<Renderer>();
            ren.enabled = !ren.enabled;
            nextTime += interval;
            time_cnt++;
            if (time_cnt == 40)
            {
                time_cnt = 0;
                time_f = false;
            }
        }

        if (Boss_HP <= 0)
        {
            stage_fade.transform.Translate(-10.0f, 0, 0);
            //BossObj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha.a);
            if (stage_fade.transform.position.x <= 10.0f)
            {
                boss_sound_play = false;
                Get_Stage_lv = PlayerPrefs.GetInt("Stage_Lv", 1);
                Get_play_cnt = PlayerPrefs.GetInt("play_cnt", 0);
                Get_Stage_lv += 1;
                Get_play_cnt += 1;
                PlayerPrefs.SetInt("Heart", life_num);
                PlayerPrefs.SetInt("Stage_Lv", Get_Stage_lv);
                PlayerPrefs.SetInt("play_cnt", Get_play_cnt);
                PlayerPrefs.Save();
                LoadScene();
                //Destroy(gameObject);
                //Destroy(Fire.gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        Doragon = GetComponent<Collider2D>();
        Doragon.isTrigger = true;
        if(get_num != 2)
        {
            if (c.tag == "fire" || c.tag == "Super_Shot" || c.tag == "kobushi")
            {
                Boss_HP -= 10;
                time_f = true;
                sound01.PlayOneShot(sound01.clip);
                if (Boss_HP <= 50)
                {
                    litlle.SetActive(true);
                    little_f = true;
                }
                if (Boss_HP == 0)
                {
                    litlle.SetActive(false);

                    FindObjectOfType<Score_Endless>().AddPoint(500);
                    Boss_Endless_f = true;

                    Endless_f1_Warning_Boss = false;
                    Endless_f2_Warning_Boss = false;
                    Endless_f3_Warning_Boss = false;
                    Endless_f4_Warning_Boss = false;
                }
            }
        }
        
        if(get_num == 2)
        {
            if (c.tag == "fire" || c.tag == "kobushi")
            {
                Boss_HP -= 10;
                time_f = true;
                sound01.PlayOneShot(sound01.clip);
                if (Boss_HP <= 50)
                {
                    litlle.SetActive(true);
                    little_f = true;
                }
                if (Boss_HP == 0)
                {
                    litlle.SetActive(false);

                    FindObjectOfType<Score_Endless>().AddPoint(500);
                    Boss_Endless_f = true;

                    Endless_f1_Warning_Boss = false;
                    Endless_f2_Warning_Boss = false;
                    Endless_f3_Warning_Boss = false;
                    Endless_f4_Warning_Boss = false;
                }
            }
        }
		if (c.tag == "kobushi")
		{
			Boss_HP -= 50;
            Debug.Log("-50");
            time_f = true;
			sound01.PlayOneShot(sound01.clip);
			if (Boss_HP <= 50)
			{
				litlle.SetActive(true);
				little_f = true;
			}
			if (Boss_HP == 0)
			{
				litlle.SetActive(false);

				FindObjectOfType<Score_Endless>().AddPoint(500);
				Boss_Endless_f = true;

				Endless_f1_Warning_Boss = false;
				Endless_f2_Warning_Boss = false;
				Endless_f3_Warning_Boss = false;
				Endless_f4_Warning_Boss = false;
			}
		}
	}

    public void LoadScene()
    {
        you_score = Score_Endless.getScore();
        save_combo = Combo_Endless.GetCombo();
        count_time = Skill_Button.GetCountTime();
        Bonus = Random.Range(0, 2);
        PlayerPrefs.SetInt("Score", you_score);
        PlayerPrefs.Save();
        /*
        // スコアを保存する
        PlayerPrefs.SetInt("Score", you_score);
        //コンボを保存する
        PlayerPrefs.SetInt("Combo", save_combo);
        //スキルタイムを保存する
        PlayerPrefs.SetInt("Count", count_time);
        PlayerPrefs.Save();
        */
        SceneManager.LoadScene("endless");
    }

    public static bool Fire_set_f()
	{
		return fire_start_position_f;
	}
    public static float Fire_set_pos()
	{
		return fire_start_position_x;
		return fire_start_position_y;
	}

    public static bool Boss_Sound_Play_f()
    {
        return boss_sound_play;
    }

    public static int Set_Next_Stage_Lv()
    {
        return Get_Stage_lv;
    }

    public static bool Set_dragon_posOK()
    {
        return dragon_f;
    }
    public static int Set_Bonus()
    {
        return Bonus;
    }
}




