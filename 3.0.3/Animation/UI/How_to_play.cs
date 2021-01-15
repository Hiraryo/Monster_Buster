using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class How_to_play : MonoBehaviour
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

	bool Button_push_Not;

	// Use this for initialization
	void Start()
    {
        startTime = Time.time;
        sound01 = GetComponent<AudioSource>();
		Button_push_Not = false;
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
        SceneManager.LoadScene("Stage02");
    }
    */

    public void NextScene()
    {
        if (Button_push_Not == false)
		{
			//　ロード画面UIをアクティブにする
			//loadUI.SetActive(true);
            LoadStage();
            //　コルーチンを開始
            //StartCoroutine("LoadData");
            Button_push_Not = true;
		}
    }

    private void LoadStage()
    {
        fade.FadeIn(1, () =>
        {
            SceneManager.LoadSceneAsync("How_to_Play");
        });
        /*
        Addressables.LoadAssetsAsync<GameObject>("HtoP", null).Completed += op =>
        {
            foreach (var result in op.Result)
            {
                SceneManager.LoadSceneAsync("How_to_Play");
            }
        };
        */
    }

    /*
    IEnumerator LoadData()
    {
        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("How_to_Play");

        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }
    */
}
