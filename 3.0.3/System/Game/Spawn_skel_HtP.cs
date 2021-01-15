using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_skel_HtP : MonoBehaviour {

    public GameObject obj;
    int var;
    public float interval;
    public GameObject parent;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnObj", 0.1f, interval);
    }

    // Update is called once per frame
    void SpawnObj()
    {
        var = Random.Range(3, 5);
        if (var == 4)
        {
            Instantiate(obj, transform.position, Quaternion.identity, parent.transform);
        }

    }
}
