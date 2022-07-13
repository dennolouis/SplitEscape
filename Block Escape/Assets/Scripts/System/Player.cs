using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int[] levelScores = new int[5];
    public List<int> scoresList = new List<int>();
    public List<bool> unlockedList = new List<bool>();
    public int adCount = 0;
    public int selectedLevel = 0;
    public int mode = 0; //easy 0, medium 1, hard 1
    public int balance = 0;

    private void Start()
    {
        int numberOfLevels = 6;

        while(scoresList.Count < numberOfLevels)
        {
            scoresList.Add(0);
        }

        while(unlockedList.Count < numberOfLevels)
        {
            unlockedList.Add(false);
        }

        for(int i = 0; i < 5; i++)
        {
            unlockedList[i] = true;
        }
    }

}
