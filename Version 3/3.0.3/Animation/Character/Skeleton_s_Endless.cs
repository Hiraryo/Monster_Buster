using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton_s_Endless : MonoBehaviour {
    float move_x = -0.35f;
    Collider2D s_Object;

    bool space_check_f = false;
    //public Rigidbody2D rb;
    int count;

    GameObject c_wait;   //skeleton_fが入る変数
    Move_Endless script;                //moveの名前のスクリプトが入る変数

    private AudioSource sound01;
    SpriteRenderer MainSpriteRenderer;
    public Sprite DebrisbySprite;
    float debris_time;
    int player_hit_f = 0;
    bool tatumaki_hit;
    int tatumaki_hit_cnt = 0;
    int life = 0;
    int skill;
    int lv;
    int point = 5;
    int point_count;
    public static bool combo_skeleton_Endless_add3 = false;
    int stage_lv;
    public static int load_cnt;
    float move_left_x;
    float move_diff_x = 0;
    // Use this for initialization
    void Start()
    {
        load_cnt = Set_Load_Cnt();
        stage_lv = GameStartText.Set_Stage_Lv();
        //move_diff_x = Skes_speed();
        /*
        if (load_cnt == 0)
        {
            move_diff_x = 0;
            load_cnt = 1;
        }
        if (load_cnt == 1)
        {
            move_diff_x = Skes_speed();
        }
        */
        move_diff_x += stage_lv * 0.0005f;
        move_x -= move_diff_x;
        move_left_x = move_x;
        c_wait = GameObject.Find("c_wait");   //c_waitをオブジェクトの名前から取得して変数に格納する
        script = c_wait.GetComponent<Move_Endless>();        //c_waitの中にあるmoveを取得して変数に格納する
        sound01 = GetComponent<AudioSource>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        debris_time = 0;
        count = 0;
        skill = PlayerPrefs.GetInt("yukou_button_number", 0);
        lv = PlayerPrefs.GetInt("lv_6", 1);
        point_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        combo_skeleton_Endless_add3 = false;
        life = Player_damage_Endless.GetLife();
        if (count < 1)
        {
            transform.Translate(move_x, 0, 0);
        }
        space_check_f = script.space_check;    //新しく変数を宣言してその中にmoveの変数space_checkを代入する。
        //--------------------------
        if (!GetComponent<SpriteRenderer>().isVisible && transform.position.x <= 0)
        {
            Destroy(gameObject);
        }
        //--------------------------

        if (count >= 1)
        {
            Destroy(GetComponent<Animator>());
            MainSpriteRenderer.sprite = DebrisbySprite;
            debris_time += Time.deltaTime;
            if (debris_time >= 2.0f)
            {
                //------リベンジ---------------
                if (skill == 8 && life == 1)
                {
                    if (lv == 1)
                    {
                        point *= 1;
                    }
                    if (lv > 1 && lv < 30)
                    {
                        point *= 2;
                    }
                    if (lv >= 30 && lv < 60)
                    {
                        point *= 3;
                    }
                    if (lv >= 60 && lv < 90)
                    {
                        point *= 4;
                    }
                    if (lv >= 90 && lv < 100)
                    {
                        point *= 5;
                    }
                    if (lv >= 100)
                    {
                        point *= 7;
                    }
                }
                //------リベンジ（終わり）---------------
                debris_time = 0;
                Destroy(gameObject);
            }
        }
        /*
        tatumaki_hit = Tatumaki.Tatumaki_OK();
        if (tatumaki_hit)
        {
            tatumaki_hit_cnt = 0;
        }
        if (tatumaki_hit && tatumaki_hit_cnt == 0)
        {
            tatumaki_hit_cnt = 1;
            s_Object = GetComponent<Collider2D>();
            s_Object.isTrigger = false;
            if (count < 1)
            {
                move_x = 0.4f;
            }
            player_hit_f++;
            if (player_hit_f == 1 && count < 1)
            {
                Invoke("Skeske", 1);
                sound01.PlayOneShot(sound01.clip);
            }
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "tatumaki")
        {
            s_Object = GetComponent<Collider2D>();
            s_Object.isTrigger = false;
            if (count < 1)
            {
                move_x = 0.4f;
            }
            player_hit_f++;
            if (player_hit_f == 1 && count < 1)
            {
                Invoke("Skeske", 1);
                sound01.PlayOneShot(sound01.clip);
                combo_skeleton_Endless_add3 = true;
            }
        }
    }
    void OnTriggerStay2D(Collider2D c)
    {
        if (c.tag == "Player" && space_check_f == true || c.tag == "kobushi"/* || c.tag == "tatumaki"*/)
        {
            
            s_Object = GetComponent<Collider2D>();
            s_Object.isTrigger = false;
            if (count < 1)
            {
                move_x = 0.4f;
            }
            player_hit_f++;
            if (player_hit_f == 1 && count < 1)
            {
                Invoke("Skeske", 1);
                sound01.PlayOneShot(sound01.clip);
                combo_skeleton_Endless_add3 = true;
            }
        }
        if (c.tag == "Super_Shot" || c.tag == "Invisible" || c.tag == "tatumaki_death")
        {
            //sound01.PlayOneShot(sound01.clip);
            FindObjectOfType<Score_Endless>().AddPoint(point);
            count = 1;
        }
    }

    void Skeske()
    {
        move_x = move_left_x;
        s_Object.isTrigger = true;
        space_check_f = false;
        count = count + 1;
        player_hit_f = 0;
        if (count >= 1)
        {
            FindObjectOfType<Score_Endless>().AddPoint(point);
        }
    }
    public static bool Get_Combo_Endless3()
    {
        return combo_skeleton_Endless_add3;
    }
    public static int Set_Load_Cnt()
    {
        return load_cnt;
    }
}
