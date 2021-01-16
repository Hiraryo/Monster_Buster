using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move_How_to_Play : MonoBehaviour
{
    [SerializeField]
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

    int damage_cnt;                 //ダメージを受けた回数

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
    [SerializeField]
    float tired_timer = 0;
    bool space_not;

    public float thrust;
    public GameObject shot;
    private AudioSource sound03;
    GameObject shell;
    public GameObject UI_obj;
    public GameObject gauge;
    [SerializeField]
    int tired_timer_num;
    void Start()
    {
        //AdMobManager.instance.DestroyBanner();
        //このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        timer = 0;
        space_cnt = 0;
        nextTime = Time.time;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
        sound03 = audioSources[2];
        damage_cnt = 0;
        gauge_check = 0;

        //tired_timer = 0;
        space_not = false;
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
        if (count > 0)
        {
            amountcount = UIobj.fillAmount;
            UItex.text = string.Format("" + count);
            super_shot_f = false;
            gauge_check = 0;
            //TimeCount = 1;
            //super_shot.SetActive(false);
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
            if (count == 0)
            {
                UItex.text = string.Format("OK");
            }
        }
        grounded = Physics2D.Linecast(transform.position, transform.position - transform.up * 100.0f, groundlayer);
        timer += Time.deltaTime;
        //攻撃処理
        //tired_timer += Time.deltaTime;
        if (space_cnt == 8 && tired_timer <= 2.0f)
        { //2秒間にスペースキーを8回押されると、動けなくなる。
            space_not = true;
            tired_timer = tired_timer_num;
            space_cnt = 0;
        }
        if (tired_timer > 2.0f && space_not == false)
        {
            space_cnt = 0;
            tired_timer = 0;
        }
        if (space_not == true)
        {
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
        //0.5秒間スペースキーを押さなかった場合
        if (timer > 0.5f && space_not == false)
        {
            space_check = false;
            MainSpriteRenderer.sprite = WaitbySprite;
        }

        if (hit_check1 == true)
        {//敵に当たった時、点滅処理
            if (Time.time > nextTime && time_cnt < 40 && time_f == true)
            {
                Renderer ren = gameObject.GetComponent<Renderer>();
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
        /*
        //--------------------------
        if (c.tag == "Skeleton" && space_check == false)
        { //敵と自分が当たった（ダメージを受けた時）
            hit_check1 = true;
            time_f = true;
            damage_cnt++;
            sound02.PlayOneShot(sound02.clip);
        }
        //--------------------------
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
        if (jump == false)
        {
            Debug.Log("Jump OK!!");
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
        //spaceキーの押した回数を数え、attack２のスプライトに変更
        if (space_not == false)  //Joy-Con(R)のAボタン
        {
            space_check = true;
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
