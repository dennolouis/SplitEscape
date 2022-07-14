using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    //public int[] levelScores = new int[5];
    public List<int> scoresList = new List<int>();
    public List<bool> unlockedList = new List<bool>();
    public int adCount = 0;
    public int selectedLevel = 0;
    public int mode = 0; //easy 0, medium 1, hard 1
    public int balance = 0;

    private void Awake()
    {
        TestSingleton();
        Load();
        EnsureListLength(6);
    }

    void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }

        instance = this;
    }

    void Load()
    {
        PlayerData playerData = SaveSystem.Load();

        instance.scoresList = playerData.scoresList;
        instance.adCount = playerData.adCount;
        instance.selectedLevel = playerData.selectedLevel;
        instance.mode = playerData.mode;
    }

    void EnsureListLength(int numberOfLevels)
    {
        while (scoresList.Count < numberOfLevels)
        {
            instance.scoresList.Add(0);
        }

        while (unlockedList.Count < numberOfLevels)
        {
            instance.unlockedList.Add(false);
        }

        for (int i = 0; i < 5; i++)
        {
            instance.unlockedList[i] = true;
        }
    }

}
