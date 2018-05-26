using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    // x:取りあえず弾が出るだけです
    
    public GameObject bullet; // 弾のprefab

    public Transform muzzle; // 弾の発射点

    public float speed = 1000; // 弾の速度

    int timeCount;

    void Start()
    {

    }

    void Update()
    {
        const int SHOT_INTERVAL = 3; // ショットの間隔

        // z キーを押している間
        if (Input.GetKey(KeyCode.Z))
        {
            timeCount++;
           
            if (timeCount > SHOT_INTERVAL)
            {
                timeCount = 0;

                GameObject bullets = GameObject.Instantiate(bullet) as GameObject; // 弾の複製

                Vector3 force;
                force = this.gameObject.transform.up * speed;
                bullets.GetComponent<Rigidbody>().AddForce(force); // Rigidbodyに力を加えて発射
                bullets.transform.position = muzzle.position; // 弾の発射点を更新
            }
        } else { timeCount = SHOT_INTERVAL; } // 発射してない時は次弾装填
    }
}
