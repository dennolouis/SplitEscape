using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{

    public TextMeshProUGUI level;
    public TextMeshProUGUI lockText;
    public GameObject lockIMG;
    int selectedLevel;
    int combinedScore;

    Level[] levels =
    {
        new Level("Tutorial", 0),
        new Level("World 0", 0),
        new Level("World 1", 100),
    };


    private void Start()
    {
        lockIMG.SetActive(false);
        combinedScore = 0;
        selectedLevel = 1;
        SetLevel();
    }

    public void Next()
    {
        if(selectedLevel < levels.Length - 1)
        {
            selectedLevel += 1;
            SetLevel();
        }
    }

    public void Previous()
    {
        if (selectedLevel > 0)
        {
            selectedLevel -= 1;
            SetLevel();
        }
    }

    void SetLevel()
    {
        level.text = levels[selectedLevel].name;
        if(levels[selectedLevel].amount > combinedScore)
        {
            lockIMG.SetActive(true);
            lockText.text = "Combined Score < " + levels[selectedLevel].amount.ToString();
        }
        else
        {
            lockIMG.SetActive(false);
        }
    }
    struct Level
    {
        public string name;
        public int amount;

        public string GetName() { return name; }
        public int GetAmount() { return amount; }

        public Level(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }
    }

}
