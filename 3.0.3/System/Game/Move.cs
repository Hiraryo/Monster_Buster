using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Move : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer MainSpriteRenderer;
    [SerializeField]
    AudioSource audioSources;
    [SerializeField]
    GameStartText_No_Endless script;
    [SerializeField]
    Combo script2;
    [SerializeField]
    Renderer ren;
    [SerializeField]
    SpriteRenderer HeartObj1;
    [SerializeField]
    SpriteRenderer HeartObj2;
    [SerializeField]
    SpriteRenderer HeartObj3;
    //Publicで宣言し、inspectorで設定可能にする
    public Sprite WaitbySprite;
    public Sprite Attack1bySprite;
    public Sprite Attack2bySprite;
    public Sprite TiredbySprite;
    Rigidbody2D rb2d;
    public float flap = 1500f;
    public bool grounded = false;
    bool jump = false;
    public LayerMask groundlayer;
    int space_cnt;
    private float nextTime;
    public float interval;   // 点滅周期
    int time_cnt;
    

    public bool hit_check1 = false;  //敵と自分が当たった時のフラグ（ここ変更点）
    public bool space_check = false;

    bool time_f = false;

    public AudioClip sound01;
    public AudioClip sound02;
    public AudioClip sound03;

    Color alpha;
    int damage_cnt;                 //ダメージを受けた回数
    int vibration_time;             //バイブレーションの実行時間

    public Skeleton_f skeleton;


    public Image UIobj;
    public Text UItex;
    public bool roop;
    public int count;
    public float countTime = 5.0f;

    public float amountcount;
    public bool super_shot_f;
    public int gauge_check;
    public float TimeCount = 5;

    GameObject GameStart;
    float timer;
    bool GameStart_f;

    public GameObject comboActive;
    public GameObject comboLabelActive;
    float combo_timer;  //コンボの文字の表示時間
    bool combo_f;   //コンボの文字を表示・非表示のフラグ
    public bool combo_score_f; //コンボが失敗したかの判定用のフラグ

    GameObject Canvas;
    public GameObject TextPlus;
    public GameObject ComboTextPlus;

    bool space_not;

    GameObject EXPL1;
    public float thrust;

    public GameObject shot;
    GameObject shell;

    int Reward_CHECK;
    int count2;
    int count3;
    string Scene_name;

    GameObject HPSystem;
    //最大HP、半端な数にした
    [SerializeField]
    int tired_timer_num;
    //現在のHP
    [SerializeField]
    float tired_timer = 0;
    public Vector3 flick_startPos; //フリック始点
    public Vector3 flick_endPos;    //フリック終点

    public GameObject UI_obj;
    public GameObject gauge;
    public GameObject TextAnim_ComboLabel;
    public GameObject TextAnim_Combo;
    bool combo_add1;
    bool combo_add2;
    bool combo_add3;
    bool combo_add4;
    bool player_show = true;
    void Start()
    {
        Scene_name = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("Scene_name", Scene_name);
        vibration_time = 0;
        rb2d = GetComponent<Rigidbody2D>();
        space_cnt = 0;
        nextTime = Time.time;
        damage_cnt = 0;
        gauge_check = 0;
        GameStart = GameObject.Find("GameStart");
        comboActive.SetActive(false);
        comboLabelActive.SetActive(false);
        combo_f = false;
        combo_score_f = false;
        Canvas = GameObject.Find("Canvas");
        TextPlus.SetActive(false);
        ComboTextPlus.SetActive(false);
        space_not = false;
        EXPL1 = GameObject.Find("EXPL1");
        count2 = 0;
        count3 = 0;
        HPSystem = GameObject.Find("HPSystem");
        UI_obj.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Jump();
        }
        if (GetComponent<SpriteRenderer>().isVisible)
        {
            player_show = true;
        }
        else
        {
            player_show = false;
        }
        combo_add1 = Skeleton_f.Get_Combo1();
        combo_add2 = Skeleton_n.Get_Combo2();
        combo_add3 = Skeleton_s.Get_Combo3();
        combo_add4 = Skeleton_s_gold.Get_Combo4();
        GameStart_f = script.GS_f;
        if (GameStart_f == true)
        {
            if (count > 0)
            {
                amountcount = UIobj.fillAmount;
                UItex.text = string.Format("" + count);
                super_shot_f = false;
                gauge_check = 0;
                if (roop)
                {
                    //Reduce fill amount over 30 seconds
                    UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
                }
                else if (!roop)
                {
                    UIobj.fillAmount += 1.0f / countTime * Time.deltaTime;
                }

                if (UIobj.fillAmount == 0 || UIobj.fillAmount == 1)
                {
                    count = count - 1;
                    UIobj.fillClockwise = !UIobj.fillClockwise;
                    roop = !roop;
                }
            }
            if (count == 0){
                UItex.text = string.Format("OK");
            }
        }

        grounded = Physics2D.Linecast(transform.position, transform.position - transform.up * 100.0f, groundlayer);
        timer += Time.deltaTime;
        //ジャンプの処理
        if (space_cnt >= 8 && tired_timer <= 2.0f){ //2秒間にスペースキーを8回押されると、動けなくなる。
            space_not = true;
            tired_timer = tired_timer_num;
            space_cnt = 0;
            
        }
        if (tired_timer > 2.0f && space_not == false)
        {
            space_cnt = 0;
            tired_timer = 0;
        }
        if (space_not == true){
            UI_obj.SetActive(true);
            space_check = false;
            MainSpriteRenderer.sprite = TiredbySprite;
            tired_timer -= Time.deltaTime;
            gauge.GetComponent<Image>().fillAmount = tired_timer / tired_timer_num;
            float _currentTired = tired_timer / tired_timer_num;
            float currentTired_percent = _currentTired * 100;
            if (60.0f <= currentTired_percent)
            {
                gauge.GetComponent<Image>().color = Color.red;
            }
            if (60.0f > currentTired_percent)
            {
                gauge.GetComponent<Image>().color = Color.blue;
            }
            if (30.0f > currentTired_percent)
            {
                gauge.GetComponent<Image>().color = Color.yellow;
            }
            
            if (tired_timer < 0)
            {
                UI_obj.SetActive(false);
                space_not = false;
                space_cnt = 0;
                tired_timer = 0;
                MainSpriteRenderer.sprite = WaitbySprite;
            }
        }
        if (space_cnt >= 1 && space_not == false)
        {
            //攻撃処理
            tired_timer += Time.deltaTime;
        }
        //コンボ文字の非表示処理
        if (combo_f == true){
            combo_timer += Time.deltaTime;
            if (combo_timer >= 1.0f)
            {
                comboActive.SetActive(false);
                comboLabelActive.SetActive(false);
                combo_f = false;
                combo_timer = 0;

                TextPlus.SetActive(false);
                ComboTextPlus.SetActive(false);
            }
        }

        //0.5秒間スペースキーを押さなかった場合
        if (timer > 0.5f && space_not == false)
        {
            space_check = false;
            MainSpriteRenderer.sprite = WaitbySprite;
        }

        if (hit_check1 == true)
        {//敵に当たった時、点滅処理
            if (Time.time > nextTime && time_cnt < 40 && time_f == true )
            {
                ren.enabled = !ren.enabled;
                nextTime += interval;
                time_cnt++;
                if (time_cnt == 40){
                    time_cnt = 0;
                    time_f = false;
                    hit_check1 = false;
                    vibration_time = 0;
                }
            }
        }
        if(combo_add1 == true || combo_add2 == true || combo_add3 == true || combo_add4 == true)
        {
            //コンボ成立
            comboActive.SetActive(true);
            comboLabelActive.SetActive(true);
            FindObjectOfType<Combo>().AddPoint(1);
            TextAnim_ComboLabel.GetComponent<TypefaceAnimator>().Play();
            TextAnim_Combo.GetComponent<TypefaceAnimator>().Play();
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Skeleton" && space_check == true && super_shot_f == false)
        {
            //コンボ成立
            combo_f = true;
            combo_timer = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Hit_Check")
        {
            MainSpriteRenderer.sprite = WaitbySprite;
            timer = 0;
        }
    }

    public void Jump()  //Cキー
    {
        if (jump == false && player_show == true)
        {
            Debug.Log("Jump OK!!");
            if (grounded && space_not == false)
            {
                
                space_cnt = 0;
                rb2d.AddForce(Vector2.up * flap);
                MainSpriteRenderer.sprite = Attack1bySprite;
                audioSources.PlayOneShot(sound01);
            }
        }
    }

    public void Flick()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            flick_startPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            flick_endPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,Input.mousePosition.z);
            float directionX = flick_endPos.x - flick_startPos.x;
            float directionY = flick_endPos.y - flick_startPos.y;
            float radian = Mathf.Atan2(directionY, directionX) * Mathf.Rad2Deg;
            if (radian < 0)
            {
                Debug.Log("radian : " + (radian + 360));    //フリック角度をConsoleに表示
            }
            else
            {
                Debug.Log("radian : " + radian);    //フリック角度をConsoleに表示
            }
            
            string direction = "";
            if (radian < 0)
            {
                radian += 360;    //マイナスのものは360を加算
            }
            
            //方向指定
            if (radian <= 22.5f || radian > 337.5f)
            {
                direction = "a";
            }
            else if (radian <= 67.5f && radian > 22.5f)
            {
                direction = "b";
            }
            else if(radian <= 112.5f && radian > 67.5f)
            {
                direction = "c";
            }
            else if(radian <= 157.5f && radian > 112.5f)
            {
                direction = "d";
            }
            else if(radian <= 202.5f && radian > 157.5f)
            {
                direction = "e";
            }
            else if(radian <= 247.5f && radian > 202.5f)
            {
                direction = "f";
            }
            else if(radian <= 292.5f && radian > 247.5f)
            {
                direction = "g";
            }
            else if(radian <= 337.5f && radian > 292.5f)
            {
                direction = "h";
            }
            Debug.Log("direction : " + direction);
        }
    }

    public void Attack()    //スペースキー
    {
        Flick();
        if(player_show == true)
        {
            //spaceキーの押した回数を数え、attack２のスプライトに変更
            if (space_not == false)
            {
                space_check = true;
                combo_score_f = false;  //コンボ不成立
                combo_timer = 0;
                space_cnt++;
                MainSpriteRenderer.sprite = Attack2bySprite;
            }

            if (count == 0)
            {
                if (space_not == false)
                {
                    // プレファブから砲弾(Shell)オブジェクトを作成し、それをshellという名前の箱に入れる。
                    shell = (GameObject)Instantiate(shot, transform.position, Quaternion.identity);

                    // Rigidbodyの情報を取得し、それをshellRigidbodyという名前の箱に入れる。
                    Rigidbody2D shellRigidbody = shell.GetComponent<Rigidbody2D>();

                    // shellRigidbodyにz軸方向の力を加える。
                    shellRigidbody.AddForce(transform.right * thrust);
                    //sound03.PlayOneShot(sound03.clip);
                    audioSources.PlayOneShot(sound03);
                    //波動拳
                    gauge_check = 1;
                    super_shot_f = true;    //フラグを立てる 
                    count = 2;
                }
            }
            if (space_not == false)
            {
                //スペースキーを押した回数が偶数の時
                if (space_cnt % 2 == 0)
                {
                    timer = 0;
                    //スプライトの変更
                    MainSpriteRenderer.sprite = Attack1bySprite;
                }
                //スペースキーを押した回数が奇数の時
                if (space_cnt % 2 == 1)
                {
                    timer = 0;
                    //スプライトの変更
                    MainSpriteRenderer.sprite = Attack2bySprite;
                }
            }
        }
    }
}
