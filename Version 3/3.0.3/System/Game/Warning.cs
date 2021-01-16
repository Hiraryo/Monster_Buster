using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour {

    [SerializeField]
    Spawn_skel script;
    [SerializeField]
    Spawn_skel1 script1;
    [SerializeField]
    Spawn_skel2 script2;
    [SerializeField]
    Spawn_skel_gold script_gold;

    GameObject skeletonPoint;
    //Spawn_skel script;

    GameObject skeletonNPoint;
    //Spawn_skel1 script1;

    GameObject skeletonSPoint;
    //Spawn_skel2 script2;

    GameObject Spawn_skel_gold;
    //Spawn_skel_gold script_gold;

    public GameObject warning;
    public GameObject warning2;
    public GameObject dragon_Red;
    public GameObject dragon_Green;
    public GameObject dragon_Blue;
    public GameObject Warning_Sound;

    public bool dragon_f;

    float time;

    private AudioSource sound01;

    public GameObject MainCam;
    public GameObject SubCam;
    public GameObject Fade2;
    public GameObject dragon_pre;

    GameObject dragon_preview;
    //Dragon_preview_move script3;

    public bool d_f;
    bool dragon_active_f;

    public bool sound_off;
    public GameObject stage_sound;
    public GameObject bless_hit;
    public bool warning_OK;
    int get_num;
    // Use this for initialization
    void Start () {
        get_num = Quest_Easy.Set_Scene_Num();
        skeletonPoint = GameObject.Find("skeletonPoint");
        //script = skeletonPoint.GetComponent<Spawn_skel>();

        skeletonNPoint = GameObject.Find("skeletonNPoint");
        //script1 = skeletonNPoint.GetComponent<Spawn_skel1>();


        skeletonSPoint = GameObject.Find("skeletonSPoint");
        //script2 = skeletonSPoint.GetComponent<Spawn_skel2>();

        Spawn_skel_gold = GameObject.Find("skeletonSPoint_gold");
        //script_gold = Spawn_skel_gold.GetComponent<Spawn_skel_gold>();

        time = 0;
        warning.SetActive(false);
        warning2.SetActive(false);
        Warning_Sound.SetActive(false);

        dragon_f = false;

        sound01 = GetComponent<AudioSource>();

        MainCam.SetActive(true);
        SubCam.SetActive(false);

        dragon_preview = GameObject.Find("dragon_preview");
        //script3 = dragon_preview.GetComponent<Dragon_preview_move>();
        d_f = false;
        dragon_active_f = false;

        dragon_pre.SetActive(false);
        sound_off = false;
        stage_sound.SetActive(true);
        bless_hit.SetActive(false);
        warning_OK = false;
    }
	  
	// Update is called once per frame
	void Update () {
        bool warning_f1_Warning = script.warning_f1;
        bool warning_f2_Warning = script1.warning_f2;
        bool warning_f3_Warning = script2.warning_f3;
        bool warning_f4_Warning = script_gold.warning_gold;
        bool dragon_p_f = Dragon_preview_move.Set_Dragon_pre_f();

        if (warning_f1_Warning == true && warning_f2_Warning == true && warning_f3_Warning == true && warning_f4_Warning == true)
        {
            time += Time.deltaTime;
            warning_OK = true;
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
                warning2.SetActive(false);
            }
            if (time >= 4.5)
            {
                warning2.SetActive(true);
            }
            if (time >= 5.0)
            {
                warning2.SetActive(false);
            }
            if (time >= 5.5)
            {
                warning2.SetActive(true);
            }
            if (time >= 6.0)
            {
                warning2.SetActive(false);
            }
            if (time >= 6.5)
            {
                warning2.SetActive(true);
            }
            */
            if (time >= 7.0)
            {
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
                    if (Fade2.transform.localPosition.x >= -3000.0f)
                    {
                        Fade2.transform.Translate(-40.0f, 0, 0);
                    }
                    if (Fade2.transform.localPosition.x < -2000.0f && dragon_active_f == false){
                        if(get_num == 1)
                        {
                            dragon_Red.SetActive(true);
                        }
                        if (get_num == 2)
                        {
                            dragon_Green.SetActive(true);
                        }
                        if (get_num == 3)
                        {
                            dragon_Blue.SetActive(true);
                        }
                        dragon_f = true;
                        dragon_active_f = true;
                        bless_hit.SetActive(true);
                    }
                }
            }
        }
    }
}
