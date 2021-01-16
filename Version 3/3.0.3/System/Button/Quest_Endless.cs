using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class Quest_Endless : MonoBehaviour
{
    float startTime;
    public int fadeTime;
    Color alpha;
    bool fade_f = false;
    bool button = true;

    private AudioSource sound01;

    [SerializeField]
    Fade fade = null;

    //　非同期動作で使用するAsyncOperation
    private AsyncOperation async;
    //　シーンロード中に表示するUI画面
    [SerializeField]
    private GameObject loadUI;
    //　読み込み率を表示するスライダー
    //[SerializeField]
    //private Slider slider;

    public static bool Button_push_Not;
    bool Button_push_cheak1;
    bool Button_push_cheak2;
    bool Button_push_cheak3;

    public static int life_reset = 0;
    public static int play_cnt;
    public GameObject Endless_cover;
    public GameObject NotClear_easy_Text;
    public GameObject NotClear_normal_Text;
    public GameObject NotClear_heard_Text;
    int heard_OK;
    bool Ecover_f;
    float Etime = 0;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Combo", 0);
        PlayerPrefs.SetInt("Count", 6);
        PlayerPrefs.Save();
        startTime = Time.time;
        sound01 = GetComponent<AudioSource>();
        Button_push_Not = false;
        play_cnt = 1;
        heard_OK = PlayerPrefs.GetInt("heard", 0);  //1:上級クリア、0:上級未クリア
        if(heard_OK == 0)
        {
            Endless_cover.SetActive(true);
        }
        else
        {
            Endless_cover.SetActive(false);
        }
    }

    private void Update()
    {
        Button_push_cheak1 = Quest_Easy.Button_Push_Easy();
        Button_push_cheak2 = Quest_Normal.Button_Push_Normal();
        Button_push_cheak3 = Quest_Heard.Button_Push_Heard();
        if (Ecover_f == true)
        {
            Etime += Time.deltaTime;
            if (Etime >= 2.0f)
            {
                Ecover_f = false;
                Etime = 0;
                NotClear_heard_Text.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    /*
    public void Update()
    {
        if (fade_f == true)
        {
            button = false;
            Invoke("GameStart", 2.0f);
        }
    }

    public void Fadestart()
    {
        fade.FadeIn(1);
        if (button == true)
        {    //ボタンの連続押しを制御
            fade_f = true;
            startTime = Time.time;
            sound01.PlayOneShot(sound01.clip);
            Update();
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("endless");
    }
    */

    public void NextScene()
    {
        /*
        if (Button_push_Not == false && Button_push_cheak1 == false && Button_push_cheak2 == false && Button_push_cheak3 == false)
        {
            life_reset = 1;
            PlayerPrefs.SetInt("life_reset", life_reset);
            PlayerPrefs.Save();
            //　ロード画面UIをアクティブにする
            loadUI.SetActive(true);
            LoadStage();
            //　コルーチンを開始
            //StartCoroutine("LoadData");
            Button_push_Not = true;
        }
        */
        if(heard_OK == 0)
        {
            Ecover_f = true;
            Etime = 0;
            NotClear_easy_Text.SetActive(false);
            NotClear_normal_Text.SetActive(false);
            NotClear_heard_Text.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("play_cnt", 0);
            PlayerPrefs.SetInt("Heart", 3);
            life_reset = 1;
            //　ロード画面UIをアクティブにする
            loadUI.SetActive(true);
            LoadStage();
            //　コルーチンを開始
            //StartCoroutine("LoadData");
            Button_push_Not = true;
        }
    }

    private void LoadStage()
    {
        /*
        Addressables.LoadAssetsAsync<GameObject>("Endless", null).Completed += op =>
        {
            foreach (var result in op.Result)
            {
                SceneManager.LoadSceneAsync("endless");
            }
        };
        */
        fade.FadeIn(1, () =>
        {
            SceneManager.LoadSceneAsync("endless");
        });
    }
    /*
    IEnumerator LoadData()
    {
        if (Button_push_Not == false && Button_push_cheak1 == false && Button_push_cheak2 == false && Button_push_cheak3 == false)
        {
            // シーンの読み込みをする
            async = SceneManager.LoadSceneAsync("endless");

            //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
            while (!async.isDone)
            {
                var progressVal = Mathf.Clamp01(async.progress / 0.9f);
                slider.value = progressVal;
                yield return null;
            }
        }
    }
    */

    public static bool Button_Push_Endless()
    {
        return Button_push_Not;
    }

    public static int Set_Play_Count()
    {
        return play_cnt;
    }

    public static int Set_life_reset()
    {
        return life_reset;
    }
}
