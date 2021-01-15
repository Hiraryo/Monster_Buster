using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStore_For_Android : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenStore()
    {
        //各プレイストアへリダイレクトするページを開く
        Application.OpenURL("http://expresshr99.html.xdomain.jp/Monster_Buster_verCheck.html");
    }
}
