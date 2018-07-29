using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeronicaPlayer : MonoBehaviour
{
    // x:もしかしてPlayerのスクリプトの時点で分ければ良いのでは？？
    public int HP = 100;
    public float SPD = 0.3f;

    public GameObject normalBullet; // 通常弾のプレハブ

    bool isExist = false; // 弾が既にあるかの判定

    private void Update()
    {
        Move();
        NormalShot();
    }

    private void Move()
    {
        switch (this.tag)
        {
            case "Player1":
                if (Input.GetKey(KeyCode.W)) { this.transform.position += Vector3.forward * SPD; }
                if (Input.GetKey(KeyCode.S)) { this.transform.position += Vector3.back * SPD; }
                if (Input.GetKey(KeyCode.D)) { this.transform.position += Vector3.right * SPD; }
                if (Input.GetKey(KeyCode.A)) { this.transform.position += Vector3.left * SPD; }
                break;

            case "Player2":
                if (Input.GetKey(KeyCode.UpArrow)) { this.transform.position += Vector3.forward * SPD; }
                if (Input.GetKey(KeyCode.DownArrow)) { this.transform.position += Vector3.back * SPD; }
                if (Input.GetKey(KeyCode.RightArrow)) { this.transform.position += Vector3.right * SPD; }
                if (Input.GetKey(KeyCode.LeftArrow)) { this.transform.position += Vector3.left * SPD; }
                break;
        }
    }

    private void NormalShot()
    {
        switch (this.tag)
        {
            case "Player1":
                // z キーを押している間
                if (Input.GetKey(KeyCode.Z))
                {
                    if (!isExist)
                    {
                        GameObject normalBullets = Instantiate(normalBullet) as GameObject; // 弾の生成
                        normalBullets.GetComponent<VeronicaNB>().shooter = this.tag;
                        normalBullets.transform.position = this.transform.position;
                        isExist = true;
                    }

                }

                // z キーを離した時
                if (Input.GetKeyUp(KeyCode.Z)) { isExist = false; }
                break;

            case "Player2":
                // m キーを押している間
                if (Input.GetKey(KeyCode.M))
                {
                    if (!isExist)
                    {
                        GameObject normalBullets = Instantiate(normalBullet) as GameObject; // 弾の生成
                        normalBullets.GetComponent<VeronicaNB>().shooter = this.tag;
                        normalBullets.transform.position = this.transform.position;
                        isExist = true;
                    }

                }

                // m キーを離した時
                if (Input.GetKeyUp(KeyCode.M)) { isExist = false; }
                break;
        }

    }

}
