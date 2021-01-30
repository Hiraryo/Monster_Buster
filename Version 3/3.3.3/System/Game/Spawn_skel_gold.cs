using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_skel_gold : MonoBehaviour {

    [SerializeField]
    GameStartText_No_Endless script;
    public GameObject obj;
    int var;
    int cnt;
    int var2;
    float interval;
    public bool warning_gold;
    GameObject GameStart;
    public GameObject parent;

    //int Reward_CHECK;
    //GameStartText script;

    bool GameStart_f;

    int scene_cnt;

    // Use this for initialization
    void Start()
    {
        scene_cnt = Quest_Easy.Set_Scene_Num();
        if (scene_cnt == 1)
        {
            interval = 2;
        }
        if (scene_cnt == 2)
        {
            interval = 2;
        }
        if (scene_cnt == 3)
        {
            interval = 2;
        }
        GameStart = GameObject.Find("GameStart");
        script = GameStart.GetComponent<GameStartText_No_Endless>();
        warning_gold = false;
        cnt = 0;
        InvokeRepeating("SpawnObj", 0.1f, interval);
        var2 = Random.Range(0, 3);
    }

    // Update is called once per frame
    void SpawnObj()
    {
        if (GameStart_f == true)
        {
            var = Random.Range(0, 10);
            if (var == 4)
            {
                Update();
                cnt++;
                Instantiate(obj, transform.position, Quaternion.identity, parent.transform);
            }
        }
    }
    void Update()
    {
        //Reward_CHECK = AdMobManager.Reward_f();
        GameStart_f = script.GS_f;
        if (cnt >= var2)   //ここの値を変えると、それぞれのスケルトンの出てくる数を制限可能。(今はそれぞれのスケルトンが5体まで出て、その後は出てこない)
        {
            warning_gold = true;
            Destroy(gameObject);
        }
        /*
        if (Reward_CHECK == 1)
        {
            Time.timeScale = 0f;
        }
        */
    }
}
