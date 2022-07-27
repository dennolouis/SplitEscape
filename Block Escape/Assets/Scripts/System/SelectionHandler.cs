using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionHandler : MonoBehaviour
{
    public Button playButton;
    public TextMeshProUGUI balance;
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

    PlayerBallDisplay playerBallDisplay;

    string[] levels =
    {
        "Tutorial",
        "World 1/6",
        "World 2/6",
        "World 3/6",
        "world 4/6",
        "world 5/6",
        "world 6/6"
    };


    private void Start()
    {


        playerBallDisplay = FindObjectOfType<PlayerBallDisplay>();

        UpdatePlayerBall();

        modes.SetActive(false);
        description.SetActive(false);
        lockIMG.SetActive(false);
        combinedScore = 0;

        SetLevel();



        balance.text = Player.instance.balance.ToString();
    }

    public void Next()
    {
        if(Player.instance.selectedLevel < levels.Length - 1)
        {
            Player.instance.selectedLevel += 1;
            valid.Play();
        }
        else
        {
            invalid.Play();
            Player.instance.selectedLevel = 0;
        }

        SetLevel();
    }

    public void Previous()
    {
        if (Player.instance.selectedLevel > 0)
        {
            Player.instance.selectedLevel -= 1;
            valid.Play();
        }
        else
        {
            invalid.Play();
            Player.instance.selectedLevel = levels.Length - 1;
        }

        SetLevel();
    }

    void SetLevel()
    {
        UpdatePlayerBall();

        level.text = levels[Player.instance.selectedLevel];
        scoreTMP.text = "Best: " + Player.instance.scoresList[Player.instance.selectedLevel].ToString();
        if(!Player.instance.unlockedList[Player.instance.selectedLevel])
        {
            lockIMG.SetActive(true);
            lockText.text = "500";
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
        FindObjectOfType<LevelChanger>().FadeToLevel(Player.instance.selectedLevel + 3);
    }

    public void ShowModes()
    {
        if(Player.instance.selectedLevel == 0)
        {
            Play();
            return;
        }

        medium.interactable = Player.instance.scoresList[Player.instance.selectedLevel] >= 40;
        hard.interactable = Player.instance.scoresList[Player.instance.selectedLevel] >= 80;

        modes.SetActive(true);
    }
    public void HideModes()
    {
        modes.SetActive(false);
    }

    public void SetMode(int mode)
    {
        Player.instance.mode = mode;
        Play();
    }

    public void ShowDescription()
    {
        description.SetActive(true);
    }
    public void HideDescription()
    {
        description.SetActive(false);
    }

    public void BuyLevel()
    {
        if(Player.instance.balance < 500)
        {
            invalid.Play();
            return;
        }
        Player.instance.balance -= 500;
        balance.text = Player.instance.balance.ToString();
        Player.instance.GetComponent<AudioSource>().Play();
        Player.instance.unlockedList[Player.instance.selectedLevel] = true;
        SetLevel();
    }

    void Save()
    {
        SaveSystem.Save(Player.instance);
    }


    void UpdatePlayerBall()
    {
        playerBallDisplay.Clear();
        playerBallDisplay.ShowPlayerBall(Player.instance.selectedLevel - 1);
    }

}
