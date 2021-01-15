using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Button_Rotate : MonoBehaviour
{
    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5));
    }
}