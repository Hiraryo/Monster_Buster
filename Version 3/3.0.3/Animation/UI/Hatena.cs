using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hatena : MonoBehaviour
{
    public GameObject Hatena_Message;
    bool Hatena_Message_f = false;
    // Start is called before the first frame update
    void Start()
    {
        Hatena_Message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Hatena_Message_f == true)
        {
            Hatena_Message.SetActive(true);
            Hatena_Message.transform.DOScale(endValue: new Vector2(1.3f, 1.0f), duration: 1.0f);
        }
        if (Hatena_Message_f == false)
        {
            Hatena_Message.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 1.0f);
        }
    }
    public void Hatena_Button_Push()
    {
        Hatena_Message_f = true;
    }

    public void Hatena_close_Push()
    {
        Hatena_Message_f = false;
    }
}
