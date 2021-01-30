using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsentButton : MonoBehaviour
{
    int Consent_f;
    public void ConsentOK()
    {
        SceneManager.LoadScene("Title");
        Consent_f = 1;
        PlayerPrefs.SetInt("Consent_f", Consent_f);
        PlayerPrefs.Save();
    }

    public void ConsentNO()
    {
        Application.Quit();
    }
}
