using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Big_s_gold : MonoBehaviour
{
    float move_x = -0.4f;
    Collider2D s_Object;

    bool space_check_f = false;
    //public Rigidbody2D rb;
    int count;

    GameObject c_wait;   //skeleton_fが入る変数
    Move_Endless script;                //moveの名前のスクリプトが入る変数

    private AudioSource sound01;
    SpriteRenderer MainSpriteRenderer;
    public Sprite DebrisbySprite;
    float debris_time;
    int player_hit_f = 0;
    int point = 5000;
    public GameObject Clear_Text;
    SpriteRenderer spriteRenderer;
    int speed_num;
    public GameObject Not_Clear_Text;
    public static bool Bonus_end_f;
    public static int Bonus;
    public GameObject Skill_1;
    public GameObject Skill_1_Back;
    public GameObject Skill_2;
    public GameObject Skill_2_Back;
    public GameObject Skill_3;
    public GameObject Skill_3_Back;
    public GameObject Skill_4;
    public GameObject Skill_4_Back;
    public GameObject Skill_5;
    public GameObject Skill_5_Back;
    int skill_random1 = 0;
    int skill_random2 = 0;
    int skill_random3 = 0;
    int skill_random4 = 0;
    int skill_random5 = 0;
    Vector3 pos;
    int start = 1;
    int end = 6;
    int ransu_cnt = 0;
    int numbers1;
    int numbers2;
    int numbers3;
    int numbers4;
    int numbers5;
    int card_count;
    float Shwo_time = 0f;
    List<int> ransu = new List<int>();
    int you_score;
    // Use this for initialization
    void Start()
    {
        Bonus = 0;
        Bonus_end_f = false;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        c_wait = GameObject.Find("c_wait");   //c_waitをオブジェクトの名前から取得して変数に格納する
        script = c_wait.GetComponent<Move_Endless>();        //c_waitの中にあるmoveを取得して変数に格納する
        sound01 = GetComponent<AudioSource>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        debris_time = 0;
        count = 0;
        Clear_Text.SetActive(false);
        Not_Clear_Text.SetActive(false);
        //1〜5を重複なくランダムで出力
        numbers1 = Random.Range(-1, 2);
        skill_random1 = numbers1;
        for (; ; )
        {
            numbers2 = Random.Range(-1, 2);
            if (numbers2 == numbers1)
            {
                continue;
            }
            else
            {
                skill_random2 = numbers2;
                break;
            }
        }
        for (; ; )
        {
            numbers3 = Random.Range(-1, 2);
            if (numbers3 == numbers2 || numbers3 == numbers1)
            {
                continue;
            }
            else
            {
                skill_random3 = numbers3;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 5)
        {
            transform.Translate(move_x, 0, 0);
        }
        space_check_f = script.space_check;    //新しく変数を宣言してその中にmoveの変数space_checkを代入する。
        //--------------------------
        if (!GetComponent<SpriteRenderer>().isVisible && transform.position.x <= 0)
        {
            //画面外にいる時
            spriteRenderer.color = new Color(1, 1, 1, 0);
            Not_Clear_Text.SetActive(true);
            Not_Clear_Text.transform.DOLocalMoveY(0f, 0.6f).OnComplete(() =>
            {
                Bonus_end_f = true;
                Bonus = Random.Range(0, 5);
                SceneManager.LoadScene("endless");
                
            });
        }
        //--------------------------

        if (count >= 5)
        {
            Destroy(GetComponent<Animator>());
            MainSpriteRenderer.sprite = DebrisbySprite;
            debris_time += Time.deltaTime;
            if (debris_time >= 1.5f)
            {
                //count = 100;
                //debris_time = 0;
                spriteRenderer.color = new Color(1, 1, 1, 0);
                if(debris_time < 2.5f)
                {
                    Clear_Text.SetActive(true);
                }
                
                
                Clear_Text.transform.DOScale(endValue: new Vector2(0.35f, 0.35f), duration: 0.6f).OnComplete(() =>
                {
                    //--------スキルのシャッフルボーナスをつけるなら下の1行をコメントアウト
                    //Clear_Text.SetActive(false);
                    //----------------------------------------------------------
                    //--------スキルのシャッフルボーナスのテストを行いたいならこの範囲をコメント
                    Bonus_end_f = true;
                    Bonus = Random.Range(0, 5);
                    SceneManager.LoadScene("endless");
                    
                    //----------------------------------------------
                });

                //--------スキルのシャッフルボーナスをつけるならこの範囲をコメントアウト
                /*
                if (debris_time >= 3.0f)
                {
                    Debug.Log("2.5s");
                    Skill_1.SetActive(true);
                    Skill_2.SetActive(true);
                    Skill_3.SetActive(true);
                    Skill_4.SetActive(true);
                    Skill_5.SetActive(true);
                    Debug.Log("Skill_1 = " + skill_random1);
                    Sequence sequence = DOTween.Sequence()
                        .OnStart(() =>
                        {
                            Skill_1.transform.DOLocalMoveX(240f * skill_random1, 1.5f);
                        }).Join(
                            Skill_2.transform.DOLocalMoveX(240f * skill_random2, 1.5f)
                        ).Join(
                            Skill_3.transform.DOLocalMoveX(240f * skill_random3, 1.5f)
                        ).Join(
                            Skill_4.transform.DOLocalMoveX(240f * skill_random4, 1.5f)
                        ).Join(
                            Skill_5.transform.DOLocalMoveX(240f * skill_random5, 1.5f)
                        );
                }
                */
                //------------------------------------------------------------
            }
        }
    }
    void OnTriggerStay2D(Collider2D c)
    {
        if (c.tag == "Player" && space_check_f == true) //敵にダメージを与えた時
        {

            s_Object = GetComponent<Collider2D>();
            s_Object.isTrigger = false;
            if (count < 5)
            {
                move_x = 0.4f;
            }
            player_hit_f++;
            if (player_hit_f == 1 && count < 5)
            {
                Invoke("Skeske", 1);
                sound01.PlayOneShot(sound01.clip);
            }
        }
    }

    void Skeske()
    {
        speed_num = Random.Range(0, 4);
        if(speed_num == 0)
        {
            move_x = -3.0f;
        }
        if (speed_num == 1)
        {
            move_x = -2.0f;
        }
        if (speed_num == 2)
        {
            move_x = -4.0f;
        }
        if (speed_num == 3)
        {
            move_x = -1.0f;
        }
        s_Object.isTrigger = true;
        space_check_f = false;
        count = count + 1;
        player_hit_f = 0;
        if (count >= 5)
        {
            FindObjectOfType<Score_Endless>().AddPoint(point);
            you_score = Score_Endless.getScore();
            // スコアを保存する
            PlayerPrefs.SetInt("Score", you_score);
            PlayerPrefs.Save();
        }
    }

    public static bool Set_Bonus_END()
    {
        return Bonus_end_f;
    }

    public static int Set_Bonus()
    {
        return Bonus;
    }
}
