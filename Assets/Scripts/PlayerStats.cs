using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 150;
    public Text PlayerMoney;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }

    void Update()
    {
        PlayerMoney.text = "$" + Money.ToString();
    }

}
