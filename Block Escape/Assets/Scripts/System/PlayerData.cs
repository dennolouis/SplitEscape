using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public List<int> scoresList = new List<int>();
    public List<bool> unlockedList = new List<bool>();
    public int adCount;
    public int selectedLevel = 0;
    public int mode = 0; //easy 0, medium 1, hard 1
    public int balance = 0;
    public string date;

    public PlayerData(Player player)
    {
        scoresList = player.scoresList;
        unlockedList = player.unlockedList;
        adCount = player.adCount;
        selectedLevel = player.selectedLevel;
        mode = player.mode;
        balance = player.balance;
        date = player.date;
    }

    public PlayerData()
    {
        adCount = 0;
    }
}
