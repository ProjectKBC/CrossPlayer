using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeronicaNB : MonoBehaviour
{
    public string shooter;

    private void Update()
    {
        switch (shooter)
        {
            case "Player1":
                // z キーを押している間
                if (Input.GetKey(KeyCode.Z))
                {
                    this.transform.position = PlayerManager.gameObjectPL1.transform.position;
                }

                // z キーを離した
                if (Input.GetKeyUp(KeyCode.Z))
                {
                    Destroy(gameObject);
                }
                break;

            case "Player2":
                // m キーを押している間
                if (Input.GetKey(KeyCode.M))
                {
                    this.transform.position = PlayerManager.gameObjectPL2.transform.position;
                }

                // m キーを離した
                if (Input.GetKeyUp(KeyCode.M))
                {
                    Destroy(gameObject);
                }
                break;
        }

    }
}