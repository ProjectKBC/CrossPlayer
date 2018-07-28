using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeronicaNB : MonoBehaviour {
    public string shooter;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            
            switch (shooter)
            {
                case "Player1":
                    this.transform.position = PlayerManager.gameObjectPL1.transform.position;
                    break;

                case "Player2":
                    this.transform.position = PlayerManager.gameObjectPL2.transform.position;
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            Destroy(gameObject);
        }
    }
}