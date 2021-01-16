using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Title_Skip : MonoBehaviour
{
	//GameObject fadeObj;
	float startTime;
	public int fadeTime;
	Color alpha;
	bool fade = false;
	bool button = true;

	private AudioSource sound01;
	bool Server_maintenance_f = false;
	string server_num_txt;
	public string[] textMessage; //テキストの加工前の一行を入れる変数
	private int rowLength; //テキスト内の行数を取得する変数

	// Use this for initialization
	void Start()
	{
		StartCoroutine(GetText());
		//fadeObj = GameObject.Find("Fade");
		startTime = Time.time;
		sound01 = GetComponent<AudioSource>();
	}

	// Update is called once per frame

	public void Update()
	{
		if (fade == true)
		{
			button = false;
			alpha.a = (Time.time - startTime) / fadeTime;
			//fadeObj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha.a);
			Invoke("Title_Skip_Button", 1.0f);
		}
	}

	public void Fadestart()
	{
		if (button == true)
		{    //ボタンの連続押しを制御
			fade = true;
			startTime = Time.time;
			sound01.PlayOneShot(sound01.clip);
			Update();
		}
	}

	public void Title_Skip_Button()
    {
		if(Server_maintenance_f == true)
        {
			SceneManager.LoadScene("Maintenance");
		}
        else
        {
			SceneManager.LoadScene("Home");
		}
	}

    IEnumerator GetText()
    {
        //サーバーのメンテ中かをチェック
        UnityWebRequest request = UnityWebRequest.Get("http://expresshr99.html.xdomain.jp/MonsterBuster/Server_Check.txt");
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

			// Spritで１行ずつを代入した1次配列を作成
			textMessage = txt.Split('\n');

			//行数を取得
			rowLength = textMessage.Length;

			for (int i = 0; i < rowLength; i++)
			{
				server_num_txt = textMessage[0];
			}
			//サーバーのメンテナンスを行っていない時
			if (server_num_txt.Equals("0"))
            {
                Debug.Log("最新版です");
            }
            else
            //サーバーのメンテナンス中
            {
				Server_maintenance_f = true;
            }
            //  または、結果をバイナリデータとして取得します
            byte[] results = request.downloadHandler.data;
		}
    }
}