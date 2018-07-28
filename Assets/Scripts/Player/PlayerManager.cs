using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static GameObject gameObjectPL1 { get; private set; }
    public static GameObject gameObjectPL2 { get; private set; }

    // プレイヤー１が選べるキャラクター
    public enum PlayerEnum
    {
        Veronica,
        Anoma,
    }

    public PlayerEnum player1;

    // プレイヤー１のステータス
    public int player1_HP;
    public float player1_SPD;

    public PlayerEnum player2;

    // プレイヤー２のステータス;
    public int player2_HP;
    public float player2_SPD;

    private void OnValidate()
    {
        player1_HP = Mathf.Max (1, player1_HP);
        player2_HP = Mathf.Max(1, player2_HP);

        // キャラごとのデフォルトステータス
        switch(player1)
        {
            case PlayerEnum.Veronica:
                player1_HP = 100;
                player1_SPD = 0.3f;
                break;

            case PlayerEnum.Anoma:
                player1_HP = 200;
                player1_SPD = 0.2f;
                break;
        }

        switch(player2)
        {
            case PlayerEnum.Veronica:
                player2_HP = 100;
                player2_SPD = 0.3f;
                break;

            case PlayerEnum.Anoma:
                player2_HP = 200;
                player2_SPD = 0.2f;
                break;
        }
    }

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

        // ステータスの割り振り
        Player tmp = gameObjectPL1.AddComponent<Player>();
        tmp.HP = player1_HP;
        tmp.SPD = player1_SPD;
        gameObjectPL1.tag = "Player1";
        tmp = gameObjectPL2.AddComponent<Player>();
        tmp.HP = player2_HP;
        tmp.SPD = player2_SPD;
        gameObjectPL2.tag = "Player2";

    }
}