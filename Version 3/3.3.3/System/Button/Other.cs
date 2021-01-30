using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Other : MonoBehaviour
{
    public GameObject Other_Message;
    int Other_Message_f = 0;
    int Sound_f = 0;
    int Sound_Back_f = 0;
    public GameObject sound;
    public GameObject privacy;
    public GameObject go_title;
    public GameObject site;
    public GameObject Sound_Contoller;
    Image Other_UI;
    Image sound_UI;
    Image privacy_UI;
    Image go_title_UI;
    Image site_UI;
    Image BGM_ON_UI;
    Image BGM_OFF_UI;
    Image SE_ON_UI;
    Image SE_OFF_UI;
    Vector2 Other_Message_pos;
    Vector2 sound_pos;
    Vector2 privacy_pos;
    Vector2 go_title_pos;
    Vector2 site_pos;
    Vector2 sound_Con_pos;
    float PositionX = 2000.0f;
    float _ZoomX = 1.0f;
    float _ZoomY = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        Other_UI = Other_Message.gameObject.GetComponent<Image>();
        sound_UI = sound.gameObject.GetComponent<Image>();
        privacy_UI = privacy.gameObject.GetComponent<Image>();
        go_title_UI = go_title.gameObject.GetComponent<Image>();
        site_UI = site.gameObject.GetComponent<Image>();
        Other_Message.SetActive(false);
        sound.SetActive(false);
        privacy.SetActive(false);
        go_title.SetActive(false);
        site.SetActive(false);
        Sound_Contoller.SetActive(false);
        Other_Message_pos = Other_Message.gameObject.GetComponent<RectTransform>().anchoredPosition;
        sound_pos = sound.gameObject.GetComponent<RectTransform>().anchoredPosition;
        privacy_pos = privacy.gameObject.GetComponent<RectTransform>().anchoredPosition;
        go_title_pos = go_title.gameObject.GetComponent<RectTransform>().anchoredPosition;
        site_pos = site.gameObject.GetComponent<RectTransform>().anchoredPosition;
        sound_Con_pos = Sound_Contoller.GetComponent<RectTransform>().anchoredPosition;

        Other_Message.gameObject.GetComponent<RectTransform>().anchoredPosition = Other_Message_pos;
        sound.gameObject.GetComponent<RectTransform>().anchoredPosition = sound_pos;
        privacy.gameObject.GetComponent<RectTransform>().anchoredPosition = privacy_pos;
        go_title.gameObject.GetComponent<RectTransform>().anchoredPosition = go_title_pos;
        site.gameObject.GetComponent<RectTransform>().anchoredPosition = site_pos;
        Sound_Contoller.gameObject.GetComponent<RectTransform>().anchoredPosition = sound_Con_pos;
    }
    // Update is called once per frame
    void Update()
    {
        if (Other_Message_f == 1)
        {
            
            Other_Message.SetActive(true);
            DOTween.ToAlpha(
                () => Other_UI.color,
                color => Other_UI.color = color,
                1f,
                0f
            );
            DOTween.ToAlpha(
                () => sound_UI.color,
                color => sound_UI.color = color,
                1f,
                0f
            );
            DOTween.ToAlpha(
                () => privacy_UI.color,
                color => privacy_UI.color = color,
                1f,
                0f
            );
            DOTween.ToAlpha(
                () => go_title_UI.color,
                color => go_title_UI.color = color,
                1f,
                0f
            );
            DOTween.ToAlpha(
                () => site_UI.color,
                color => site_UI.color = color,
                1f,
                0f
            );
            Other_Message.transform.DOScale(endValue: new Vector2(_ZoomX, _ZoomY), duration: 0.6f).OnComplete(() =>
            {
                sound.SetActive(true);
                privacy.SetActive(true);
                go_title.SetActive(true);
                //site.SetActive(true);
                sound.transform.DOLocalMoveY(200.0f,0.7f);  //230(公式サイトを表示した場合のY座標)
                privacy.transform.DOLocalMoveY(0.0f, 0.7f); //70(公式サイトを表示した場合のY座標)
                go_title.transform.DOLocalMoveY(-200.0f, 0.7f); //-70(公式サイトを表示した場合のY座標)
                //site.transform.DOLocalMoveY(-230.0f, 0.7f);   -230(公式サイトを表示した場合のY座標)
            });
            Other_Message_f = 0;
        }
        if (Other_Message_f == 2)
        {
            if(Sound_f == 1)
            {
                Sequence sequence3 = DOTween.Sequence()
                .OnStart(() =>
                {
                    Sound_Contoller.transform.DOScale(endValue: new Vector2(28.0f, 20.0f), duration: 0.2f);
                }).Join(
                    DOTween.ToAlpha(() =>
                    BGM_ON_UI.color,
                    color => BGM_ON_UI.color = color,
                    0f,
                    0.25f
                )).Join(
                    DOTween.ToAlpha(() =>
                    BGM_OFF_UI.color,
                    color => BGM_OFF_UI.color = color,
                    0f,
                    0.25f
                )).Join(
                    DOTween.ToAlpha(() =>
                    SE_ON_UI.color,
                    color => SE_ON_UI.color = color,
                    0f,
                    0.25f
                )).Join(
                    DOTween.ToAlpha(() =>
                    SE_OFF_UI.color,
                    color => SE_OFF_UI.color = color,
                    0f,
                    0.25f
                )).OnComplete(() =>
                {
                    Sound_Contoller.transform.DOLocalMove(endValue: new Vector2(sound_Con_pos.x, sound_Con_pos.y), duration: 0.1f);
                    Other_Message.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 0.1f);
                    sound.transform.DOLocalMove(endValue: new Vector2(sound_pos.x, sound_pos.y), duration: 0.1f);
                    privacy.transform.DOLocalMove(endValue: new Vector2(privacy_pos.x, privacy_pos.y), duration: 0.1f);
                    go_title.transform.DOLocalMove(endValue: new Vector2(go_title_pos.x, go_title_pos.y), duration: 0.1f);
                    site.transform.DOLocalMove(endValue: new Vector2(site_pos.x, site_pos.y), duration: 0.1f);
                    Other_Message.SetActive(false);
                    sound.SetActive(false);
                    privacy.SetActive(false);
                    go_title.SetActive(false);
                    site.SetActive(false);
                    Sound_Contoller.SetActive(false);
                });
                Sound_f = 0;
            }
            Sequence sequence = DOTween.Sequence()
                .OnStart(() =>
                {
                    Other_Message.transform.DOScale(endValue: new Vector2(_ZoomX*2, _ZoomY*2), duration: 0.2f);
                })
                .Join(
                DOTween.ToAlpha(() =>
                Other_UI.color,
                color => Other_UI.color = color,
                0f,
                0.25f
            )).Join(DOTween.ToAlpha(
                () => sound_UI.color,
                color => sound_UI.color = color,
                0f,
                0.25f
            )).Join(DOTween.ToAlpha(
                () => privacy_UI.color,
                color => privacy_UI.color = color,
                0f,
                0.25f
            )).Join(DOTween.ToAlpha(
                () => go_title_UI.color,
                color => go_title_UI.color = color,
                0f,
                0.25f
            )).Join(DOTween.ToAlpha(
                () => site_UI.color,
                color => site_UI.color = color,
                0f,
                0.25f
            )).OnComplete(() =>
                {
                    Other_Message.transform.DOScale(endValue: new Vector2(0f, 0f), duration: 0.1f);
                    Other_Message.SetActive(false);
                    sound.SetActive(false);
                    privacy.SetActive(false);
                    go_title.SetActive(false);
                    site.SetActive(false);
                    Sound_Contoller.SetActive(false);
                });
            Other_Message_f = 0;
        }

        if(Sound_f == 1)
        {
            Sound_Contoller.transform.DOScale(endValue: new Vector2(5f, 3f), duration: 0.1f);
            Sound_Contoller.SetActive(true);
            Sequence sequence2 = DOTween.Sequence()
            .OnStart(() =>
            {
                sound.transform.DOLocalMoveX(PositionX*-1, 0.5f);
            }).Join(
                privacy.transform.DOLocalMoveX(PositionX, 0.5f)
            ).Join(
                go_title.transform.DOLocalMoveX(PositionX*-1, 0.5f)
            ).Join(
                site.transform.DOLocalMoveX(PositionX, 0.5f)
            ).OnComplete(() =>
            {
                Sound_Contoller.transform.DOLocalMoveY(0f, 0.3f);
            });
            Sound_f = 0;
        }
        if (Sound_Back_f == 1)
        {
            Sound_Contoller.transform.DOLocalMoveY(-1280f, 0.15f).OnComplete(() =>
            {
                site.transform.DOLocalMoveX(0f, 0.1f).OnComplete(() =>
                {
                    go_title.transform.DOLocalMoveX(0f, 0.1f).OnComplete(() =>
                    {
                        privacy.transform.DOLocalMoveX(0f, 0.1f).OnComplete(() =>
                        {
                            sound.transform.DOLocalMoveX(0f, 0.1f);
                        });
                    });
                });
            });
            Sound_Back_f = 0;
        }
    }
    public void Other_Button_Push()
    {
        Other_Message_f = 1;
        Other_Message.gameObject.GetComponent<RectTransform>().anchoredPosition = Other_Message_pos;
        sound.gameObject.GetComponent<RectTransform>().anchoredPosition = sound_pos;
        privacy.gameObject.GetComponent<RectTransform>().anchoredPosition = privacy_pos;
        go_title.gameObject.GetComponent<RectTransform>().anchoredPosition = go_title_pos;
        site.gameObject.GetComponent<RectTransform>().anchoredPosition = site_pos;
        Sound_Contoller.gameObject.GetComponent<RectTransform>().anchoredPosition = sound_Con_pos;
    }

    public void Other_close_Push()
    {
        Other_Message_f = 2;
    }

    public void Sound_Push()
    {
        Sound_f = 1;
        Sound_Back_f = 0;
    }

    public void Sound_Back_Push()
    {
        Sound_f = 0;
        Sound_Back_f = 1;
        sound.transform.localPosition = new Vector2(PositionX*-1, 200f);  //230(公式サイトを表示した場合のY座標)
        privacy.transform.localPosition = new Vector2(PositionX, 0f);   //70(公式サイトを表示した場合のY座標)
        go_title.transform.localPosition = new Vector2(PositionX*-1, -200f);  //-70(公式サイトを表示した場合のY座標)
        //site.transform.localPosition = new Vector2(PositionX, -230f); //-230(公式サイトを表示した場合のY座標)
    }
}
