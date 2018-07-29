using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlayer : MonoBehaviour
{
    public int HP = 100;
    public float SPD = 0.3f;

    public GameObject normalBullet; // 通常弾のプレハブ

    public int shotInterval = 3; // ショットの間隔

    int timeCount; // 弾の間隔を管理
   

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
                    timeCount++;
                    if (timeCount > shotInterval)
                    {
                        timeCount = 0;

                        GameObject normalBullets = Instantiate(normalBullet) as GameObject; // 弾の生成
                        normalBullets.transform.position = this.transform.position; // 弾の発射点を更新
                    }

                }
                break;

            case "Player2":
                // m キーを押している間
                if (Input.GetKey(KeyCode.M))
                {
                    timeCount++;
                    if (timeCount > shotInterval)
                    {
                        timeCount = 0;

                        GameObject normalBullets = Instantiate(normalBullet) as GameObject; // 弾の生成
                        normalBullets.transform.position = this.transform.position; // 弾の発射点を更新
                    }

                }
                break;
        }
    }

}
