using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Big_Gold_Skel : MonoBehaviour
{
    public GameObject obj;
    int cnt;
    GameObject GameStart;
    GameStartText script;
    bool GameStart_f;
    bool Boss_Endless_f_gold;

    // Use this for initialization
    void Start()
    {
        obj.SetActive(false);
        GameStart = GameObject.Find("GameStart");
        script = GameStart.GetComponent<GameStartText>();
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameStart_f = script.GS_f;
        if (GameStart_f == true && cnt == 0)
        {
            obj.SetActive(true);
        }
    }
}
