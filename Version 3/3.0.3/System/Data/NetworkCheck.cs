using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkCheck : MonoBehaviour
{
    public GameObject Not_Network_dialog;
    // Start is called before the first frame update
    void Start()
    {
        Not_Network_dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ネットワークの状態を出力
        switch (Application.internetReachability)
        {
            case NetworkReachability.NotReachable:
                Debug.Log("ネットワークには到達不可");
                Not_Network_dialog.SetActive(true);
                break;
            case NetworkReachability.ReachableViaCarrierDataNetwork:
                Debug.Log("キャリアデータネットワーク経由で到達可能");
                Not_Network_dialog.SetActive(false);
                SceneManager.LoadScene("Title");
                break;
            case NetworkReachability.ReachableViaLocalAreaNetwork:
                Debug.Log("Wifiまたはケーブル経由で到達可能");
                Not_Network_dialog.SetActive(false);
                SceneManager.LoadScene("Title");
                break;
        }
    }

    public void Not_Network_dialog_OK()
    {
        Not_Network_dialog.SetActive(false);
    }
}
