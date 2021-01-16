using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;//Addressablesを使うのに必要

public class Load_Asset : MonoBehaviour
{
    private void Start()
    {
        //PrefabというLabelが付いたGameObjectを全て取得
        Addressables.LoadAssetsAsync<Sprite>("Game", OnLoadPrefab);
    }

    //Prefabのロードが完了する度に(1つのPrefabづつ)呼ばれる
    private void OnLoadPrefab(Sprite sprite)
    {
        Debug.Log(sprite.name);
    }
}
