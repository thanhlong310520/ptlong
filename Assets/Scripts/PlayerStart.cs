using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public static int money;
    public int _money = 400;

    public static int Lives;
    public int startLives = 10;
    void Start()
    {
        money = _money;
        Lives = startLives;
    }

}
