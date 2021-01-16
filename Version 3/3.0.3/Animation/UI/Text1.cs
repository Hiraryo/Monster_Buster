using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Text1 : MonoBehaviour
{
    //[SerializeField]
    //GameObject InsTech;

    [SerializeField]
    Fade fade = null;

    [SerializeField]
    RectTransform rectTran;

    //[SerializeField]
    //GameObject FadeMask;

    bool InsTech_start = false;
    int num = 0;
    float time;
    public GameObject I;
    float alpha;             //アルファ値
    public float alpha_float;
    public float pos_float; //0.8
    public float scale_float;   //0.8
    public Vector3 pos;     //0,-61,0
    public Vector3 scale;   //25.3,24.850654,24.85065
    public RectTransform Ins;
    // Start is called before the first frame update
    void Start()
    {
        //alpha = 1.0f;
        AdMobManager.instance.RequestInterstitial();
        I.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
        I.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("alpha = " + alpha);
        
        InsTech_start = TypefaceAnimator.GetInsTech();
        if (InsTech_start == true)
        {
            alpha += alpha_float;
            I.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
            //I.transform.DOLocalMoveY(pos.y, pos_float);
            //Ins.DOScale(endValue: new Vector3(scale.x, scale.y, scale.z), duration: scale_float);
            if (num == 0)
            {

                I.SetActive(true);

                /*
                if(alpha >= 1)
                {
                    alpha += 0.1f;
                }
                */

                /*
                    DOTween.ToAlpha(
                        () => N_UI.color,
                        color => N_UI.color = color, 1f, 0.3f);
                    DOTween.ToAlpha(
                        () => S_UI.color,
                        color => S_UI.color = color, 1f, 0.3f);
                    DOTween.ToAlpha(
                        () => T_UI.color,
                        color => T_UI.color = color, 1f, 0.3f);
                    DOTween.ToAlpha(
                        () => E_UI.color,
                        color => E_UI.color = color, 1f, 0.3f);
                    DOTween.ToAlpha(
                        () => C_UI.color,
                        color => C_UI.color = color, 1f, 0.3f);
                    DOTween.ToAlpha(
                        () => H_UI.color,
                        color => H_UI.color = color, 1f, 0.3f);
                        */
                time += Time.deltaTime;
                if (time >= 0.2f)
                {
                    num = 1;

                    //FadeMask.GetComponent<Fade>().Start();
                    //1秒でスケール（1,1,1）にスケーリング
                    rectTran.DOScale(endValue: new Vector3(9.951094f, 0.1250695f, 0), duration: 0.4f).OnComplete(() =>
                    {

                        onComplete();
                        // アニメーションが終了時によばれる
                    });
                }

            }
        }
    }

    public void onComplete()
    {
        
        fade.FadeIn(1.5f,() =>
        {
            SceneManager.LoadScene("Title");
        });
        
    }
}
