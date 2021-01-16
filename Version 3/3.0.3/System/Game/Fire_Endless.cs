using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire_Endless : MonoBehaviour {

    public float speed_x;
    public float speed_y;
    Collider2D b_object;

    bool space_check_b = false;

    GameObject c_wait;
    Move_Endless script;
    // Use this for initialization
    void Start () {
        c_wait = GameObject.Find("c_wait");   //c_waitをオブジェクトの名前から取得して変数に格納する
        script = c_wait.GetComponent<Move_Endless>(); //c_waitの中にあるmoveを取得して変数に格納する
	}
	
	// Update is called once per frame
	void Update () {
        bool d_f = Boss_Endless2.Set_dragon_posOK();
        if (d_f == true)
        {
            transform.Translate(speed_x, speed_y, 0);
            space_check_b = script.space_check;    //新しく変数を宣言してその中にmove.csの変数space_checkを代入する。
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player" && space_check_b == true || c.tag == "tatumaki" || c.tag == "Invisible") //火の玉にダメージを与えた時
        {
            b_object = GetComponent<Collider2D>();
            b_object.isTrigger = true;
            speed_x = 0.5f;
            speed_y = 0.01f;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
        transform.localScale = theScale;

            //Invoke("FireBall", 1);
        }
        if (c.tag == "Doragon")
        {
            Destroy(gameObject);
        }
    }






    // Switch the way the player is labelled as facing.
    //facingRight = !facingRight;

    // Multiply the player's x local scale by -1.

    //void FireBall() {
    //speed_x = -0.3f;
    //speed_y = -0.2f;
    //b_object.isTrigger = true;
    //space_check_b = false;
    //}
}
