using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionHandler : MonoBehaviour
{
    public Button playButton;
    public TextMeshProUGUI totalScoreTMP;
    public TextMeshProUGUI level;
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI lockText;
    public AudioSource valid;
    public AudioSource invalid;
    public GameObject lockIMG;
    public GameObject description;
    int selectedLevel;
    int combinedScore;

    PlayerData playerData;

    Level[] levels =
    {
        new Level("Tutorial", 0),
        new Level("World 1/4", 0),
        new Level("World 2/4", 100),
        new Level("World 3/4", 300),
        new Level("world 4/4", 400)
    };


    private void Start()
    {
        playerData = SaveSystem.Load();

        description.SetActive(false);
        lockIMG.SetActive(false);
        combinedScore = 0;

        foreach(int score in playerData.levelScores){
            combinedScore += score;
        }

        selectedLevel = combinedScore > 0? 1: 0;
        SetLevel();

        

        totalScoreTMP.text = "Total Score: " + combinedScore.ToString();
    }

    public void Next()
    {
        if(selectedLevel < levels.Length - 1)
        {
            selectedLevel += 1;
            valid.Play();
        }
        else
        {
            invalid.Play();
            selectedLevel = 0;
        }

        SetLevel();
    }

    public void Previous()
    {
        if (selectedLevel > 0)
        {
            selectedLevel -= 1;
            valid.Play();
        }
        else
        {
            invalid.Play();
            selectedLevel = levels.Length - 1;
        }

        SetLevel();
    }

    void SetLevel()
    {
        level.text = levels[selectedLevel].name;
        scoreTMP.text = "Best: " + playerData.levelScores[selectedLevel].ToString();
        if(levels[selectedLevel].amount > combinedScore)
        {
            lockIMG.SetActive(true);
            lockText.text = "Total Score < " + levels[selectedLevel].amount.ToString();
            scoreTMP.gameObject.SetActive(false);
            playButton.interactable = false;
        }
        else
        {
            lockIMG.SetActive(false);
            scoreTMP.gameObject.SetActive(true);
            playButton.interactable = true;
        }
    }

    public void Play()
    {
        FindObjectOfType<LevelChanger>().FadeToLevel(selectedLevel + 3);
    }

    public void ShowDescription()
    {
        description.SetActive(true);
    }
    public void HideDescription()
    {
        description.SetActive(false);
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
