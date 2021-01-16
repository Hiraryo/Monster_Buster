using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField]
    Warning script1;
    [SerializeField]
    AudioSource audioSources;
    [SerializeField]
    Renderer ren;

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
    //Warning script1;

    public GameObject Fire;

    public AudioClip sound01;
    public GameObject boss_sound;
    public Collider2D c_wait_isTrigger;
    int scene_cnt;
    // Use this for initialization
    void Start()
    {
        litlle.SetActive(false);
        litlle_time = 0;
        little_f = false;

        nextTime = Time.time;

        Warning = GameObject.Find("Warning");
        //script1 = Warning.GetComponent<Warning>();

        Fire.SetActive(false);
        boss_sound.SetActive(false);
        //sound01 = GetComponent<AudioSource>();
        scene_cnt = Quest_Easy.Set_Scene_Num();
    }

    // Update is called once per frame
    void Update()
    {
        bool d_f = script1.dragon_f;
        if (d_f == true && transform.localPosition.x > 398.0f || transform.localPosition.y > -9.0f){
            transform.Translate(-10.0f, -10.0f, 0);
            c_wait_isTrigger.isTrigger = false;
        }
        if (transform.localPosition.x <= 398.0f || transform.localPosition.y <= -9.0f){
            Fire.SetActive(true);
            boss_sound.SetActive(true);
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
            //Renderer ren = gameObject.GetComponent<Renderer>();
            ren.enabled = !ren.enabled;
            nextTime += interval;
            time_cnt++;
            if (time_cnt == 40)
            {
                time_cnt = 0;
                time_f = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        Doragon = GetComponent<Collider2D>();
        Doragon.isTrigger = true;
        if(scene_cnt != 3)
        {
            if (c.tag == "fire" || c.tag == "Super_Shot")
            {
                Boss_HP -= 10;
                time_f = true;
                audioSources.PlayOneShot(sound01);
                //sound01.PlayOneShot(sound01.clip);
                if (Boss_HP <= 50)
                {
                    litlle.SetActive(true);
                    little_f = true;
                }
                if (Boss_HP == 0)
                {
                    litlle.SetActive(false);
                    Destroy(gameObject);
                    Destroy(Fire.gameObject);
                    FindObjectOfType<Score>().AddPoint(500);
                    if (scene_cnt == 1)
                    {
                        PlayerPrefs.SetInt("easy", 1);
                        PlayerPrefs.Save();
                    }
                    if (scene_cnt == 2)
                    {
                        PlayerPrefs.SetInt("normal", 1);
                        PlayerPrefs.Save();
                    }
                    SceneManager.LoadScene("GameClear");
                }
            }
        }
        if (scene_cnt == 3)
        {
            if (c.tag == "fire")
            {
                Boss_HP -= 10;
                time_f = true;
                audioSources.PlayOneShot(sound01);
                //sound01.PlayOneShot(sound01.clip);
                if (Boss_HP <= 50)
                {
                    litlle.SetActive(true);
                    little_f = true;
                }
                if (Boss_HP == 0)
                {
                    litlle.SetActive(false);
                    Destroy(gameObject);
                    Destroy(Fire.gameObject);
                    FindObjectOfType<Score>().AddPoint(500);
                    if (scene_cnt == 3)
                    {
                        PlayerPrefs.SetInt("heard", 1);
                        PlayerPrefs.Save();
                    }
                    SceneManager.LoadScene("GameClear");
                }
            }
        }
    }
}




