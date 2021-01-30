using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class Quest_Easy : MonoBehaviour
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
    public GameObject Normal_cover;
    public GameObject Heard_cover;
    public GameObject NotClear_easy_Text;
    public GameObject NotClear_normal_Text;
    public GameObject NotClear_heard_Text;
    public static int scene_number;
    int easy_OK;
    int normal_OK;
    bool Ncover_f;
    bool Hcover_f;
    float Ntime = 0;
    float Htime = 0;
    int easy_click_cnt = 0;
    int normal_click_cnt = 0;
    int heard_click_cnt = 0;
    public GameObject easy_boss_dialog;
    public GameObject normal_boss_dialog;
    public GameObject heard_boss_dialog;
    //public GameObject Not_tap;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        sound01 = GetComponent<AudioSource>();
		Button_push_Not = false;
        scene_number = 0;
        easy_OK = PlayerPrefs.GetInt("easy", 0);    //1:初級クリア、0:初級未クリア
        normal_OK = PlayerPrefs.GetInt("normal", 0);    //1:中級クリア、0:中級未クリア
        easy_click_cnt = PlayerPrefs.GetInt("e_cnt", 0);
        normal_click_cnt = PlayerPrefs.GetInt("n_cnt", 0);
        heard_click_cnt = PlayerPrefs.GetInt("h_cnt", 0);
        easy_boss_dialog.SetActive(false);
        normal_boss_dialog.SetActive(false);
        heard_boss_dialog.SetActive(false);
        //Not_tap.SetActive(false);
        if (easy_OK == 0)
        {
            Normal_cover.SetActive(true);
            Heard_cover.SetActive(true);
        }
        if (easy_OK == 1)
        {
            Normal_cover.SetActive(false);
        }
        if(normal_OK == 0)
        {
            Heard_cover.SetActive(true);
        }
        if (normal_OK == 1)
        {
            Heard_cover.SetActive(false);
        }
    }

    private void Update()
    {
        Button_push_cheak1 = Quest_Normal.Button_Push_Normal();
        Button_push_cheak2 = Quest_Heard.Button_Push_Heard();
        Button_push_cheak3 = Quest_Endless.Button_Push_Endless();
        if(Ncover_f == true)
        {
            Ntime += Time.deltaTime;
            if(Ntime >= 2.0f)
            {
                Ncover_f = false;
                Ntime = 0;
                NotClear_easy_Text.SetActive(false);
            }
        }
        if (Hcover_f == true)
        {
            Htime += Time.deltaTime;
            if (Htime >= 2.0f)
            {
                Hcover_f = false;
                Htime = 0;
                NotClear_normal_Text.SetActive(false);
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
        //Invoke("GameStart", 2.0f);
        StartCoroutine("GameStart");
    }
}

public void Fadestart()
{
    //　ロード画面UIをアクティブにする
    loadUI.SetActive(true);
    fade.FadeIn(1);
    if (button == true)
    {    //ボタンの連続押しを制御
        fade_f = true;
        startTime = Time.time;
        sound01.PlayOneShot(sound01.clip);
        Update();
    }
}

IEnumerator GameStart()
{
    // シーンの読み込みをする
    async = SceneManager.LoadSceneAsync("Stage01");
    //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
    while (!async.isDone)
    {
        var progressVal = Mathf.Clamp01(async.progress / 0.9f);
        slider.value = progressVal;
        yield return null;
    }
}
*/
/*
    public void NextScene()
    {
        if (Button_push_Not == false && Button_push_cheak1 == false && Button_push_cheak2 == false && Button_push_cheak3 == false)
		{
			//　ロード画面UIをアクティブにする
			loadUI.SetActive(true);

			//　コルーチンを開始
			StartCoroutine("LoadData");
			Button_push_Not = true;
		}
    }
    */

    public void Easy_Scene()
    {
        if(easy_click_cnt == 0)
        {
            easy_boss_dialog.SetActive(true);
        }
        else
        {
            //　ロード画面UIをアクティブにする
            loadUI.SetActive(true);
            LoadStage();
            //　コルーチンを開始
            //StartCoroutine("LoadData");
            scene_number = 1;
        }
    }
    public void Normal_Scene()
    {
        if (easy_OK == 0)
        {
            Ncover_f = true;
            Htime = 0;
            NotClear_easy_Text.SetActive(true);
            NotClear_normal_Text.SetActive(false);
            NotClear_heard_Text.SetActive(false);
        }
        else
        {
            if (normal_click_cnt == 0)
            {
                normal_boss_dialog.SetActive(true);
            }
            else
            {
                //　ロード画面UIをアクティブにする
                loadUI.SetActive(true);
                LoadStage();
                //　コルーチンを開始
                //StartCoroutine("LoadData");
                scene_number = 2;
            }
        }
        
    }
    public void Heard_Scene()
    {
        if (normal_OK == 0)
        {
            Hcover_f = true;
            Ntime = 0;
            NotClear_easy_Text.SetActive(false);
            NotClear_normal_Text.SetActive(true);
            NotClear_heard_Text.SetActive(false);
        }
        else
        {
            if (heard_click_cnt == 0)
            {
                heard_boss_dialog.SetActive(true);
            }
            else
            {
                //　ロード画面UIをアクティブにする
                loadUI.SetActive(true);
                LoadStage();
                //　コルーチンを開始
                //StartCoroutine("LoadData");
                scene_number = 3;
            }
        }
    }

    public void New_easy()
    {
        LoadStage();
        scene_number = 1;
        PlayerPrefs.SetInt("e_cnt", 1);
        PlayerPrefs.Save();
    }
    public void New_normal()
    {
        LoadStage();
        scene_number = 2;
        PlayerPrefs.SetInt("n_cnt", 1);
        PlayerPrefs.Save();
    }
    public void New_heard()
    {
        LoadStage();
        scene_number = 3;
        PlayerPrefs.SetInt("h_cnt", 1);
        PlayerPrefs.Save();
    }
    private void LoadStage()
    {
        fade.FadeIn(1, () =>
        {
            SceneManager.LoadSceneAsync("Stage01");
        });
    }
    /*
    IEnumerator LoadData()
    {
        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("Stage01");

        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }

    }
    */

    public static bool Button_Push_Easy()
    {
        return Button_push_Not;
    }

    public  static int Set_Scene_Num()
    {
        return scene_number;
    }
}
