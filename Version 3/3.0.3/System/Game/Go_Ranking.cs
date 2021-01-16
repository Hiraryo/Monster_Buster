using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_Ranking : MonoBehaviour
{
    public GameObject Ranking_dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Go_to_Ranking()
    {
        naichilab.RankingLoader_Home.Instance.SendScoreAndShowRanking(0);
    }
}
