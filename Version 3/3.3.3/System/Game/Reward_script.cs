using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reward_script : MonoBehaviour
{
    int Reward_CHECK;
    public static bool Reward_OK;
    // Start is called before the first frame update
    void Start()
    {
        Reward_OK = false;
        //AdMobManager.instance.viewReward();
    }

    // Update is called once per frame
    void Update()
    {
        //Reward_CHECK = AdMobManager.Reward_f();
        if (Reward_CHECK == 1)
        {
            //広告表示中
            Time.timeScale = 0f;
        }
        if (Reward_CHECK == 2)
        {
            //アイテムを与える
            Reward_OK = true;
            SceneManager.LoadScene("Stage01");
        }
        if (Reward_CHECK == 3)
        {
            //キャンセル
            SceneManager.LoadScene("GameOver");
        }
    }
}
