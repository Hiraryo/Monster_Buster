using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using NCMB;
using NCMB.Extensions;
using UnityEngine.SceneManagement;

namespace naichilab
{
    public class RankingSceneManager_Home : MonoBehaviour
    {
        //public GameObject Ranking_dialog;
        public GameObject Not_Network_dialog;
        [SerializeField] Button closeButton;
        [SerializeField] RectTransform scrollViewContent;
        [SerializeField] GameObject rankingNodePrefab;
        [SerializeField] GameObject readingNodePrefab;
        [SerializeField] GameObject notFoundNodePrefab;
        private const string RankingDataClassName = "MonsterBuster_EndlessMode";
        private NCMBObject highScoreSpreadSheetObject;

        /// <summary>
        /// 入力した名前
        /// </summary>
        /// <value>The name of the inputted.</value>

        void Start()
        {
            Not_Network_dialog.SetActive(false);
            StartCoroutine(GetHighScoreAndRankingBoard());
        }

        IEnumerator GetHighScoreAndRankingBoard()
        {
            //ランキング取得
            yield return StartCoroutine(LoadRankingBoard());
        }
        public void SendScore()
        {
            // ネットワークの状態を出力
            switch (Application.internetReachability)
            {
                case NetworkReachability.NotReachable:
                    Debug.Log("ネットワークには到達不可");
                    Not_Network_dialog.SetActive(true);
                    break;
                case NetworkReachability.ReachableViaCarrierDataNetwork:
                    Debug.Log("キャリアデータネットワーク経由で到達可能");
                    Not_Network_dialog.SetActive(false);
                    StartCoroutine(LoadRankingBoard());
                    break;
                case NetworkReachability.ReachableViaLocalAreaNetwork:
                    Debug.Log("Wifiまたはケーブル経由で到達可能");
                    Not_Network_dialog.SetActive(false);
                    StartCoroutine(LoadRankingBoard());
                    break;
            }
        }

        

        /// <summary>
        /// ランキング取得＆表示
        /// </summary>
        /// <returns>The ranking board.</returns>
        private IEnumerator LoadRankingBoard()
        {
            int nodeCount = scrollViewContent.childCount;
            Debug.Log(nodeCount);
            for (int i = nodeCount - 1; i >= 0; i--)
            {
                Destroy(scrollViewContent.GetChild(i).gameObject);
            }

            var msg = Instantiate(readingNodePrefab, scrollViewContent);

            //2017.2.0b3の描画されないバグ暫定対応
            MaskOffOn();

            var so = new YieldableNcmbQuery<NCMBObject>(RankingDataClassName);
            //so.Limit = 30;
            if (RankingLoader_Home.Instance.setting.Order == ScoreOrder.OrderByAscending)
            {
                so.OrderByAscending("hiscore");
            }
            else
            {
                so.OrderByDescending("hiscore");
            }
            yield return so.FindAsync();

            Debug.Log("count : " + so.Count.ToString());
            Destroy(msg);

            if (so.Count > 0)
            {

                int rank = 0;
                foreach (var r in so.Result)
                {

                    var n = Instantiate(this.rankingNodePrefab, scrollViewContent);
                    var rankNode = n.GetComponent<RankingNode>();
                    rankNode.NoText.text = (++rank).ToString();
                    rankNode.NameText.text = r["name"].ToString();
                    var s = RankingLoader_Home.Instance.BuildScore(r["hiscore"].ToString());
                    var d = RankingLoader_Home.Instance.BuildStageLv(r["stageLv"].ToString());
                    rankNode.ScoreText.text = s != null ? s.TextForDisplay : "エラー";
                    rankNode.StageLvText.text = r["stageLv"].ToString();
                    Debug.Log(r["hiscore"].ToString());
                }

            }
            else
            {
                Instantiate(this.notFoundNodePrefab, scrollViewContent);
            }
        }

        public void OnCloseButtonClick()
        {
            //this.closeButton.interactable = false;
            //Ranking_dialog.SetActive(false);
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Ranking_Home");
            //SceneManager.LoadScene("Home");
        }

        private void MaskOffOn()
        {
            //2017.2.0b3でなぜかScrollViewContentを追加しても描画されない場合がある。
            //親maskをOFF/ONすると直るので無理やり・・・
            var m = this.scrollViewContent.parent.GetComponent<Mask>();
            m.enabled = false;
            m.enabled = true;
        }

    }
}
