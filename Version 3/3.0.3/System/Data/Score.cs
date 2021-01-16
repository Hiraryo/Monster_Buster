using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    // スコアを表示する
    public Text scoreText;
    // ハイスコアを表示する
    public Text highScoreText;

    // スコア
    public static int score;

    // ハイスコア
    public static int highScore;

    string Scene_name;
    void Start()
    {
        Scene_name = PlayerPrefs.GetString("Scene_name");
        // スコアを0に戻す
        score = 0;

        // ハイスコアを取得する。保存されてなければ0を取得する。
        if (Scene_name == "Stage01")
        {
            highScore = PlayerPrefs.GetInt("highScore1", 0);
        }
        if (Scene_name == "Stage02")
        {
            highScore = PlayerPrefs.GetInt("highScore2", 0);
        }
        if (Scene_name == "Stage03")
        {
            highScore = PlayerPrefs.GetInt("highScore3", 0);
        }
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

    public static int GetHighScore()
    {
        return highScore;
    }
}
