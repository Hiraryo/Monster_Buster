using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bless : MonoBehaviour {

    public static bool bless_f;
    bool bless_hit;
    float time;
    // Use this for initialization
    void Start () {
        bless_f = false;
        bless_hit = false;
        time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (bless_hit == true){
            time += Time.deltaTime;
            bless_f = false;
        }
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player" && bless_hit == false)
        {
            bless_hit = true;
            bless_f = true;
        }
        if (other.tag == "Player" && time >= 1.0f)  //続けて当たる間隔時間(1.0秒)
        {
            bless_f = true;
            time = 0;
        }
    }

    public static bool Get_Bless_f()
    {
        return bless_f;
    }
}
