using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move_Endless : MonoBehaviour
{

    SpriteRenderer MainSpriteRenderer;
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
    float timer;
    int space_cnt;
    private float nextTime;
    public float interval;   // 点滅周期
    int time_cnt;

    public bool hit_check1 = false;  //敵と自分が当たった時のフラグ（ここ変更点）
    public bool space_check = false;

    bool time_f = false;
    private AudioSource sound01;
    private AudioSource sound02;

    Color alpha;

    GameObject HeartObj1;
    GameObject HeartObj2;
    GameObject HeartObj3;
    GameObject HeartObj4;
    GameObject HeartObj5;
    GameObject HeartObj6;

    //public static int damage_cnt;                 //ダメージを受けた回数

    public Skeleton_f skeleton;


    public Image UIobj;
    public Text UItex;
    public bool roop;
    public int count;
    public float countTime = 5.0f;

    public float amountcount;

    //public GameObject super_shot;
    public bool super_shot_f;
    public int gauge_check;
    public float TimeCount = 5;

    GameObject GameStart;
    GameStartText script;

    bool GameStart_f;

    public GameObject comboActive;
    public GameObject comboLabelActive;
    float combo_timer;  //コンボの文字の表示時間
    bool combo_f;   //コンボの文字を表示・非表示のフラグ
    public bool combo_score_f; //コンボが失敗したかの判定用のフラグ

    GameObject Canvas;
    Combo_Endless script2;

    public GameObject TextPlus;
    public GameObject ComboTextPlus;

    bool space_not;

    GameObject EXPL1;

    GameObject stage_fade;
    Stage_Fade_Endless_Next script4;
    bool StageFade_f;

    public float thrust;
    public GameObject shot;
    private AudioSource sound03;
    GameObject shell;
    string Scene_name;

    [SerializeField] ContactFilter2D filter2d;
    bool isTouched = false;
    int lv;
    public int life = 0;
    //bool life_cnt_f;    //ハートが増えていいかの判定フラグ

    GameObject HPSystem;
    //最大HP、半端な数にした
    int tired_timer_num;
    //現在のHP
    [SerializeField]
    float tired_timer = 0;

    public GameObject UI_obj;
    public GameObject gauge;
    public GameObject TextAnim_ComboLabel;
    public GameObject TextAnim_Combo;
    bool combo_Endless_add1;
    bool combo_Endless_add2;
    bool combo_Endless_add3;
    bool combo_Endless_add4;
    bool player_show = true;
    void Start()
    {
        //AdMobManager.instance.RequestBanner();
        Scene_name = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("Scene_name", Scene_name);
        //AdMobManager.instance.RequestBanner();
        //このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        timer = 0;
        space_cnt = 0;
        nextTime = Time.time;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
        HeartObj1 = GameObject.Find("heart1");  //はじめに消えるハート
        HeartObj2 = GameObject.Find("heart2");  //2番目に消えるハート
        HeartObj3 = GameObject.Find("heart3");  //最後に消えるハート
        HeartObj4 = GameObject.Find("heart4");  //heart1の隣のハート
        HeartObj5 = GameObject.Find("heart5");  //heart4の隣のハート　
        HeartObj6 = GameObject.Find("heart6");  //heart5の隣のハート
        //damage_cnt = 0;
        gauge_check = 0;
        GameStart = GameObject.Find("GameStart");
        script = GameStart.GetComponent<GameStartText>();
        comboActive.SetActive(false);
        comboLabelActive.SetActive(false);
        combo_f = false;
        combo_score_f = false;
        Canvas = GameObject.Find("Canvas");
        script2 = Canvas.GetComponent<Combo_Endless>();
        TextPlus.SetActive(false);
        ComboTextPlus.SetActive(false);
        tired_timer = 0;
        space_not = false;
        EXPL1 = GameObject.Find("EXPL1");
        //damage_cnt = Move_Endless.getDamage_cnt();
        stage_fade = GameObject.Find("stage_fade");
        script4 = stage_fade.GetComponent<Stage_Fade_Endless_Next>();
        sound03 = audioSources[2];
        life = PlayerPrefs.GetInt("Heart", 3);
        if(life == 3)
        {
            HeartObj1.SetActive(true);
            HeartObj2.SetActive(true);
            HeartObj3.SetActive(true);
        }
        if (life == 2)
        {
            HeartObj1.SetActive(false);
            HeartObj2.SetActive(true);
            HeartObj3.SetActive(true);
        }
        if (life == 1)
        {
            HeartObj1.SetActive(false);
            HeartObj2.SetActive(false);
            HeartObj3.SetActive(true);
        }
        //------超人化---------------
        lv = PlayerPrefs.GetInt("lv_6", 1);
        if (lv >= 1 && lv < 30)
        {
            tired_timer_num = 4;
        }
        if (lv >= 30 && lv < 60)
        {
            tired_timer_num = 3;
        }
        if (lv >= 60 && lv < 90)
        {
            tired_timer_num = 2;
        }
        if (lv >= 90 && lv < 100)
        {
            tired_timer_num = 2;
        }
        if (lv >= 100)
        {
            tired_timer_num = 1;
        }
        //------超人化（終わり）---------------
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
        combo_Endless_add1 = Skeleton_f_Endless.Get_Combo_Endless1();
        combo_Endless_add2 = Skeleton_n_Endless.Get_Combo_Endless2();
        combo_Endless_add3 = Skeleton_s_Endless.Get_Combo_Endless3();
        combo_Endless_add4 = Skeleton_s_gold_Endless.Get_Combo_Endless4();
        GameStart_f = script.GS_f;
        StageFade_f = script4.SF_f;
        
        
        /*
        if (life_cnt_f == true && life_cnt < 6)
        {
            Debug.Log("OOOOO");
            life_cnt++;
            life_cnt_f = false;
        }
        */

        if (GameStart_f == true || StageFade_f == true)
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

        grounded = Physics2D.Linecast(transform.position, transform.position - transform.up * 5.0f, groundlayer);
        //isTouched = GetComponent<Rigidbody2D>().IsTouching(filter2d);
        timer += Time.deltaTime;
        //攻撃処理
        //Debug.Log("space_cnt" + space_cnt);
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
            if (combo_timer >= 2.0f)
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
                Renderer ren = gameObject.GetComponent<Renderer>();
                ren.enabled = !ren.enabled;
                nextTime += interval;
                time_cnt++;
                if (time_cnt == 40){
                    time_cnt = 0;
                    time_f = false;
                    hit_check1 = false;
                }
            }
        }
        /*
        if (bless_ff == true){
            hit_check1 = true;
            time_f = true;
            if (life > 0)
            {
                life -= 1;
            }
            PlayerPrefs.SetInt("Heart", life);
            PlayerPrefs.Save();
            sound02.PlayOneShot(sound02.clip);
            combo_score_f = true;
            TextPlus.SetActive(true);
            ComboTextPlus.SetActive(true);
            script2.Combo_Score();
            if (life <= 0)
            {
                SceneManager.LoadScene("GameOver_Endless");
                //SceneManager.LoadScene("Reward");
            }
        }
        */
        if (combo_Endless_add1 == true || combo_Endless_add2 == true || combo_Endless_add3 == true || combo_Endless_add4 == true)
        {
            //コンボ成立
            comboActive.SetActive(true);
            comboLabelActive.SetActive(true);
            FindObjectOfType<Combo_Endless>().AddPoint(1);
            TextAnim_ComboLabel.GetComponent<TypefaceAnimator>().Play();
            TextAnim_Combo.GetComponent<TypefaceAnimator>().Play();
            combo_f = true;
            combo_timer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //--------------------------
        /*
        if (c.tag == "Skeleton" && space_check == false || c.tag == "fire" && space_check == false)
        { //敵と自分が当たった（ダメージを受けた時）
            hit_check1 = true;
            time_f = true;
            if (damage_cnt < 3)
            {
                damage_cnt++;
            }
            sound02.PlayOneShot(sound02.clip);
            combo_score_f = true;
            TextPlus.SetActive(true);
            ComboTextPlus.SetActive(true);
            script2.Combo_Score();
            if (damage_cnt == 1)
            {
                HeartObj1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha.a);
            }
            if (damage_cnt == 2)
            {
                HeartObj2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha.a);
            }
            if (damage_cnt >= 3)
            {
                HeartObj3.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha.a);
                //公開するときは、以下の2行をコメントアウト
                //AdMobManager.instance.DestroyBanner();    // この行はコメントのまま
                SceneManager.LoadScene("GameOver_Endless");
            }
        }
        */
        /*
        if (c.tag == "Skeleton" && space_check == true && super_shot_f == false)
        {
            //コンボ成立
            combo_f = true;
            combo_timer = 0;
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Hit_Check")
        {
            MainSpriteRenderer.sprite = WaitbySprite;
            timer = 0;
        }
        /*
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
        */
    }
    public void Jump()  //Cキー
    {
        if (jump == false && player_show == true)
        {
            if (grounded && space_not == false)
            {
                space_cnt = 0;
                rb2d.AddForce(Vector2.up * flap);
                MainSpriteRenderer.sprite = Attack1bySprite;
                sound01.PlayOneShot(sound01.clip);
                //jump = true;
            }
        }
    }

    public void Attack()    //スペースキー
    {
        if (player_show == true)
        {
            //spaceキーの押した回数を数え、attack２のスプライトに変更
            if (space_not == false)  //Joy-Con(R)のAボタン
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
                    sound03.PlayOneShot(sound03.clip);
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
