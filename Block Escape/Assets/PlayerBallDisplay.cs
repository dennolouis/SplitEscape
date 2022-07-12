using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallDisplay : MonoBehaviour
{
    [SerializeField] GameObject[] playerBalls;

    public void Clear()
    {
        foreach (GameObject playerBall in playerBalls) playerBall.SetActive(false);
    }

    public void ShowPlayerBall(int levelIndex)
    {
        if(levelIndex < 0)
        {
            levelIndex = 0;
        }
        playerBalls[levelIndex].SetActive(true);
    }
}
