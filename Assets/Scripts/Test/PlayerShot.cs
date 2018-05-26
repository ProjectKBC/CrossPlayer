using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    // x:取りあえず弾が出るだけです
    
    public GameObject bullet; // 弾のprefab

    public Transform muzzle; // 弾の発射点

    public float speed = 1000; // 弾の速度

    public int shotInterval = 3; // ショットの間隔

    int timeCount; // 弾の間隔を管理

    void Start()
    {

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

                GameObject bullets = GameObject.Instantiate(bullet) as GameObject; // 弾の複製

                force = this.gameObject.transform.up * speed;
                bullets.GetComponent<Rigidbody>().AddForce(force); // Rigidbodyに力を加えて発射
                bullets.transform.position = muzzle.position; // 弾の発射点を更新
            }
            else { timeCount = shotInterval; } // 発射してない時は次弾装填
        }
    }
}
