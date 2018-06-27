using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    // x:取りあえず弾が出るだけです
    
    public GameObject normalBullet; // 通常弾のprefab

    public GameObject specialBullet; // 特殊弾のprefab

    public Transform muzzle; // 弾の発射点

    public float speed = 1000; // 弾の速度

    public int shotInterval = 3; // ショットの間隔

    int timeCount; // 弾の間隔を管理

    float playerSpeed;

    float startTime;

    void Start()
    {
        playerSpeed = GetComponent<PlayerTest>().speed;
    }

    void Update()
    {

        // z キーを押している間
        if (Input.GetKey(KeyCode.Z))
        {
            Vector3 force;
            timeCount++;

            if (timeCount > shotInterval)
            {
                timeCount = 0;

                GameObject normalBullets = GameObject.Instantiate(normalBullet) as GameObject; // 弾の複製

                force = this.gameObject.transform.up * speed;
                normalBullets.GetComponent<Rigidbody>().AddForce(force); // Rigidbodyに力を加えて発射
                normalBullets.transform.position = muzzle.position; // 弾の発射点を更新
            }
            else { timeCount = shotInterval; } // 発射してない時は次弾装填
        }
        // x:特殊ショットのつもりです
        if (Input.GetKeyDown(KeyCode.X))
        {
            Vector3 force;
            startTime = Time.time;

            GameObject specialBullets = GameObject.Instantiate(specialBullet) as GameObject; // 弾の複製

            GetComponent<PlayerTest>().speed = 0;

            //force = this.gameObject.transform.up * speed;
            //specialBullets.GetComponent<Rigidbody>().AddForce(force); // Rigidbodyに力を加えて発射
            specialBullets.transform.position = muzzle.position; // 弾の発射点を更新
        }
        if (Time.time - startTime > 0.5)
        {
            GetComponent<PlayerTest>().speed = playerSpeed;
        }
    }
}
