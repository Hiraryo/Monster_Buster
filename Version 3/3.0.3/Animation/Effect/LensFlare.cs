using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensFlare : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(-0.5f, -0.25f, 0);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
