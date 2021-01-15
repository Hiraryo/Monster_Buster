using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quest_Heard : MonoBehaviour
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
    [SerializeField]
    private Slider slider;

    public static bool Button_push_Not;
    bool Button_push_cheak1;
    bool Button_push_cheak2;
    bool Button_push_cheak3;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        sound01 = GetComponent<AudioSource>();
        Button_push_Not = false;
    }

    private void Update()
    {
        Button_push_cheak1 = Quest_Easy.Button_Push_Easy();
        Button_push_cheak2 = Quest_Normal.Button_Push_Normal();
        Button_push_cheak3 = Quest_Endless.Button_Push_Endless();
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
        SceneManager.LoadScene("Stage03");
    }
    */

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

    IEnumerator LoadData()
    {
        if (Button_push_Not == false && Button_push_cheak1 == false && Button_push_cheak2 == false && Button_push_cheak3 == false)
        {
            // シーンの読み込みをする
            async = SceneManager.LoadSceneAsync("Stage03");

            //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
            while (!async.isDone)
            {
                var progressVal = Mathf.Clamp01(async.progress / 0.9f);
                slider.value = progressVal;
                yield return null;
            }
        }
    }

    public static bool Button_Push_Heard()
    {
        return Button_push_Not;
    }
}
