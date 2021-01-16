using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_skel_gold1 : MonoBehaviour {
    public GameObject obj;
    int var;
    int cnt;
    int var2;
    public float interval;
    public bool warning_gold;
    GameObject GameStart;
    GameStartText script;

    bool GameStart_f;

    //GameObject d_016;
    //Boss_Endless script2;

    bool Boss_Endless_f_gold;

    public bool Endless_f_gold; //スケルトンが一定数出現すると、ボスを出現させる為に一旦停止フラグ(false : 一定数に達していない, true : 一定数に達した為スケルトン出現を停止)
    public GameObject parent;
    // Use this for initialization
    void Start()
    {
        GameStart = GameObject.Find("GameStart");
        script = GameStart.GetComponent<GameStartText>();
        warning_gold = false;
        cnt = 0;
        InvokeRepeating("SpawnObj", 0.1f, interval);
        var2 = Random.Range(0, 3);
        //d_016 = GameObject.Find("d_016");
        //script2 = d_016.GetComponent<Boss_Endless>();
        Endless_f_gold = false;
    }

    // Update is called once per frame
    void SpawnObj()
    {
        //if (GameStart_f == true && Boss_Endless_f_gold == true)
        if (GameStart_f == true && Endless_f_gold == false)
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
        GameStart_f = script.GS_f;
        //Boss_Endless_f_gold = script2.Boss_Endless_f;
        if (cnt >= var2)   //ここの値を変えると、それぞれのスケルトンの出てくる数を制限可能。(今はそれぞれのスケルトンが5体まで出て、その後は出てこない)
        {
            warning_gold = true;
            Endless_f_gold = true;
            //Destroy(gameObject);
        }
    }
}
