using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{
    public GameObject I;
    public float alpha;
    // Start is called before the first frame update
    void Start()
    {
        alpha = 0;
        I.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        alpha += 0.01f;
    }
}
