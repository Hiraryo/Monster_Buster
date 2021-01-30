using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    //ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;
    public GameObject Stop_Button;
    // Start is called before the first frame update
    void Start()
    {
        //AdMobManager.instance.DestroyBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause_Button()
    {
        //if (Stop_Button.GetComponent<SpriteRenderer>().isVisible)
        {
            //ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            //ポーズUIが表示されている時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            //ポーズUIが表示されていなければ通常通り進行
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
