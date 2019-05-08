#Theta

##まずはTHETAのアプリをダウンロード。

https://support.theta360.com/ja/download/
DRLはここ、適宜なバージョンを選択してダウンロードします。
##THETAから画像をPC側にコピー
THETAはReadOnlyなので、コピーしないと作業できない。
##影像をアプリにドラッグ（画像ならこのステップは不要）
変換完了まで待つ
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/71d6b1ef-a348-909e-dd1a-070e73ff7ab8.png)
完了あと変換できた画像をUnityにインポート

##シーンの中でスフィアを作る
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/bea420e5-540e-9f7f-cb1d-c395cce84d61.png)
#球体の材質を変える
ディフォルトの材質は物理に基づくレンダリングなので、テクスチャーは光に影響される。これを避けるために、まずは新しいマテリアルを作って、それから【UnlitShader】を作る。
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/9c01a296-431f-909a-25a3-0a7e1e376e2e.png)
次にUnlitShaderをマテリアルに与える。
最後にマテリアルを球体に与える
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/7944f2a0-0744-d232-608d-f206d254a6a7.png)
↑こういう感じです。
##画像をドラッグしてマテリアルに与える
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/07ac74e4-bb19-1387-1e9d-fe91debf7544.png)
##影像の場合
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/fee2cc8a-8599-ba6f-8d2f-b4ed32f4ef09.png)
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/35fd1bde-0917-a3e3-de1a-152383eb302c.png)
↑ここにドラッグ

こうすると、もう画像が見えましたが、テクスチャーがスフィアの外についてるので、法線を反転しないといけない。

##最後のステップ
下のスクリプトを球体に追加

```C#：NormalReverser.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalReverser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] triangles = GetComponent<MeshFilter>().mesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }
        GetComponent<MeshFilter>().mesh.triangles = triangles;

    }
    // Update is called once per frame
    void Update()
    {

    }

}

```

![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/1c45c007-d953-bfb2-76bb-22ead618e72e.png)
スクリプトファイルの名前とクラスの名前は一緒じゃないとだめ。

何をやったかというと、マッシュの三角形の第二の点と第三の点を入れ替わった。
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/788323bd-2a43-b68f-1b7e-97a12484926c.png)
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/57fc9739-060b-90cb-0d1d-495517f67b34.png)
こうして、法線ベクトルが反転された。

##テスト
カメラの位置を球体の中心に合わせて、Play！
おすすめの位置は![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/534d9453-47ec-f61c-c68b-7607e974d253.png)
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/3e838a80-3e31-8380-2da2-a2e6a77e43b7.png)
ResetPositionをタッチすると自動に(0,0,0)に戻る。

最後はこういう感じです。
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/403926/64a21caf-70e0-f5f8-b265-88bb45538da1.png)
