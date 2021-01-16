using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsentDialogProgram : MonoBehaviour
{
    int Consent_f;
    // Start is called before the first frame update
    void Start()
    {
        Consent_f = PlayerPrefs.GetInt("Consent_f", 0);
        if (Consent_f == 0)
        {
            SceneManager.LoadScene("Consent_Dialog_Program");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
