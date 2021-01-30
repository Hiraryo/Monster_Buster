using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Maintenance : MonoBehaviour
{
    public string[] textMessage; //テキストの加工前の一行を入れる変数
    public string[] textMessage2; //テキストの加工前の一行を入れる変数
    private int rowLength; //テキスト内の行数を取得する変数
    private int rowLength2; //テキスト内の行数を取得する変数
    public GameObject data;
    public GameObject sub_message;
    public string mainte_data;
    public string sub_message_txt;
    private void Start()
    {
        StartCoroutine(GetText());
    }
    public void Go_Title()
    {
        SceneManager.LoadScene("Title");
    }
    IEnumerator GetText()
    {
        UnityWebRequest request = UnityWebRequest.Get("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        UnityWebRequest request2 = UnityWebRequest.Get("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        yield return request.SendWebRequest();
        yield return request2.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        if (request2.isNetworkError || request2.isHttpError)
        {
            Debug.Log(request2.error);
        }
        else
        {
            // 結果をテキストとして表示します
            Debug.Log(request.downloadHandler.text);
            string txt = request.downloadHandler.text;
            string sub_txt = request2.downloadHandler.text;
            //バージョンが同じ時
            //Spritで１行ずつを代入した1次配列を作成
            textMessage = txt.Split('\n');
            textMessage2 = sub_txt.Split('\n');

            //行数を取得
            rowLength = textMessage.Length;
            rowLength2 = textMessage2.Length;

            for (int i = 0; i < rowLength; i++)
            {
                mainte_data = textMessage[1];
            }
            for (int s = 0; s < rowLength2; s++)
            {
                sub_message_txt += '\n' + textMessage2[s];
            }
            //  または、結果をバイナリデータとして取得します
            byte[] results = request.downloadHandler.data;
            byte[] results2 = request2.downloadHandler.data;
            data.GetComponent<Text>().text = mainte_data;
            sub_message.GetComponent<Text>().text = sub_message_txt;
        }
    }
}
