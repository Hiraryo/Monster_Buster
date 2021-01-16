using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Destroy : MonoBehaviour
{
    Transform shot_transform;
    float scale_x;
    float scale_y;
    float scale_z;
    bool shot_hit = false;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = shot_transform.localScale;
        scale_x = localScale.x;
        scale_y = localScale.y;
        scale_z = localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
        if(shot_hit == true)
        {
            scale_x -= 3.0f;
            scale_y -= 3.0f;
            scale_z -= 3.0f;
            localScale.x = scale_x;
            localScale.y = scale_y;
            localScale.z = scale_z;
            shot_transform.localScale = localScale; // ローカル座標での座標を設定
            if(scale_x <= 0 && scale_y <= 0 && scale_z <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Not_Super_Shot")
        {
            shot_hit = true;
        }
    }
}
