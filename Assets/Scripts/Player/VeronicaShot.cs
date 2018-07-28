using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeronicaShot : MonoBehaviour
{
    // x:キャラクターごとにショットのスクリプトを用意してみるテスト

    public GameObject normalBullet; // 通常弾のプレハブ

    bool isExist = false;

    public string plTag;

    private void Start()
    {
        plTag = this.GetComponent<Player>().tag;
    }

    private void Update()
    {

        // z キーを押している間
        if (Input.GetKey(KeyCode.Z))
        {
            if (!isExist)
            {
                GameObject normalBullets = Instantiate(normalBullet) as GameObject; // 弾の生成
                normalBullets.GetComponent<VeronicaNB>().shooter = plTag;
                normalBullets.transform.position = this.transform.position;
                isExist = true;

                normalBullets.SetActive(true);
            }

        }

        // z キーを離した時
        if (Input.GetKeyUp(KeyCode.Z)) { isExist = false; }

    }

}
