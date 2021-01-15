using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController_Endless : MonoBehaviour {
    Image img;
    Image img1;
    Image img2;
    Image img3;
    GameObject damage_hit;
    Player_damage_Endless script;
    GameObject warning;
    Warning3 script2;
    int scene_cnt;

    void Start()
    {
        
        damage_hit = GameObject.Find("damage_hit");
        script = damage_hit.GetComponent<Player_damage_Endless>();
        warning = GameObject.Find("Warning");
        script2 = warning.GetComponent<Warning3>();

        img = GetComponent<Image>();
        img.color = Color.clear;

        img1 = GetComponent<Image>();
        img1.color = Color.clear;

        img2 = GetComponent<Image>();
        img2.color = Color.clear;

        img3 = GetComponent<Image>();
        img3.color = Color.clear;
        Debug.Log("AA:" + scene_cnt);
    }

    void Update()
    {
        bool flush_f = script.hit_check1;
        bool warning_OK = script2.warning_OK;
        if (flush_f == true)
        {
            this.img.color = new Color(0.5f, 0f, 0f, 0.5f);
        }
        else
        {
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
        }
        if (warning_OK == true)
        {
            scene_cnt = GameStartText.Set_num();
            if (scene_cnt == 0)
            {
                this.img1.color = new Color(1.0f, 0f, 0f, 0.5f);
                this.img1.color = Color.Lerp(this.img1.color, Color.clear, Mathf.PingPong(Time.time * 2.0f, 1.0F));
            }
            if (scene_cnt == 1)
            {
                this.img2.color = new Color(0f, 1.0f, 0f, 0.5f);
                this.img2.color = Color.Lerp(this.img2.color, Color.clear, Mathf.PingPong(Time.time * 2.0f, 1.0F));
            }
            if (scene_cnt == 2)
            {
                this.img3.color = new Color(0f, 0f, 1.0f, 0.5f);
                this.img3.color = Color.Lerp(this.img3.color, Color.clear, Mathf.PingPong(Time.time * 2.0f, 1.0F));
            }
        }
    }
}
