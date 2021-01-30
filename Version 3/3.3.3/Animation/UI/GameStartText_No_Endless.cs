using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartText_No_Endless : MonoBehaviour
{
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
    int scene_cnt;
    // Use this for initialization
    void Start()
    {
        scene_cnt = Quest_Easy.Set_Scene_Num();
        Debug.Log("scene_cnt == " + scene_cnt);
        if (scene_cnt == 1)
        {
            stage_sound1.SetActive(true);
        }
        if (scene_cnt == 2)
        {
            stage_sound2.SetActive(true);
        }
        if (scene_cnt == 3)
        {
            stage_sound3.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
        if (pos.x > 0)
        {
            pos.x -= GS_move_x;
        }
        if (pos.x <= 0)
        {
            if (anime_f == false)
            {
                GetComponent<TypefaceAnimator>().Play();
                anime_f = true;
            }
            timer += Time.deltaTime;
        }
        if (timer >= 2.0f)
        {
            GS_move_x = 230.0f;
            pos.x -= GS_move_x;
        }
        if (pos.x <= -6000)
        {
            GS_f = true;
            pos.x = -6000;
            jump_button.SetActive(true);
            attack_button.SetActive(true);
        }
        GetComponent<RectTransform>().anchoredPosition = pos;
    }
}
