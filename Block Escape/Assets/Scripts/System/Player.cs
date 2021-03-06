using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public List<int> scoresList = new List<int>();
    public List<bool> unlockedList = new List<bool>();
    public int adCount = 0;
    public int selectedLevel = 0;
    public int mode = 0; //easy 0, medium 1, hard 2
    public int balance = 0;

    [SerializeField]
    int numberOfLevels = 11;


    public string date = "";

    private void Awake()
    {
        TestSingleton();
        Load();
        EnsureListLength();
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
        instance.unlockedList = playerData.unlockedList;
        instance.adCount = playerData.adCount;
        instance.selectedLevel = playerData.selectedLevel;
        instance.mode = playerData.mode;
        instance.balance = playerData.balance;
        instance.date = playerData.date;
    }

    void EnsureListLength()
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

    public void AddToBalance()
    {
        balance++;
        GetComponent<AudioSource>().Play();
    }
}
