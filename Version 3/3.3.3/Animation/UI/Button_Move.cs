using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Button_Move : MonoBehaviour
{
    public GameObject back_button;
    public GameObject quest;
    public GameObject quest_easy;
    public GameObject quest_normal;
    public GameObject quest_heard;
    public GameObject quest_endless;
    public GameObject strengthen;
    public GameObject skill;
    public GameObject character;
    //public GameObject Magic_Canvas;
    //public GameObject strengthen_player_LvUP;
    //public GameObject strengthen_skill_LvUP;
    public GameObject how_to_play;
    public GameObject Ranking;
    public GameObject privacy_policy;
    //public GameObject go_Title;
    public GameObject other_Button;
    public int button_dx = 5;
    public int button_soto_x = -604;    //一番下のボタンが画面外の時のX座標
    public int button_menu_x = 560; //はじめのボタンの移動終了位置
    public int button_quest_x = 1000;    //クエストメニュー一覧ボタンの移動終了位置
    public int button_skill_x = 0; //スキルが停止する位置
    public int button_z_1 = 0;  //画面上で停止するZ値
    public int button_z_2 = -250;   //画面外で停止するZ値
    public int character_z = -500;  //キャラクターの画面外停止Z座標
    public int magic_z = -100;  //魔法陣の画面外停止Z座標
    //public int go_title_button_x = -130;
    float back_x;
    float back_y;
    float quest_x;
    float quest_y;
    float strengthen_x;
    float strengthen_y;
    float how_to_play_x;
    float how_to_play_y;
    float ranking_x;
    float ranking_y;
    float privacy_policy_x;
    float privacy_policy_y;
    //float go_title_x;
    //float go_title_y;
    float quest_easy_x;
    float quest_easy_y;
    float quest_normal_x;
    float quest_normal_y;
    float quest_heard_x;
    float quest_heard_y;
    float quest_endless_x;
    float quest_endless_y;
    float skill_x;
    float skill_y;
    float chara_x;
    float chara_y;
    float chara_z;
    //float magic_Canvas_x;
    //float magic_Canvas_y;
    //float magic_Canvas_z;
    bool button_start_f;
    bool back_f;
    bool quest_f;
    bool strengthen_f;
    
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        //AdMobManager.instance.RequestBanner();
        //AdMobManager.instance.DestroyBanner();
        other_Button.SetActive(false);
        /*
        quest.SetActive(true);
        quest_easy.SetActive(false);
        quest_normal.SetActive(false);
        quest_heard.SetActive(false);
        quest_endless.SetActive(false);
        strengthen.SetActive(true);
        //strengthen_player_LvUP.SetActive(false);
        //strengthen_skill_LvUP.SetActive(false);
        multiplayer.SetActive(true);
        how_to_play.SetActive(true);
        privacy_policy.SetActive(true);
        */
        button_start_f = true;
        //各ボタンの初期X座標をそれぞれの変数に代入
        back_x = back_button.transform.localPosition.x;
        back_y = back_button.transform.localPosition.y;
        //go_title_x = go_Title.transform.localPosition.x;
        //go_title_y = go_Title.transform.localPosition.y;
        //-------------------------------------------------------------
        quest_x = quest.transform.localPosition.x;
        strengthen_x = strengthen.transform.localPosition.x;
        how_to_play_x = how_to_play.transform.localPosition.x;
        privacy_policy_x = privacy_policy.transform.localPosition.x;
        ranking_x = Ranking.transform.localPosition.x;

        quest_y = quest.transform.localPosition.y;
        strengthen_y = strengthen.transform.localPosition.y;
        how_to_play_y = how_to_play.transform.localPosition.y;
        privacy_policy_y = privacy_policy.transform.localPosition.y;
        ranking_y = Ranking.transform.localPosition.y;
        //-------------------------------------------------------------
        quest_easy_x = quest_easy.transform.localPosition.x;
        quest_normal_x = quest_normal.transform.localPosition.x;
        quest_heard_x = quest_heard.transform.localPosition.x;
        quest_endless_x = quest_endless.transform.localPosition.x;

        quest_easy_y = quest_easy.transform.localPosition.y;
        quest_normal_y = quest_normal.transform.localPosition.y;
        quest_heard_y = quest_heard.transform.localPosition.y;
        quest_endless_y = quest_endless.transform.localPosition.y;
        //-------------------------------------------------------------
        skill_x = skill.transform.localPosition.x;
        skill_y = skill.transform.localPosition.y;
        //-------------------------------------------------------------
        chara_x = character.transform.localPosition.x;
        chara_y = character.transform.localPosition.y;
        chara_z = character.transform.localPosition.z;
        //-------------------------------------------------------------
        //magic_Canvas_x = Magic_Canvas.transform.localPosition.x;
        //magic_Canvas_y = Magic_Canvas.transform.localPosition.y;
        //magic_Canvas_z = Magic_Canvas.transform.localPosition.z;
        //-------------------------------------------------------------
        back_f = false;
        quest_f = false;
        strengthen_f = false;
    }

    // Update is called once per frame
    void Update()
    {
        //シーン開始時
        if (button_start_f == true)
        {
            quest.transform.DOLocalMove(endValue: new Vector3(button_menu_x, quest_y,button_z_1), duration: 1.0f);
            strengthen.transform.DOLocalMove(endValue: new Vector3(button_menu_x, strengthen_y, button_z_1), duration: 1.0f);
            how_to_play.transform.DOLocalMove(endValue: new Vector3(button_menu_x, how_to_play_y, button_z_1), duration: 1.0f);
            privacy_policy.transform.DOLocalMove(endValue: new Vector3(button_menu_x, privacy_policy_y, button_z_1), duration: 1.0f);
            Ranking.transform.DOLocalMove(endValue: new Vector3(button_menu_x, ranking_y, button_z_1), duration: 1.0f);
            //go_Title.transform.DOLocalMove(endValue: new Vector3(go_title_button_x, go_title_y, button_z_1), duration: 1.0f);
        }
        if (privacy_policy.transform.localPosition.x <= button_quest_x)
        {
            button_start_f = false;
        }
        //クエスト、強化ボタンが押された時、初めのメニューを左に移動
        if (quest_f == true || strengthen_f == true)
        {
            quest.transform.DOLocalMove(endValue: new Vector3(button_soto_x - (80 * 5), quest_y, button_z_2), duration: 1.0f);
            strengthen.transform.DOLocalMove(endValue: new Vector3(button_soto_x - (80 * 4), strengthen_y, button_z_2), duration: 1.0f);
            how_to_play.transform.DOLocalMove(endValue: new Vector3(button_soto_x - (80 * 3), how_to_play_y, button_z_2), duration: 1.0f);
            privacy_policy.transform.DOLocalMove(endValue: new Vector3(button_soto_x - (80 * 2), privacy_policy_y, button_z_2), duration: 1.0f);
            Ranking.transform.DOLocalMove(endValue: new Vector3(button_soto_x - 80, ranking_y, button_z_2), duration: 1.0f);
        }
        
        //クエストボタンが押された時
        if (quest_f == true)
        {
            quest_easy.transform.DOLocalMove(endValue: new Vector3(button_menu_x, quest_easy_y, button_z_1), duration: 1.0f);
            quest_normal.transform.DOLocalMove(endValue: new Vector3(button_menu_x, quest_normal_y, button_z_1), duration: 1.0f);
            quest_heard.transform.DOLocalMove(endValue: new Vector3(button_menu_x, quest_heard_y, button_z_1), duration: 1.0f);
            quest_endless.transform.DOLocalMove(endValue: new Vector3(button_menu_x, quest_endless_y, button_z_1), duration: 1.0f);
            back_button.transform.DOLocalMove(endValue: new Vector3(button_menu_x, back_y, button_z_1), duration: 1.0f);
        }

        //強化ボタンが押された時
        if (strengthen_f == true)
        {
            skill.transform.DOLocalMove(endValue: new Vector3(button_skill_x, skill_y, button_z_1), duration: 1.0f);
            back_button.transform.DOLocalMove(endValue: new Vector3(button_menu_x, back_y, button_z_1), duration: 1.0f);
            character.transform.DOLocalMove(endValue: new Vector3(chara_x, chara_y, character_z), duration: 1.0f);
            //Magic_Canvas.transform.DOLocalMove(endValue: new Vector3(magic_Canvas_x, magic_Canvas_y, magic_z), duration: 1.0f);
        }
        if (back_f == true)
        {
            quest.transform.DOLocalMove(endValue: new Vector3(button_menu_x, quest_y, button_z_1), duration: 1.0f);
            strengthen.transform.DOLocalMove(endValue: new Vector3(button_menu_x, strengthen_y, button_z_1), duration: 1.0f);
            how_to_play.transform.DOLocalMove(endValue: new Vector3(button_menu_x, how_to_play_y, button_z_1), duration: 1.0f);
            privacy_policy.transform.DOLocalMove(endValue: new Vector3(button_menu_x, privacy_policy_y, button_z_1), duration: 1.0f);
            Ranking.transform.DOLocalMove(endValue: new Vector3(button_menu_x, ranking_y, button_z_1), duration: 1.0f);

            quest_easy.transform.DOLocalMove(endValue: new Vector3(quest_easy_x, quest_easy_y, button_z_2), duration: 1.0f);
            quest_normal.transform.DOLocalMove(endValue: new Vector3(quest_normal_x, quest_normal_y, button_z_2), duration: 1.0f);
            quest_heard.transform.DOLocalMove(endValue: new Vector3(quest_heard_x, quest_heard_y, button_z_2), duration: 1.0f);
            quest_endless.transform.DOLocalMove(endValue: new Vector3(quest_endless_x, quest_endless_y, button_z_2), duration: 1.0f);
            back_button.transform.DOLocalMove(endValue: new Vector3(back_x, back_y, button_z_2), duration: 1.0f);
            skill.transform.DOLocalMove(endValue: new Vector3(skill_x, skill_y, button_z_2), duration: 1.0f);
            character.transform.DOLocalMove(endValue: new Vector3(chara_x, chara_y, chara_z), duration: 1.0f);
            //Magic_Canvas.transform.DOLocalMove(endValue: new Vector3(magic_Canvas_x, magic_Canvas_y, magic_Canvas_z), duration: 1.0f);
        }
    }

    public void Back_Button()
    {
        back_f = true;
        quest_f = false;
        strengthen_f = false;
    }
    public void Quest_Button()
    {
        back_f = false;
        quest_f = true;
        strengthen_f = false;
    }
    public void Strengthen_Button()
    {
        back_f = false;
        quest_f = false;
        strengthen_f = true;
    }
    public void On_Other_Button()
    {
        other_Button.SetActive(true);
    }
    public void Go_Title()
    {
        SceneManager.LoadScene("Title");
    }
}
