using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning3 : MonoBehaviour {

    GameObject skeletonPoint;
    Spawn_skel4_1 script;

    GameObject skeletonNPoint;
    Spawn_skel3_2 script1;

    GameObject skeletonSPoint;
    Spawn_skel5_3 script2;

    GameObject Spawn_skel_gold;
    Spawn_skel_gold1 script_gold;

    public GameObject warning;
    public GameObject warning2;
    public GameObject dragon;
    public GameObject Warning_Sound;

    public static bool dragon_f;

    float time;

    private AudioSource sound01;

    public GameObject MainCam;
    public GameObject SubCam;
    public GameObject Fade2;
    public GameObject dragon_pre;

    public bool d_f;
    bool dragon_active_f;

    public bool sound_off;

    public bool Endless_f1_Warning;
    public bool Endless_f2_Warning;
    public bool Endless_f3_Warning;
    public bool Endless_f4_Warning;

    public GameObject stage_sound;
    public GameObject bless_hit;
    public bool warning_OK;
    // Use this for initialization
    void Start () {
        skeletonPoint = GameObject.Find("skeletonPoint");
        script = skeletonPoint.GetComponent<Spawn_skel4_1>();

        skeletonNPoint = GameObject.Find("skeletonNPoint");
        script1 = skeletonNPoint.GetComponent<Spawn_skel3_2>();


        skeletonSPoint = GameObject.Find("skeletonSPoint");
        script2 = skeletonSPoint.GetComponent<Spawn_skel5_3>();

        Spawn_skel_gold = GameObject.Find("skeletonSPoint_gold");
        script_gold = Spawn_skel_gold.GetComponent<Spawn_skel_gold1>();

        time = 0;
        warning.SetActive(false);
        warning2.SetActive(false);
        Warning_Sound.SetActive(false);

        dragon_f = false;

        sound01 = GetComponent<AudioSource>();

        MainCam.SetActive(true);
        SubCam.SetActive(false);

        d_f = false;
        dragon_active_f = false;

        sound_off = false;
        bless_hit.SetActive(false);
        warning_OK = false;
    }
	  
	// Update is called once per frame
	void Update () {
        bool warning_f1_Warning = script.warning_f1;
        bool warning_f2_Warning = script1.warning_f2;
        bool warning_f3_Warning = script2.warning_f3;
        bool warning_f4_Warning = script_gold.warning_gold;
        bool dragon_p_f = Dragon_preview_move1.Set_Dragon_pre_f();

        //
        Endless_f1_Warning = script.Endless_f1;
        Endless_f2_Warning = script1.Endless_f2;
        Endless_f3_Warning = script2.Endless_f3;
        Endless_f4_Warning = script_gold.Endless_f_gold;

        if (warning_f1_Warning == true && warning_f2_Warning == true && warning_f3_Warning == true && warning_f4_Warning == true)
        {
            warning_OK = true;
            time += Time.deltaTime;
            Warning_Sound.SetActive(true);
            sound_off = true;
            stage_sound.SetActive(false);
            /*
            if (time >= 3.0)
            {
                Warning_Sound.SetActive(true);
                warning.SetActive(true);
                warning2.SetActive(true);
                sound_off = true;
                stage_sound.SetActive(false);
            }
            if (time >= 4.0)
            {
                stage_sound.SetActive(false);
                warning2.SetActive(false);
            }
            if (time >= 4.5)
            {
                stage_sound.SetActive(false);
                warning2.SetActive(true);
            }
            if (time >= 5.0)
            {
                stage_sound.SetActive(false);
                warning2.SetActive(false);
            }
            if (time >= 5.5)
            {
                stage_sound.SetActive(false);
                warning2.SetActive(true);
            }
            if (time >= 6.0)
            {
                stage_sound.SetActive(false);
                warning2.SetActive(false);
            }
            if (time >= 6.5)
            {
                stage_sound.SetActive(false);
                warning2.SetActive(true);
            }
            */
            if (time >= 7.0)
            {
                stage_sound.SetActive(false);
                //warning.SetActive(false);
                //warning2.SetActive(false);
                MainCam.SetActive(false);
                SubCam.SetActive(true);
                dragon_pre.SetActive(true);
                warning_OK = false;
                d_f = true;
                if (dragon_p_f == true){
                    MainCam.SetActive(true);
                    SubCam.SetActive(false);
                    Fade2.SetActive(true);
                    if (Fade2.transform.position.x >= -78.0f)
                    {
                        Fade2.transform.Translate(-2.0f, 0, 0);
                    }
                    if (Fade2.transform.position.x < -78.0f && dragon_active_f == false){
                        dragon.SetActive(true);
                        dragon_f = true;
                        dragon_active_f = true;
                        bless_hit.SetActive(true);
                    }
                }
            }
        }
    }

    public static bool Set_dragon_eye()
    {
        return dragon_f;
    }
}
