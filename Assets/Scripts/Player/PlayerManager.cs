using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    // プレイヤー１が選べるキャラクター
    public enum Player1
    {
        Veronica,
        Anoma,
    }

    public enum Player2
    {
        Veronica,
        Anoma,
    }

    public Player1 player1;

    // プレイヤー１のステータス
    public int player1_HP;
    public float player1_SPD;

    public Player2 player2;

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
            case Player1.Veronica:
                player1_HP = 100;
                player1_SPD = 0.3f;
                break;

            case Player1.Anoma:
                player1_HP = 200;
                player1_SPD = 0.2f;
                break;
        }

        switch(player2)
        {
            case Player2.Veronica:
                player2_HP = 100;
                player2_SPD = 0.3f;
                break;

            case Player2.Anoma:
                player2_HP = 200;
                player2_SPD = 0.2f;
                break;
        }
    }

    private void Start()
    {
        string P1name = player1.ToString();
        string P2name = player2.ToString();
        // キャラの生成
        GameObject char1 = Instantiate((GameObject)Resources.Load("Models/" + P1name)) as GameObject;
        char1.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        char1.transform.position = new Vector3(-2.25f, 0, -2.25f);
        char1.transform.rotation = Quaternion.Euler(90, 0, 0);
        GameObject char2 = Instantiate((GameObject)Resources.Load("Models/" + P2name)) as GameObject;
        char2.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        char2.transform.position = new Vector3(2.25f, 0, -2.25f);
        char2.transform.rotation = Quaternion.Euler(90, 0, 0);

        // ステータスの割り振り
        char1.AddComponent<Player>();
        char1.GetComponent<Player>().HP = player1_HP;
        char1.GetComponent<Player>().SPD = player1_SPD;
        char1.tag = "Player1";
        char2.AddComponent<Player>();
        char2.GetComponent<Player>().HP = player2_HP;
        char2.GetComponent<Player>().SPD = player2_SPD;
        char2.tag = "Player2";
    }

}