using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

//クラス作成
public class MainPlayer : MonoBehaviour
{
  //メンバ変数
  [SerializeField] private GameObject UI_obj;
  [SerializeField] private GameObject gauge;
  [SerializeField] private GameObject TextAnim_ComboLabel;
  [SerializeField] private GameObject TextAnim_Combo;

  [SerializeField] private LayerMask groundlayer;
  [SerializeField] private SpriteRenderer MainSpriteRenderer;
  [SerializeField] private Sprite Attack1bySprite;
  [SerializeField] private Sprite Attack2bySprite;
  [SerializeField] private Sprite TiredbySprite;
  [SerializeField] private Sprite WaitbySprite;
  [SerializeField] private AudioSource audioSources;
  [SerializeField] private GameStartText_No_Endless script; //←この書き方はいけなさそう。GameStartText_No_Endlessのscriptメソッドを継承した書き方に変更した方が良さそう
  [SerializeField] private Renderer ren;
  [SerializeField] private AudioClip sound01;
  [SerializeField] private AudioClip sound03; //後でsound02に置換する（置換より、適切な名前に変えた方がいい）
  [SerializeField] private Image UIobj;
  [SerializeField] private Text UItex;
  [SerializeField] private GameObject comboActive;
  [SerializeField] private GameObject comboLabelActive;
  [SerializeField] private GameObject TextPlus;
  [SerializeField] private GameObject ComboTextPlus;
  [SerializeField] private GameObject shot;
  [SerializeField] private Vector3 flick_startPos;  //フリック始点
  [SerializeField] private Vector3 flick_endPos;  //フリック終点

  private Rigidbody2D rb2d;
  private GameObject GameStart;
  private GameObject Canvas;
  private GameObject EXPL1;
  private GameObject shell;

  private int _TiredTimerNum = 3; //疲れる時間
  private float _tiredTimer = 0.0f; //疲れている時間
  [SerializeField] private float _flashInterval; //元は_interval //主人公の点滅周期
  [SerializeField] private float _flap = 1500.0f; //元は_flap //ジャンプ力
  private float _thrust;  //元は_thrust
  private float _nextTime;  //元は_nextTime  //nextTime = Time.time;と書いてたから普通の変数じゃない。後で確認・修正
  
  private float _vibrationTime = 0.0f; //元は_vibration_time  //バイブレーションの実行時間
  //private float _countTime = 5.0f;  //元は_countTime
  private float _amountCount = 0.0f;  //元は_amountcount
  private float _timer = 0.0f;  //元は_timer  //各スプライト表示時間
  private float _comboTimer = 0.0f;  //元は_combo_timer  //コンボの文字の表示時間
  private float _attackButtonPressTime = 2.0f;  //アタックボタンの連打が可能な時間


  private int _AttackCount = 0; //元は_AttackCount  //スペースキーを押した回数（アタック）
  private int _FlashCount = 0;  //元は_time_cnt
  public int _Count { get; set;} = 0; //元は_count
  private int _GaugeCheck = 0; //元は_gauge_check
  private int _MaxAttackCount = 8;  //_attackButtonPressTime秒間にアタックボタンを押せる最大回数


  public bool _ComboScoreFlag { get; set; }= false; //元は_combo_score_f //コンボが失敗したかの判定用のフラグ
  private bool _JumpFlag = false; //元は_jump  //ジャンプ中かの判定
  public bool _HitCheckFlag { get; set;} = false;  //元は_hit_check1 //敵と自分が当たった時のフラグ
  public bool _AttackButtonFlag { get; set;} = false;  //元は_space_check //true : アタックボタンを押せる, false : アタックボタンを押せない
  private bool _TimeFlag = false; //元は_time_f
  //private bool _LoopFlag = false; //元は_roop
  public bool _SuperShotFlag { get; set; } = false; //元は_super_shot_f
  private bool _GameStartFlag = false;  //元は_GameStart_f
  private bool _ComboFlag = false; //元は_combo_f //コンボの文字を表示・非表示のフラグ
  private bool _NotAttackFlag = false;  //元は_space_not
  private bool _ComboAdd1 = false; //元は_combo_add1
  private bool _ComboAdd2 = false; //元は_combo_add2
  private bool _ComboAdd3 = false; //元は_combo_add3
  private bool _ComboAdd4 = false; //元は_combo_add4
  private bool _PlayerShowFlag = true; //元は_player_show
  public bool _GroundedFlag { get; set;} = false; //元は_grounded

  private string _SsceneName; //元は_Scene_name

  //メンバメソッド
  //ジャンプをする
  /*
  public void PlayerJump()
  {

  }
  */

  //コンボ処理
  /*
  public void PlayerCombo()
  {

  }
  */
  
  /*
  public void PlayerDamage()
  {

  }
  */
  void Start()
  {
    //インスタンス生成
    //Player Main_Player = new Player();
    //Main_Player.PlayerJump();
    //Main_Player.PlayerCombo();
    //Main_Player.PlayerDamage();
    _SsceneName = SceneManager.GetActiveScene().name;
    PlayerPrefs.SetString("Scene_name", _SsceneName);
    rb2d = GetComponent<Rigidbody2D>();
    _nextTime = Time.time;
    comboActive.SetActive(false);
    comboLabelActive.SetActive(false);
    TextPlus.SetActive(false);
    ComboTextPlus.SetActive(false);
    UI_obj.SetActive(false);
    Canvas = GameObject.Find("Canvas");
    EXPL1 = GameObject.Find("EXPL1");
    GameStart = GameObject.Find("GameStart");
  }

  void Update()
  {
    _ComboAdd1 = Skeleton_f.Get_Combo1();//~~~~~コンボ処理のメソッドを書く
    _ComboAdd2 = Skeleton_n.Get_Combo2();
    _ComboAdd3 = Skeleton_s.Get_Combo3();
    _ComboAdd4 = Skeleton_s_gold.Get_Combo4();
    _GameStartFlag = script.GS_f;
    _GroundedFlag = Physics2D.Linecast(transform.position, transform.position - transform.up * 100.0f,groundlayer);
    _timer += Time.deltaTime;

    _PlayerShowFlag = (GetComponent<SpriteRenderer>().isVisible) ? true : false;

    //ジャンプ処理
    if (_PlayerShowFlag == true && _JumpFlag == false && _NotAttackFlag == false)
    {
      //攻撃回数をリセット
      _AttackCount = 0;
      rb2d.AddForce(Vector2.up * _flap);
      MainSpriteRenderer.sprite = Attack1bySprite;
      audioSources.PlayOneShot(sound01);
    }
    //攻撃処理
    //動けないパターン
    //アタックボタンが _attackButtonPressTime 秒間に _MaxAttackCount 回押されたら、動けなくなる。
    if(_AttackCount >= _MaxAttackCount && _tiredTimer <= _attackButtonPressTime)
    {
      _NotAttackFlag = true;
      _tiredTimer = _TiredTimerNum;
      _AttackCount = 0;

      UI_obj.SetActive(true);
      _AttackButtonFlag = false;
      MainSpriteRenderer.sprite = TiredbySprite;
      _tiredTimer -= Time.deltaTime;
      gauge.GetComponent<Image>().fillAmount = _tiredTimer / _TiredTimerNum;
      float _currentTiredPercent = ( _tiredTimer / _TiredTimerNum ) * 100;
      if(_currentTiredPercent >= 60.0f)
      {
        gauge.GetComponent<Image>().color = Color.red;
      }
      if(_currentTiredPercent < 60.0f)
      {
        gauge.GetComponent<Image>().color = Color.blue;
      }
      if(_currentTiredPercent < 30.0f)
      {
        gauge.GetComponent<Image>().color = Color.yellow;
      }
      if(_tiredTimer < 0)
      {
        UI_obj.SetActive(false);
        _NotAttackFlag = false;
        _AttackCount = 0;
        _tiredTimer = 0;
        MainSpriteRenderer.sprite = WaitbySprite;
      }
    }
    //動けるパターン
    if(_AttackCount >= 1 && _NotAttackFlag == false)
    {
      _tiredTimer += Time.deltaTime;
      if(_tiredTimer > _attackButtonPressTime)
      {
        _AttackCount = 0;
        _tiredTimer = 0.0f;
      }
    }

    //0.5秒間スペースキーを押さなかった場合
    if(_timer > 0.5f && _NotAttackFlag == false)
    {
      _AttackButtonFlag = false;
      MainSpriteRenderer.sprite = WaitbySprite;
    }
    if(_HitCheckFlag == true && Time.time > _nextTime && _FlashCount < 40 && _TimeFlag == true)
    {
      ren.enabled = !ren.enabled;
      _nextTime += _flashInterval;
      _FlashCount++;
      if(_FlashCount == 40)
      {
        _FlashCount = 0;
        _TimeFlag = false;
        _HitCheckFlag = false;
        _vibrationTime = 0;
      }
    }
    if(_ComboAdd1 == true || _ComboAdd2 == true || _ComboAdd3 == true || _ComboAdd4 == true)
    {
      //コンボ成立
      comboActive.SetActive(true);
      comboLabelActive.SetActive(true);
      FindObjectOfType<Combo>().AddPoint(1);
      TextAnim_ComboLabel.GetComponent<TypefaceAnimator>().Play();
      TextAnim_Combo.GetComponent<TypefaceAnimator>().Play();
    }
    //コンボ文字の非表示処理
    if(_ComboFlag == true)
    {
      _comboTimer += Time.deltaTime;
      if(_comboTimer >= 1.0f)
      {
        comboActive.SetActive(false);
        comboLabelActive.SetActive(false);
        TextPlus.SetActive(false);
        ComboTextPlus.SetActive(false);
        _ComboFlag = false;
        _comboTimer = 0.0f;
      }
    }

    //波動拳処理
    if(_Count == 0 && _PlayerShowFlag == true && _NotAttackFlag == false) //波動拳を発動する為のタイマーが0になり、かつ攻撃可能な状態であるなら
    {
      //プレファブから波動拳(shot)オブジェクトを作成し、それをshellに格納する。
      shell = (GameObject)Instantiate(shot,transform.position, Quaternion.identity);
      //shellのRigidbodyを取得し、それをshellRigidbodyに格納する。
      Rigidbody2D shellRigidbody = shell.GetComponent<Rigidbody2D>();
      //shellRigidbodyにZ軸方向の力を加える。
      shellRigidbody.AddForce(transform.right * _thrust);
      audioSources.PlayOneShot(sound03);
      _GaugeCheck = 1;
      _SuperShotFlag = true;
      //波動拳を発動する為のタイマーを初期値である「2」に戻す。
      _Count = 2;
    }
  }

  public void Jump()
  {
    _JumpFlag = false;
    _PlayerShowFlag = true;
  }

  public void Attack()
  {
    _AttackButtonFlag = true;
    //コンボ不成立
    _ComboScoreFlag = false;
    //スプライト表示時間をリセット
    _timer = 0.0f;
    //コンボタイマーをリセット
    _comboTimer = 0.0f;
    _AttackCount++;
    //スペースキーを押した回数が偶数なら「Attack1bySprite」、奇数なら「Attack2bySprite」に変更する。
    MainSpriteRenderer.sprite = (_AttackCount % 2 == 0) ? Attack1bySprite : Attack2bySprite;
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.name == "Hit_Check")
    {
      MainSpriteRenderer.sprite = WaitbySprite;
      //スプライト表示時間をリセット
      _timer = 0.0f;
    }
  }

  void OnTriggerEnter2D(Collider2D collider){
    if(collider.tag == "Skeleton" && _AttackButtonFlag == true && _SuperShotFlag == false)
    {
      _ComboFlag = true;
      _comboTimer = 0.0f;
    }
  }
}