﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLocalizer : MonoBehaviour
{
    [Multiline]
    public string englishText;
    public int englishFontSize;
    void Start()
    {
        /*
        Text text = GetComponent<Text>();
        if (Application.systemLanguage != SystemLanguage.Japanese)
        {
            text.text = englishText;
            if (englishFontSize != 0)
            {
                text.fontSize = englishFontSize;
            }
        }
        */
    }
}
