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
    public GameObject modes;
    public Button easy;
    public Button medium;
    public Button hard;
    int selectedLevel;
    int combinedScore;

    PlayerData playerData;
    Player player;

    Level[] levels =
    {
        new Level("Tutorial", 0),
        new Level("World 1/4", 0),
        new Level("World 2/4", 0),
        new Level("World 3/4", 0),
        new Level("world 4/4", 0)
    };


    private void Start()
    {

        Load();
        modes.SetActive(false);
        description.SetActive(false);
        lockIMG.SetActive(false);
        combinedScore = 0;

        foreach(int score in playerData.levelScores){
            combinedScore += score;
        }

        //selectedLevel = player.selectedLevel;//combinedScore > 0? 1: 0;
        SetLevel();

        

        totalScoreTMP.text = "Total Score: " + combinedScore.ToString();
    }

    public void Next()
    {
        if(player.selectedLevel < levels.Length - 1)
        {
            player.selectedLevel += 1;
            valid.Play();
        }
        else
        {
            invalid.Play();
            player.selectedLevel = 0;
        }

        SetLevel();
    }

    public void Previous()
    {
        if (player.selectedLevel > 0)
        {
            player.selectedLevel -= 1;
            valid.Play();
        }
        else
        {
            invalid.Play();
            player.selectedLevel = levels.Length - 1;
        }

        SetLevel();
    }

    void SetLevel()
    {
        level.text = levels[player.selectedLevel].name;
        scoreTMP.text = "Best: " + playerData.levelScores[player.selectedLevel].ToString();
        if(levels[player.selectedLevel].amount > combinedScore)
        {
            lockIMG.SetActive(true);
            lockText.text = "Total Score < " + levels[player.selectedLevel].amount.ToString();
            scoreTMP.gameObject.SetActive(false);
            playButton.interactable = false;
        }
        else
        {
            lockIMG.SetActive(false);
            scoreTMP.gameObject.SetActive(true);
            playButton.interactable = true;
        }
        HideModes();
    }

    public void Play()
    {
        Save();
        FindObjectOfType<LevelChanger>().FadeToLevel(player.selectedLevel + 3);
    }

    public void ShowModes()
    {
        medium.interactable = playerData.levelScores[player.selectedLevel] >= 40;
        hard.interactable = playerData.levelScores[player.selectedLevel] >= 80;

        modes.SetActive(true);
    }
    public void HideModes()
    {
        modes.SetActive(false);
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

    void Save()
    {
        SaveSystem.Save(player);
    }

    void Load()
    {   
        player = FindObjectOfType<Player>();
        playerData = SaveSystem.Load();

        for (int i = 0; i < player.levelScores.Length; i++)
        {
            player.levelScores[i] = playerData.levelScores[i];
            player.scoresList.Add(playerData.levelScores[i]); //comment this out in future update
        }

        //player.scoresList = data.scoresList;   uncomment this in future update
        player.adCount = playerData.adCount;
        player.selectedLevel = playerData.selectedLevel;

    }

}
