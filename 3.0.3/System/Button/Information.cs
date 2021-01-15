using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Information : MonoBehaviour
{
    public GameObject Information_Dialog1;
    public GameObject Information_Dialog2;
    public GameObject Information_Dialog3;
    public GameObject Information_Dialog4;
    public GameObject Information_Dialog5;
    public GameObject Information_Dialog6;
    public GameObject Information_Dialog7;
    public GameObject Information_Dialog8;
    bool Information1_button_f = false;
    bool Information2_button_f = false;
    bool Information3_button_f = false;
    bool Information4_button_f = false;
    bool Information5_button_f = false;
    bool Information6_button_f = false;
    bool Information7_button_f = false;
    bool Information8_button_f = false;
    // Start is called before the first frame update
    void Start()
    {
        Information_Dialog1.SetActive(false);
        Information_Dialog2.SetActive(false);
        Information_Dialog3.SetActive(false);
        Information_Dialog4.SetActive(false);
        Information_Dialog5.SetActive(false);
        Information_Dialog6.SetActive(false);
        Information_Dialog7.SetActive(false);
        Information_Dialog8.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Information1_button_f == true)
        {
            Information_Dialog1.SetActive(true);
            Information_Dialog1.transform.DOScale(endValue: new Vector2(0.5f, 0.35f), duration: 1.0f);
        }
        if (Information1_button_f == false)
        {
            Information_Dialog1.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 1.0f);
        }
        //-----------------------------------
        if (Information2_button_f == true)
        {
            Information_Dialog2.SetActive(true);
            Information_Dialog2.transform.DOScale(endValue: new Vector2(0.5f, 0.35f), duration: 1.0f);
        }
        if (Information2_button_f == false)
        {
            Information_Dialog2.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 1.0f);
        }
        //-----------------------------------
        if (Information3_button_f == true)
        {
            Information_Dialog3.SetActive(true);
            Information_Dialog3.transform.DOScale(endValue: new Vector2(0.5f, 0.35f), duration: 1.0f);
        }
        if (Information3_button_f == false)
        {
            Information_Dialog3.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 1.0f);
        }
        //-----------------------------------
        if (Information4_button_f == true)
        {
            Information_Dialog4.SetActive(true);
            Information_Dialog4.transform.DOScale(endValue: new Vector2(0.5f, 0.35f), duration: 1.0f);
        }
        if (Information4_button_f == false)
        {
            Information_Dialog4.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 1.0f);
        }
        //-----------------------------------
        if (Information5_button_f == true)
        {
            Information_Dialog5.SetActive(true);
            Information_Dialog5.transform.DOScale(endValue: new Vector2(0.5f, 0.35f), duration: 1.0f);
        }
        if (Information5_button_f == false)
        {
            Information_Dialog5.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 1.0f);
        }
        //-----------------------------------
        if (Information6_button_f == true)
        {
            Information_Dialog6.SetActive(true);
            Information_Dialog6.transform.DOScale(endValue: new Vector2(0.5f, 0.35f), duration: 1.0f);
        }
        if (Information6_button_f == false)
        {
            Information_Dialog6.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 1.0f);
        }
        //-----------------------------------
        if (Information7_button_f == true)
        {
            Information_Dialog7.SetActive(true);
            Information_Dialog7.transform.DOScale(endValue: new Vector2(0.5f, 0.35f), duration: 1.0f);
        }
        if (Information7_button_f == false)
        {
            Information_Dialog7.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 1.0f);
        }
        //-----------------------------------
        if (Information8_button_f == true)
        {
            Information_Dialog8.SetActive(true);
            Information_Dialog8.transform.DOScale(endValue: new Vector2(0.5f, 0.35f), duration: 1.0f);
        }
        if (Information8_button_f == false)
        {
            Information_Dialog8.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 1.0f);
        }
    }

    public void Push_Informaiton1()
    {
        Information1_button_f = true;
        Information2_button_f = false;
        Information3_button_f = false;
        Information4_button_f = false;
        Information5_button_f = false;
        Information6_button_f = false;
        Information7_button_f = false;
        Information8_button_f = false;
        Update();
    }
    public void Push_Informaiton2()
    {
        Information1_button_f = false;
        Information2_button_f = true;
        Information3_button_f = false;
        Information4_button_f = false;
        Information5_button_f = false;
        Information6_button_f = false;
        Information7_button_f = false;
        Information8_button_f = false;
        Update();
    }
    public void Push_Informaiton3()
    {
        Information1_button_f = false;
        Information2_button_f = false;
        Information3_button_f = true;
        Information4_button_f = false;
        Information5_button_f = false;
        Information6_button_f = false;
        Information7_button_f = false;
        Information8_button_f = false;
        Update();
    }
    public void Push_Informaiton4()
    {
        Information1_button_f = false;
        Information2_button_f = false;
        Information3_button_f = false;
        Information4_button_f = true;
        Information5_button_f = false;
        Information6_button_f = false;
        Information7_button_f = false;
        Information8_button_f = false;
        Update();
    }
    public void Push_Informaiton5()
    {
        Information1_button_f = false;
        Information2_button_f = false;
        Information3_button_f = false;
        Information4_button_f = false;
        Information5_button_f = true;
        Information6_button_f = false;
        Information7_button_f = false;
        Information8_button_f = false;
        Update();
    }
    public void Push_Informaiton6()
    {
        Information1_button_f = false;
        Information2_button_f = false;
        Information3_button_f = false;
        Information4_button_f = false;
        Information5_button_f = false;
        Information6_button_f = true;
        Information7_button_f = false;
        Information8_button_f = false;
        Update();
    }
    public void Push_Informaiton7()
    {
        Information1_button_f = false;
        Information2_button_f = false;
        Information3_button_f = false;
        Information4_button_f = false;
        Information5_button_f = false;
        Information6_button_f = false;
        Information7_button_f = true;
        Information8_button_f = false;
        Update();
    }
    public void Push_Informaiton8()
    {
        Information1_button_f = false;
        Information2_button_f = false;
        Information3_button_f = false;
        Information4_button_f = false;
        Information5_button_f = false;
        Information6_button_f = false;
        Information7_button_f = false;
        Information8_button_f = true;
        Update();
    }
}
