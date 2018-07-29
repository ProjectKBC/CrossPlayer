using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeronicaPlayer : MonoBehaviour {
    // x:もしかしてPlayerのスクリプトの時点で分ければ良いのでは？？
    public int HP = 100;
    public float SPD = 0.3;

    [System.NonSerialized]
    public bool isStun = false;

    private void Update()
    {
        if (!isStun)
        {
            Move();
        }

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

}
