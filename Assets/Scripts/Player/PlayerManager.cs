using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static GameObject gameObjectPL1 { get; private set; }
    public static GameObject gameObjectPL2 { get; private set; }

    // プレイヤーが選べるキャラクター
    public enum PlayerEnum
    {
        Veronica,
        Anoma,
    }

    public PlayerEnum player1;
    public PlayerEnum player2;

    private void Start()
    {
        string pl1name = player1.ToString();
        string pl2name = player2.ToString();

        // キャラの生成
        gameObjectPL1 = Instantiate((GameObject)Resources.Load("Prefabs/Character/" + pl1name)) as GameObject;
        gameObjectPL1.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        gameObjectPL1.transform.position = new Vector3(-2.25f, 0, -2.25f);
        gameObjectPL1.transform.rotation = Quaternion.Euler(90, 0, 0);

        gameObjectPL2 = Instantiate((GameObject)Resources.Load("Prefabs/Character/" + pl2name)) as GameObject;
        gameObjectPL2.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        gameObjectPL2.transform.position = new Vector3(2.25f, 0, -2.25f);
        gameObjectPL2.transform.rotation = Quaternion.Euler(90, 0, 0);

        gameObjectPL1.tag = "Player1";
        gameObjectPL2.tag = "Player2";

    }
}