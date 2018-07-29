using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeronicaPlayer : MonoBehaviour
{
    // x:もしかしてPlayerのスクリプトの時点で分ければ良いのでは？？
    public int HP = 100;
    public float SPD = 0.3f;

    public GameObject normalBullet; // 通常弾のプレハブ
    private VeronicaNB mNormalBullet;

    bool nbIsExist = false; // 弾が既にあるかの判定

    public const float SHOT_MAX_LP = 5.0f; // 弾のライフポイントの最大値

    public float shotLP; // 弾のライフポイント

    private void OnValidate()
    {
        shotLP = SHOT_MAX_LP;
    }

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
                if (Input.GetKey(KeyCode.Z) && shotLP > 0)
                {
                    if (!nbIsExist)
                    {
						normalBullet.transform.position = this.transform.position;
                        mNormalBullet = Instantiate(normalBullet).GetComponent<VeronicaNB>(); // 通常弾のキャッシュを生成
                        mNormalBullet.shooter = this.tag;
                        nbIsExist = true;
                    }
                    shotLP -= Time.deltaTime; // 弾を撃ってる間は弾のライフポイントが減る
                }

                // z キーを離している間
                if (!Input.GetKey(KeyCode.Z) && shotLP < SHOT_MAX_LP)
                {
                    shotLP += Time.deltaTime; // 弾を撃ってない間は弾のライフポイントが増える
                    mNormalBullet.shooter = "none";
                    nbIsExist = false;
                }
                break;

            case "Player2":
                // m キーを押している間
                if (Input.GetKey(KeyCode.M) && shotLP > 0)
                {
                    if (!nbIsExist)
                    {
                        normalBullet.transform.position = this.transform.position;
                        mNormalBullet = Instantiate(normalBullet).GetComponent<VeronicaNB>(); // 通常弾のキャッシュを生成
                        mNormalBullet.shooter = this.tag;
                        nbIsExist = true;
                    }
                    shotLP -= Time.deltaTime; // 弾を撃ってる間は弾のライフポイントが減る
                }

                // m キーを離している間
                if (!Input.GetKey(KeyCode.M) && shotLP < SHOT_MAX_LP)
                {
                    shotLP += Time.deltaTime; // 弾を撃ってない間は弾のライフポイントが増える
                    mNormalBullet.shooter = "none";
                    nbIsExist = false;
                }
                break;
        }

        // 弾のライフポイントが切れた時
        if (shotLP <= 0)
        {
            mNormalBullet.shooter = "none";
        }

    }

}
