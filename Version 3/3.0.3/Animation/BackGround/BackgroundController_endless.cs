using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController_endless : MonoBehaviour {

    [SerializeField]
    Warning3 script1;

    GameObject Warning;

	// スクロールするスピード
	public float speed = 0.1f;
	// Use this for initialization
	void Start () {
        Warning = GameObject.Find("Warning");
        //script1 = Warning.GetComponent<Warning>();
    }

    // Update is called once per frame
    void Update () {
        bool d_ff = script1.d_f;
        if (d_ff == true)
        {
			// 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
			float x = Mathf.Repeat(Time.time * speed, 1);

			// Yの値がずれていくオフセットを作成
			Vector2 offset = new Vector2(x, 0);

			// マテリアルにオフセットを設定する
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
		}
    }
}