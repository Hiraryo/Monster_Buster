using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_damage_How_to_Play : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSources;
    [SerializeField]
    Renderer ren;
    public AudioClip sound02;
    bool time_f = false;
    public bool hit_check1 = false;  //敵と自分が当たった時のフラグ（ここ変更点）
    public bool space_check = false;
    Color alpha;
    int time_cnt;
    public float interval;   // 点滅周期
    private float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit_check1 == true)
        {//敵に当たった時、点滅処理
            if (Time.time > nextTime && time_cnt < 40 && time_f == true)
            {
                ren.enabled = !ren.enabled;
                nextTime += interval;
                time_cnt++;
                if (time_cnt == 40)
                {
                    time_cnt = 0;
                    time_f = false;
                    hit_check1 = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //--------------------------
        if (c.tag == "Skeleton_damage_hit" && space_check == false || c.tag == "fire" && space_check == false)
        { //敵と自分が当たった（ダメージを受けた時）
            hit_check1 = true;
            time_f = true;
            //sound02.PlayOneShot(sound02.clip);
            audioSources.PlayOneShot(sound02);
        }
    }
}
