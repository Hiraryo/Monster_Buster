using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_preview_move : MonoBehaviour
{
    float time;

    public GameObject Fade;

    public static bool dragon_preview_f;

    GameObject Warning;
    Warning script1;
    int get_num;
    public GameObject dragon_pre_Red;
    public GameObject dragon_pre_Green;
    public GameObject dragon_pre_Blue;
    // Use this for initialization
    void Start()
    {
        get_num = Quest_Easy.Set_Scene_Num();
        if (get_num == 1)
        {
            dragon_pre_Red.SetActive(true);
            dragon_pre_Green.SetActive(false);
            dragon_pre_Blue.SetActive(false);
        }
        if (get_num == 2)
        {
            dragon_pre_Red.SetActive(false);
            dragon_pre_Green.SetActive(true);
            dragon_pre_Blue.SetActive(false);
        }
        if (get_num == 3)
        {
            dragon_pre_Red.SetActive(false);
            dragon_pre_Green.SetActive(false);
            dragon_pre_Blue.SetActive(true);
        }
        time = 0;
        dragon_preview_f = false;

        Warning = GameObject.Find("Warning");
        script1 = Warning.GetComponent<Warning>();
    }

    // Update is called once per frame
    void Update()
    {
        bool d_ff = script1.d_f;
        if (d_ff == true)
        {
            time += Time.deltaTime;
            if (time >= 2.0f && transform.position.x >= 26.0f && transform.position.y >= 2186.0f)
            {
                transform.Translate(-10.0f, -10.0f, 0);
            }
            if (time >= 2.5f && Fade.transform.position.x <= 632.0f)
            {
                Fade.transform.Translate(40.0f, 0, 0);
            }
            if (Fade.transform.position.x >= 632.0f)
            {
                dragon_preview_f = true;
            }
        }
    }

    public static bool Set_Dragon_pre_f()
    {
        return dragon_preview_f;
    }
}
