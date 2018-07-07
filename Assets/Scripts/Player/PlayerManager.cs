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

    public Player1 player1;

    // プレイヤー１のステータス
    public int player1_HP;
    public float player1_SPD;
    public float player1_shot_SPD;
    public float player1_shot_interval;
    public float player1_NS_ATK;
    public float player1_SS_ATK;

    private void OnValidate()
    {
        player1_HP = Mathf.Max (1, player1_HP);

        // キャラごとのデフォルトステータス
        switch(player1)
        {
            case Player1.Veronica:
                player1_HP = 100;
                player1_SPD = 3;
                player1_NS_ATK = 10;
                player1_SS_ATK = 30;
                break;

            case Player1.Anoma:
                player1_HP = 200;
                player1_SPD = 2;
                player1_NS_ATK = 5;
                player1_SS_ATK = 20;
                break;
        }
    }

    private void awake()
    {
        gameObject.GetComponent<Player>().HP = player1_HP;
        gameObject.GetComponent<Player>().SPD = player1_SPD;
        gameObject.GetComponent<Player>().shot_SPD = player1_shot_SPD;
        gameObject.GetComponent<Player>().shot_interval = player1_shot_SPD;
        gameObject.GetComponent<Player>().NS_ATK = player1_NS_ATK;
        gameObject.GetComponent<Player>().SS_ATK = player1_SS_ATK;
    }

    private void Start()
    {
        string P1name = player1.ToString();
        // キャラの生成
        GameObject P1 = Instantiate((GameObject)Resources.Load("Models/" + P1name)) as GameObject;
        P1.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        P1.transform.position = new Vector3(0, 0, -2.25f);
        P1.transform.rotation = Quaternion.Euler(90, 0, 0);

    }
}