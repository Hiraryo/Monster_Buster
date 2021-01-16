using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSE : MonoBehaviour
{
    AudioSource m_AudioSource;

    public Slider m_Slider;

    private bool m_Play;
    public bool m_ToggleChange;
    public GameObject SE_ON_Text;
    public GameObject SE_OFF_Text;
    bool SE_OFF_f = false;
    public static float volume;
    public static int cnt;
    void Start()
    {
        /*
        cnt = Count();
        if (cnt == 0)
        {
            volume = 1;
            cnt = 1;
        }
        else
        {
            volume = PlayerPrefs.GetFloat("SE_v", 1);
        }
        */
        volume = PlayerPrefs.GetFloat("SE_v", 1.0f);
        m_AudioSource = GetComponent<AudioSource>();
        m_Slider.GetComponent<Slider>().normalizedValue = volume;
        if (SE_OFF_f == false)  //音がなっている時の初期表示
        {
            m_Play = true;
            SE_ON_Text.SetActive(false);
            SE_OFF_Text.SetActive(true);
        }
        if (SE_OFF_f == true)   //音がなっていない時の初期表示
        {
            SE_ON_Text.SetActive(true);
            SE_OFF_Text.SetActive(false);
        }
    }

    void Update()
    {
        m_AudioSource.volume = m_Slider.GetComponent<Slider>().normalizedValue;
        volume = m_AudioSource.volume;
        if (m_AudioSource.volume == 1.0f)
        {
            SE_ON_Text.SetActive(false);
            SE_OFF_Text.SetActive(true);
            SE_OFF_f = false;
        }
        if (m_AudioSource.volume == 0.0f)
        {
            SE_ON_Text.SetActive(true);
            SE_OFF_Text.SetActive(false);
            SE_OFF_f = true;
        }
    }

    public void On_Click_SE()
    {
        if (SE_OFF_f == true)  //音がなっていない時にONのボタンを押した時 => 音量1
        {
            SE_ON_Text.SetActive(false);
            SE_OFF_Text.SetActive(true);
            SE_OFF_f = false;
            m_Slider.GetComponent<Slider>().normalizedValue = 1.0f;
            PlayerPrefs.SetFloat("SE_v", 1.0f);
        }
    }
    public void Off_Click_SE()
    {
        if (SE_OFF_f == false)  //音がなっている時にOFFのボタンを押した時 => 音量0
        {
            SE_ON_Text.SetActive(true);
            SE_OFF_Text.SetActive(false);
            SE_OFF_f = true;
            m_Slider.GetComponent<Slider>().normalizedValue = 0.0f;
            PlayerPrefs.SetFloat("SE_v", 0.0f);
        }
    }

    public static float Set_SE_volume()
    {
        return volume;
    }
    public static int Count()
    {
        return cnt;
    }

    public void Save_SE_Volume()
    {
        PlayerPrefs.SetFloat("SE_v", volume);
    }
}
