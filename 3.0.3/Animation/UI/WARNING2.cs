using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WARNING2 : MonoBehaviour {
    SpriteRenderer MainSpriteRenderer;
    public Sprite Warning2_Japanese;
    public Sprite Warning2_English;
    // Use this for initialization
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (Application.systemLanguage != SystemLanguage.Japanese)
        {
            MainSpriteRenderer.sprite = Warning2_English;
        }
        else
        {
            MainSpriteRenderer.sprite = Warning2_Japanese;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.x > 0)
        {
            transform.Translate(-20.0f, 0, 0);
        }
    }
}
