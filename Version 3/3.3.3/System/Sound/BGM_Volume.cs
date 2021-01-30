using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Volume : MonoBehaviour
{
    AudioSource m_AudioSource;
    float volume;
    // Start is called before the first frame update
    void Start()
    {
        volume = ToggleBGM.Set_BGM_volume();
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
