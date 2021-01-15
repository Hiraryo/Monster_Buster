using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    GameObject Warning;
    Warning3 script;

    // Use this for initialization
    void Start () {
        Warning = GameObject.Find("Warning");
        script = Warning.GetComponent<Warning3>();

    }
	
	// Update is called once per frame
	void Update () {
        bool sound_off_f = script.sound_off;
        if (sound_off_f == true){
            Destroy(GetComponent<AudioSource>());
        }
	}
}
