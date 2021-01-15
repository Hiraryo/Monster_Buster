using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class Version_Check : MonoBehaviour
{
    //int NowVersion; //最新バージョン
    public GameObject Version;
    public string ver1;
    // Start is called before the first frame update
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        // iOS / Android ともに Version を取得
        //ver1 = Application.unityVersion;
        Version.GetComponent<Text>().text = "Version  " + ver1;
        // iOS では Build を取得（未確認）
        // Android では Bundle Version Code を取得
        /*Application.unityVersion
        string ver2 = UniVersionManager.GetBuildVersion();

        // 最新版が存在する場合
        if (UniVersionManager.IsNewVersion(NowVersion))
        {
            // ここでストアに遷移させたりする
            SceneManager.LoadScene("Go_PlayStore");
        }
        */
        StartCoroutine(GetText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetText()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://expresshr99.html.xdomain.jp/MonsterBuster/3.0.3/MSversion.txt");
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            // 結果をテキストとして表示します
            Debug.Log(request.downloadHandler.text);
            string txt = request.downloadHandler.text;
            //バージョンが同じ時
            if (ver1.Equals(txt))
            {
                Debug.Log("最新版です");
            }
            else
            //バージョンが違う時
            {
                SceneManager.LoadScene("Go_PlayStore");
            }
            //  または、結果をバイナリデータとして取得します
            byte[] results = request.downloadHandler.data;
        }
    }
}
