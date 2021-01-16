using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextLocalizer_How_to_Play : MonoBehaviour
{
    [Multiline]
    public string englishText;
    public int englishFontSize;

    public string[] sentences; // 文章を格納する
    [SerializeField] Text uiText;   // uiTextへの参照

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f;   // 1文字の表示にかける時間

    private int currentSentenceNum = 0; //現在表示している文章番号
    private string currentSentence = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;     // 表示にかかる時間
    private float timeBeganDisplay = 1;         // 文字列の表示を開始した時間
    private int lastUpdateCharCount = -1;       // 表示中の文字数

    public GameObject TextController;
    void Start()
    {
        currentSentence = sentences[currentSentenceNum];
        timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
        timeBeganDisplay = Time.time;
        currentSentenceNum++;
        lastUpdateCharCount = 0;
        Text text = GetComponent<Text>();
        if (Application.systemLanguage != SystemLanguage.Japanese)
        {
            TextController.SetActive(false);
            text.text = englishText;
            if (englishFontSize != 0)
            {
                text.fontSize = englishFontSize;
            }
        }
    }

    void Update()
    {

        if (Application.systemLanguage != SystemLanguage.Japanese)
        {
            //表示される文字数を計算
            int displayCharCount = (int)(Mathf.Clamp01((Time.time - timeBeganDisplay) / timeUntilDisplay) * currentSentence.Length);
            //表示される文字数が表示している文字数と違う
            if (displayCharCount != lastUpdateCharCount)
            {
                uiText.text = currentSentence.Substring(0, displayCharCount);
                //表示している文字数の更新
                lastUpdateCharCount = displayCharCount;
            }
        }
    }

    // 次の文章をセットする
    public void SetNextSentence()
    {
        if (Application.systemLanguage != SystemLanguage.Japanese)
        {
            // 文章の表示完了 / 未完了
            if (IsDisplayComplete())
            {
                //最後の文章ではない & ボタンが押された
                if (currentSentenceNum < sentences.Length)    //Joy-Con(R)のXボタン
                {
                    currentSentence = sentences[currentSentenceNum];
                    timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
                    timeBeganDisplay = Time.time;
                    currentSentenceNum++;
                    lastUpdateCharCount = 0;
                    //最後の文章でエンターキーが押されると、タイトルへ戻る
                    if (currentSentenceNum == sentences.Length)
                    {
                        SceneManager.LoadScene("Title");
                    }
                }
            }
            else
            {
                timeUntilDisplay = 0; //※1
            }
        }
    }

    bool IsDisplayComplete()
    {
        return Time.time > timeBeganDisplay + timeUntilDisplay; //※2
    }
}
