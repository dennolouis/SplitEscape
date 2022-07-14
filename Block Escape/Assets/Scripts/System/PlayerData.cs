using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    //public int[] levelScores = new int[5];
    public List<int> scoresList = new List<int>();
    public List<bool> unlockedList = new List<bool>();
    public int adCount;
    public int selectedLevel = 0;
    public int mode = 0; //easy 0, medium 1, hard 1
    public int balance = 0;

    public PlayerData(Player player)
    {
        adCount = player.adCount;
        selectedLevel = player.selectedLevel;
        mode = player.mode;
    }

    public PlayerData()
    {
        adCount = 0;
    }
}
