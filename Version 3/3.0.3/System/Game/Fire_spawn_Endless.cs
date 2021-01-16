using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_spawn_Endless : MonoBehaviour {
    [SerializeField]
    Warning3 script1;
    public GameObject Tama;
    public float interval;
    int count;
    int count2;
    bool d_f;
    // Use this for initialization
    void Start () {
        count = 0;
        InvokeRepeating("Hidama", 0.1f, interval);
    }
	
	// Update is called once per frame
	void Update () {
        d_f = Boss_Endless2.Set_dragon_posOK();
    }
    void Hidama()
    {
        if (d_f == true){
            count2 = Random.Range(3, 5);
            if (count2 == 4)
            {
                Update();
                count2++;
                Instantiate(Tama, this.transform.position, this.transform.rotation);
            }
        }
    }
}
