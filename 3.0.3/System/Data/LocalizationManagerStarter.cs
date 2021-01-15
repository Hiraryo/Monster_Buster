using System.Collections;
using UnityEngine;

namespace _Project.Scripts
{
    /// <summary>
    /// LocalizationManagerを起動するクラス。
    /// 同じオブジェクトにLocalizationManagerもつけておくとNullReferenceExceptionを避けれる。
    /// </summary>
    [DefaultExecutionOrder(-1)]
    public class LocalizationManagerStarter : MonoBehaviour
    {
        IEnumerator Start()
        {
            // OSの使用言語を取得します。
            var lang = Application.systemLanguage;
            string setlang = "";
            if (lang == SystemLanguage.English)
            {
                setlang = "localizedText_en.json";
            }
            else
            {
                setlang = "localizedText_en.json";
            }
            yield return null;
        }
    }
}