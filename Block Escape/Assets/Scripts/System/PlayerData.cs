using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int[] levelScores = new int[5];
    public int adCount;
    //public int selectedLevel;
    
    public PlayerData(Player player)
    {
        for(int i = 0; i < levelScores.Length; i++)
        {
            levelScores[i] = player.levelScores[i];
        }

        adCount = player.adCount;
        //selectedLevel = player.selectedLevel;
    }

    public PlayerData()
    {
        for (int i = 0; i < levelScores.Length; i++)
        {
            levelScores[i] = 0;
        }

        adCount = 0;
        //selectedLevel = 0;
    }

    public void EnsureValidData()
    {
        if(levelScores == null)
        {
            for (int i = 0; i < levelScores.Length; i++)
            {
                levelScores[i] = 0;
            }
        }
    }
}
