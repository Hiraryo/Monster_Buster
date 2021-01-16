using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_n_How_to_Play : MonoBehaviour {

    float move_x = -7.0f;
    Collider2D s_Object;

    bool space_check_f = false;
    //public Rigidbody2D rb;
    int count;

    GameObject c_wait;   //skeleton_fが入る変数
    Move_How_to_Play script;                //moveの名前のスクリプトが入る変数

    private AudioSource sound01;

    SpriteRenderer MainSpriteRenderer;
    public Sprite DebrisbySprite;
    float debris_time;
    int player_hit_f = 0;
    // Use this for initialization
    void Start()
    {
        c_wait = GameObject.Find("c_wait");   //c_waitをオブジェクトの名前から取得して変数に格納する
        script = c_wait.GetComponent<Move_How_to_Play>();        //c_waitの中にあるmoveを取得して変数に格納する
        sound01 = GetComponent<AudioSource>();

        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        debris_time = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 2)
        {
            transform.Translate(move_x, 0, 0);
        }
        space_check_f = script.space_check;    //新しく変数を宣言してその中にmoveの変数space_checkを代入する。
        transform.Translate(move_x, 0, 0);
        if (!GetComponent<SpriteRenderer>().isVisible && transform.position.x <= 0)
        {
            Destroy(gameObject);
        }

        if (count >= 2)
        {
            Destroy(GetComponent<Animator>());
            MainSpriteRenderer.sprite = DebrisbySprite;
            debris_time += Time.deltaTime;
            if (debris_time >= 2.0f)
            {
                debris_time = 0;
                Destroy(gameObject);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player" && space_check_f == true) //敵にダメージを与えた時
        {
            s_Object = GetComponent<Collider2D>();
            s_Object.isTrigger = false;
            if (count < 3)
            {
                move_x = 7.5f;
            }
            player_hit_f++;
            if (player_hit_f == 1 && count < 2)
            {
                Invoke("Skeske", 1);
                sound01.PlayOneShot(sound01.clip);
            }
        }
        if (c.tag == "Super_Shot")
        {
            sound01.PlayOneShot(sound01.clip);
            Destroy(gameObject);
        }
    }

    void Skeske()
    {
        move_x = -7.0f;
        s_Object.isTrigger = true;
        space_check_f = false;
        count = count + 1;
        player_hit_f = 0;
        if (count >= 2)
        {
            Destroy(gameObject);
        }
    }
}
