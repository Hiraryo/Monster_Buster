using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using GoogleMobileAds.Api;

public class GameOver : MonoBehaviour 
{
    public GameObject Not_Network_dialog;

    float time;
    int count;

    public AdMobManager interstitial_OK_f;
    //bool Ad_f;
    // Use this for initialization
    void Start () {
        time = 0;
        count = 0;
        Not_Network_dialog.SetActive(false);
        //AdMobManager.instance.DestroyBanner();
        //AdMobManager.instance.RequestInterstitial();
        //Ad_f = interstitial_OK_f.interstitial_OK;
    }

    // Update is called once per frame
    void Update () {
        /*
        Debug.Log("Ad_f : " + Ad_f);
        if (Ad_f == true)
        {
            SceneManager.LoadScene("Home");
        }
        */
        // ネットワークの状態を出力
        switch (Application.internetReachability)
        {
            case NetworkReachability.NotReachable:
                //Debug.Log("ネットワークには到達不可");
                Not_Network_dialog.SetActive(true);
                break;
            case NetworkReachability.ReachableViaCarrierDataNetwork:
                //Debug.Log("キャリアデータネットワーク経由で到達可能");
                Not_Network_dialog.SetActive(false);
                if (time >= 4.5f)
                {
                    count++;
                    if (count <= 1)
                    {
                        Debug.Log("OK1");
                        //AdMobManager.instance.viewReward();
                        //AdMobManager.instance.viewInterstitial();
                        SceneManager.LoadScene("Home");
                    }
                }
                break;
            case NetworkReachability.ReachableViaLocalAreaNetwork:
                //Debug.Log("Wifiまたはケーブル経由で到達可能");
                Not_Network_dialog.SetActive(false);
                if (time >= 4.5f)
                {
                    count++;
                    if (count <= 1)
                    {
                        Debug.Log("OK2");
                        //AdMobManager.instance.viewReward();
                        //AdMobManager.instance.viewInterstitial();
                        SceneManager.LoadScene("Home");
                    }
                }
                break;
        }
        time += Time.deltaTime;
    }
}
