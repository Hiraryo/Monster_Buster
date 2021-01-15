using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Super_Shot")
        {
            // ぶつかってきたオブジェクトを破壊（削除）。
            Destroy(c.gameObject);
        }
    }
}
