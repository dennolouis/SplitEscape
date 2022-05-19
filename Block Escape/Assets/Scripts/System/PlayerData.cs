using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int[] levelScores = new int[5];
    public int adCount;
    
    public PlayerData(Player player)
    {
        for(int i = 0; i < levelScores.Length; i++)
        {
            levelScores[i] = player.levelScores[i];
        }

        adCount = player.adCount;
    }

    public PlayerData()
    {
        for (int i = 0; i < levelScores.Length; i++)
        {
            levelScores[i] = 0;
        }

        adCount = 0;
    }
}
