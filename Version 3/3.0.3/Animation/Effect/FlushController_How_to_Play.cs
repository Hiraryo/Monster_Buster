using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController_How_to_Play : MonoBehaviour {

    Image img;

    GameObject c_wait;
    Move_How_to_Play script;

    void Start()
    {
        c_wait = GameObject.Find("c_wait");
        script = c_wait.GetComponent<Move_How_to_Play>();

        img = GetComponent<Image>();
        img.color = Color.clear;
    }

    void Update()
    {
        bool flush_f = script.hit_check1;
        if (flush_f == true)
        {
            this.img.color = new Color(0.5f, 0f, 0f, 0.5f);
        }
        else
        {
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
        }
    }
}
