using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Fade_Endless_Next : MonoBehaviour
{
    public bool SF_f;
    public GameObject stage_fade;
    // Start is called before the first frame update
    void Start()
    {
        SF_f = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage_fade.transform.position.x >= 10.0f && stage_fade.transform.position.x < 100.0f)
        {
            stage_fade.transform.Translate(2.0f, 0, 0);
        }
        if (stage_fade.transform.position.x >= 100.0f)
        {
            SF_f = true;
        }
    }
}
