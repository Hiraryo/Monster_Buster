using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    bool scale_x_f;
    // Start is called before the first frame update
    void Start()
    {
        scale_x_f = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ワールドのy軸に沿って1秒間に2度回転
        transform.Rotate(new Vector3(0, 80, 0) * Time.deltaTime, Space.World);
        /*
        if (transform.localScale.x <= 1.5 && transform.localScale.x >= -1.5)
        {
            if (scale_x_f == false)
            {
                this.transform.localScale -= new Vector3(0.02f, 0, 0);
            }
            if (scale_x_f == true)
            {
                this.transform.localScale += new Vector3(0.2f, 0, 0);
            }
            if (transform.localScale.x <= -1.5)
            {
                scale_x_f = true;
            }
            if (transform.localScale.x >= 1.5)
            {
                scale_x_f = false;
            }
        }
        */
    }
}
