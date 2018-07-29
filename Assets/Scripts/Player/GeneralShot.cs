using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralShot : MonoBehaviour {

    public GameObject normalBullet; // 通常弾のプレハブ

    public int shotInterval = 3; // ショットの間隔

    int timeCount; // 弾の間隔を管理
	
	private void Update ()
    {
        // z キーを押している間
        if (Input.GetKey(KeyCode.Z))
        {
            timeCount++;
            if(timeCount > shotInterval)
            {
                timeCount = 0;

                GameObject normalBullets = Instantiate(normalBullet) as GameObject; // 弾の生成
                normalBullets.transform.position = this.transform.position; // 弾の発射点を更新
            }

        }
	}
}
