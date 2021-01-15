using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    //ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Game_Start()
    {
        //ポーズUIのアクティブ、非アクティブを切り替え
        pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = 1f;
    }

    public void Go_Home()
    {
        //AdMobManager.instance.DestroyBanner();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }
}
