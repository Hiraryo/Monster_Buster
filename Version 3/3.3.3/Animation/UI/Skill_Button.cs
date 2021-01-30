using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Skill_Button : MonoBehaviour
{
    int skill;
    public GameObject kobushi;
    float kobushi_start;
    float kobushi_start_y;
    bool skill_ok = false;
    int kobushi_ground_hit = 1;
    public Image Skillobj;
    public Text Skilltex;
    public GameObject SkillButton;
    public bool roop;
    public static int count;
    public float countTime;
    public float amountcount;
    bool gauge_check = false;
    public float kobushi_dx;    //拳の移動の最大値X
    [SerializeField]
    Transform Tatumaki_Tran;
    float timer = 0;
    public GameObject tatumaki;
    bool kobushi_f = false;
    bool tatumaki_f = false;
    bool invisible_f = false;
    bool life_saisei_f = false;
    int life_saisei_cnt = 0;
    public static int life;
    GameObject HeartObj1;
    GameObject HeartObj2;
    GameObject HeartObj3;
    GameObject HeartObj4;
    GameObject HeartObj5;
    GameObject HeartObj6;

    public static int life_num;
    int lv1;
    int lv2;
    int lv4;
    int lv7;
    float Invisible_timer = 0;
    public GameObject Invisible_atari;
    float tatumaki_timer = 0;
    public float duration = 0.3F;
    public GameObject player;
    Color Player_color;
    public GameObject stage_sound;
    public GameObject Invisible_Sound;
    public GameObject Boss_Sound;
    bool boss_sound_f = false;
    public GameObject bless_hit;
    int bairitu;
    Vector3 pos;
    public ParticleSystem Heart1_Particle;
    public ParticleSystem Heart2_Particle;
    public ParticleSystem Heart4_Particle;
    public ParticleSystem Heart5_Particle;
    public ParticleSystem Heart6_Particle;
    bool Heart_anime_Finish = false;
    public static bool Heart_Add_f = false;
    bool GetHeart_Dell = false;
    public static int load_cnt;
    bool player_show = true;
    // Start is called before the first frame update
    void Start()
    {
        Heart1_Particle.Stop();
        Heart2_Particle.Stop();
        Heart4_Particle.Stop();
        Heart5_Particle.Stop();
        Heart6_Particle.Stop();
        skill = PlayerPrefs.GetInt("yukou_button_number", 0);
        life = PlayerPrefs.GetInt("Heart", 3);
        lv1 = PlayerPrefs.GetInt("lv_1", 1);
        lv2 = PlayerPrefs.GetInt("lv_2", 1);
        lv4 = PlayerPrefs.GetInt("lv_4", 1);
        lv7 = PlayerPrefs.GetInt("lv_7", 1);
        load_cnt = Set_Load_Cnt();
        if(load_cnt == 0)
        {
            count = 6;
            load_cnt = 1;
        }
        if(load_cnt == 1)
        {
            count = GetCountTime();
        }
        pos = kobushi.transform.position;
        kobushi_start = kobushi.transform.position.x;
        kobushi_start_y = kobushi.transform.position.y;
        if (skill == 0 || skill == 6 || skill == 8)
        {
            SkillButton.SetActive(false);
        }
        kobushi.SetActive(false);
        tatumaki.SetActive(false);

        HeartObj1 = GameObject.Find("heart1");  //はじめに消えるハート
        HeartObj2 = GameObject.Find("heart2");  //2番目に消えるハート
        HeartObj3 = GameObject.Find("heart3");  //最後に消えるハート
        HeartObj4 = GameObject.Find("heart4");  //heart1の隣のハート
        HeartObj5 = GameObject.Find("heart5");  //heart4の隣のハート　
        HeartObj6 = GameObject.Find("heart6");  //heart5の隣のハート
        Invisible_atari.SetActive(false);
        
        //life_num = Player_damage_Endless.Life();
        if (lv1 < 10)
        {
            bairitu = 4;
        }
        if (lv1 >= 10 && lv1 < 20)
        {
            bairitu = 5;
        }
        if (lv1 >= 20 && lv1 < 30)
        {
            bairitu = 6;
        }
        if (lv1 >= 30 && lv1 < 40)
        {
            bairitu = 7;
        }
        if (lv1 >= 40 && lv1 < 50)
        {
            bairitu = 8;
        }
        if (lv1 >= 50 && lv1 < 60)
        {
            bairitu = 9;
        }
        if (lv1 >= 60 && lv1 < 70)
        {
            bairitu = 10;
        }
        if (lv1 >= 80 && lv1 < 90)
        {
            bairitu = 11;
        }
        if (lv1 >= 90 && lv1 < 100)
        {
            bairitu = 12;
        }
        if (lv1 >= 100)
        {
            bairitu = 13;
        }
        kobushi_dx *= bairitu;
        tatumaki_timer = lv2 * 0.2f;
        Player_color = player.GetComponent<Renderer>().material.color;
        Invisible_Sound.SetActive(false);
        if(skill == 4)
        {
            //LVが1の時はcountTimeを8にする
            //LVが100の時はcountTimeを2にする
            countTime = 8 - 0.06f * lv4;
        }
        if(skill != 4)
        {
            countTime = 5.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().isVisible)
        {
            player_show = true;
        }
        else
        {
            player_show = false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Skill_Button_OK();
        }
        GetHeart_Dell = Player_damage_Endless.GetHeartDel();
        if(GetHeart_Dell == true)
        {
            GetHeartDate();
            GetHeart_Dell = false;
        }
        boss_sound_f = Boss_Endless2.Boss_Sound_Play_f();
        Debug.Log("life = " + life);
        if (count > 0)
        {
            Heart_Add_f = false;
            amountcount = Skillobj.fillAmount;
            Skilltex.text = string.Format("" + count);
            if (roop)
            {
                //Reduce fill amount over 30 seconds
                Skillobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
            }
            else if (!roop)
            {
                Skillobj.fillAmount += 1.0f / countTime * Time.deltaTime;
            }

            if (Skillobj.fillAmount == 0 || Skillobj.fillAmount == 1)
            {
                count = count - 1;
                Skillobj.fillClockwise = !Skillobj.fillClockwise;
                roop = !roop;
            }
        }
        if (count == 0)
        {
            Skilltex.text = string.Format("OK");
            gauge_check = true;
        }
        if (skill_ok == true && gauge_check == true && skill == 1)
        {
            kobushi_f = true;
        }
        if (skill_ok == true && gauge_check == true && skill == 2)
        {
            tatumaki_f = true;
        }
        if (skill_ok == true && gauge_check == true && skill == 4)
        {
            GetHeartDate();
            Heart_anime_Finish = false;
            life_saisei_f = true;
            gauge_check = false;
            skill_ok = false;
            if (life < 6)
            {
                life += 1;
            }
            SaveHeartDate();
            Heart_Add_f = true;
            count = 5;
        }
        if (skill_ok == true && gauge_check == true && skill == 7)
        {
            invisible_f = true;
        }
        //------拳--------------
        if (kobushi_f == true)
        {
            kobushi.SetActive(true);
            if (kobushi_ground_hit == 1)
            {
                kobushi.transform.position += new Vector3(4, 0);
            }
            if (kobushi_ground_hit == 2)
            {
                kobushi.transform.position -= new Vector3(4, 0);
            }
            if (kobushi.transform.position.x >= kobushi_start + kobushi_dx)
            {
                kobushi_ground_hit = 2;
            }
            if (kobushi.transform.position.x <= kobushi_start && gauge_check == true)
            {
                kobushi_ground_hit = 0;
                skill_ok = false;
                gauge_check = false;
                kobushi_f = false;
                count = 5;
                pos.x = kobushi_start;
                pos.y = kobushi_start_y;
                kobushi.transform.position = pos;
                kobushi.SetActive(false);
            }
        }
        //------拳（終わり）--------------
        //------竜巻---------------
        if (tatumaki_f == true)
        {
            timer += Time.deltaTime;
            tatumaki.SetActive(true);
            Tatumaki_Tran.DOScale(endValue: new Vector3(2.5f, 2.5f, 2.5f), duration: 1.0f);
            if (timer >= tatumaki_timer)
            {
                gauge_check = false;
                tatumaki_f = false;
                skill_ok = false;
                Tatumaki_Tran.DOScale(endValue: new Vector3(0f, 0f, 0f), duration: 1.0f);
                tatumaki.SetActive(false);
                timer = 0;
                count = 5;
            }
        }
        //------竜巻（終わり）------
        //------ハート再生---------------
        if (life_saisei_f == true)
        {
            if (life == 1)
            {
                /*
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                */
            }
            if (life == 2)
            {
                if(Heart_anime_Finish == false)
                {
                    Heart2_Particle.Play();
                    Heart_anime_Finish = true;
                }
                /*
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                */
            }
            if (life == 3)  //スタート時
            {
                if (Heart_anime_Finish == false)
                {
                    Heart1_Particle.Play();
                    Heart_anime_Finish = true;
                }
                /*
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                */
            }
            if (life == 4)
            {
                if (Heart_anime_Finish == false)
                {
                    Heart4_Particle.Play();
                    Heart_anime_Finish = true;
                }
                /*
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                */
            }
            if (life == 5)
            {
                if (Heart_anime_Finish == false)
                {
                    Heart5_Particle.Play();
                    Heart_anime_Finish = true;
                }
                /*
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                */
            }
            if (life == 6)
            {
                if (Heart_anime_Finish == false)
                {
                    Heart6_Particle.Play();
                    Heart_anime_Finish = true;
                }
                /*
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj4.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj5.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                HeartObj6.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                */
            }
        }
        //------ハート再生（終わり）---------------
        //------無敵---------------
        if (invisible_f == true)
        {
            stage_sound.SetActive(false);
            Boss_Sound.SetActive(false);
            Invisible_Sound.SetActive(true);
            Invisible_timer += Time.deltaTime;
            Invisible_atari.SetActive(true);
            bless_hit.SetActive(false);
            //durationの時間ごとに色が変わる
            float phi = Time.time / duration * 2 * Mathf.PI;
            float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
            //色をRGBではなくHSVで指定
            player.GetComponent<Renderer>().material.color = Color.HSVToRGB(amplitude, 1, 1);
            if (lv7 >= 1 && lv7 < 30)
            {
                if(Invisible_timer >= 4.0f)
                {
                    skill_ok = false;
                    gauge_check = false;
                    count = 5;
                    Invisible_atari.SetActive(false);
                    invisible_f = false;
                    Invisible_timer = 0;
                    player.GetComponent<Renderer>().material.color = Player_color;
                    Invisible_Sound.SetActive(false);
                    bless_hit.SetActive(true);
                    if (boss_sound_f == false)
                    {
                        stage_sound.SetActive(true);
                    }
                    if (boss_sound_f == true)
                    {
                        Boss_Sound.SetActive(true);
                    }
                }
            }
            if (lv7 >= 30 && lv7 < 60)
            {
                if (Invisible_timer >= 6.0f)
                {
                    skill_ok = false;
                    gauge_check = false;
                    count = 5;
                    Invisible_atari.SetActive(false);
                    invisible_f = false;
                    Invisible_timer = 0;
                    player.GetComponent<Renderer>().material.color = Player_color;
                    Invisible_Sound.SetActive(false);
                    bless_hit.SetActive(true);
                    if (boss_sound_f == false)
                    {
                        stage_sound.SetActive(true);
                    }
                    if (boss_sound_f == true)
                    {
                        Boss_Sound.SetActive(true);
                    }
                }
            }
            if (lv7 >= 60 && lv7 < 90)
            {
                if (Invisible_timer >= 8.0f)
                {
                    skill_ok = false;
                    gauge_check = false;
                    count = 5;
                    Invisible_atari.SetActive(false);
                    invisible_f = false;
                    Invisible_timer = 0;
                    player.GetComponent<Renderer>().material.color = Player_color;
                    Invisible_Sound.SetActive(false);
                    bless_hit.SetActive(true);
                    if (boss_sound_f == false)
                    {
                        stage_sound.SetActive(true);
                    }
                    if (boss_sound_f == true)
                    {
                        Boss_Sound.SetActive(true);
                    }
                }
            }
            if (lv7 >= 90 && lv7 < 100)
            {
                if (Invisible_timer >= 9.0f)
                {
                    skill_ok = false;
                    gauge_check = false;
                    count = 5;
                    Invisible_atari.SetActive(false);
                    invisible_f = false;
                    Invisible_timer = 0;
                    player.GetComponent<Renderer>().material.color = Player_color;
                    Invisible_Sound.SetActive(false);
                    bless_hit.SetActive(true);
                    if (boss_sound_f == false)
                    {
                        stage_sound.SetActive(true);
                    }
                    if (boss_sound_f == true)
                    {
                        Boss_Sound.SetActive(true);
                    }
                }
            }
            if (lv7 >= 100)
            {
                if (Invisible_timer >= 10.0f)
                {
                    skill_ok = false;
                    gauge_check = false;
                    count = 5;
                    Invisible_atari.SetActive(false);
                    invisible_f = false;
                    Invisible_timer = 0;
                    player.GetComponent<Renderer>().material.color = Player_color;
                    Invisible_Sound.SetActive(false);
                    bless_hit.SetActive(true);
                    if (boss_sound_f == false)
                    {
                        stage_sound.SetActive(true);
                    }
                    if (boss_sound_f == true)
                    {
                        Boss_Sound.SetActive(true);
                    }
                }
            }
        }
        //------無敵（終わり）---------------
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            kobushi_ground_hit = 2;
            //var source = GetComponent<Cinemachine.CinemachineImpulseSource>();
            //source.GenerateImpulse();
        }
    }
    public void Skill_Button_OK()
    {
        if (gauge_check == true && player_show == true)
        {
            kobushi_ground_hit = 1;
            skill_ok = true;
        }
        
    }

    public static int GetHeart()
    {
        return life;
    }
    public static bool GetHeart_Add()
    {
        return Heart_Add_f;
    }
    public void SaveHeartDate()
    {
        PlayerPrefs.SetInt("Heart", life);
        PlayerPrefs.Save();
    }
    public void GetHeartDate()
    {
        life = PlayerPrefs.GetInt("Heart", 3);
    }
    public static int GetCountTime()
    {
        return count;
    }
    public static int Set_Load_Cnt()
    {
        return load_cnt;
    }
}
