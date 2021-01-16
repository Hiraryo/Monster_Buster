using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WARNING1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.x < 0){
            transform.Translate(20.0f, 0, 0);
        }
    }
}
