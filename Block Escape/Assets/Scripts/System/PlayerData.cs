using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int[] levelScores = new int[5];
    public List<int> scoresList = new List<int>();
    public int adCount;
    public int selectedLevel = 0;
    public int mode = 0; //easy 0, medium 1, hard 1

    public PlayerData(Player player)
    {
        for (int i = 0; i < levelScores.Length; i++)
        {
            levelScores[i] = player.levelScores[i];
            scoresList.Add(player.levelScores[i]);
        }

        adCount = player.adCount;
        selectedLevel = player.selectedLevel;
        mode = player.mode;
    }

    public PlayerData()
    {
        for (int i = 0; i < levelScores.Length; i++)
        {
            levelScores[i] = 0;
        }

        adCount = 0;
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
