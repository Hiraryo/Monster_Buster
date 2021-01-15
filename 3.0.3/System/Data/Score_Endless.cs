using UnityEngine;
using UnityEngine.UI;

public class Score_Endless : MonoBehaviour
{

    // スコアを表示する
    public Text scoreText;
    // ハイスコアを表示する
    public Text highScoreText;

    // スコア
    public static int score;

    // ハイスコア
    public static int highScore;
    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";

    public int life_reset;
    void Start()
    {
        score = getScore();
        // ハイスコアを取得する。保存されてなければ0を取得する。
        score = PlayerPrefs.GetInt("Score", 0);
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        if (highScore < score)
        {
            highScore = score;
        }
        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    void Update()
    {
        
    }

    // ポイントの追加
    public void AddPoint(int point)
    {
        score = score + point;
        if (highScore < score)
        {
            highScore = score;
        }
        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    public static int getScore()
    {
      return score;
    }

    public static int gethighScore()
    {
        return highScore;
    }
}
