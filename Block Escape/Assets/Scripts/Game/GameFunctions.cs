using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameFunctions : MonoBehaviour
{

    static public bool justGothit = false;
    static public bool gameOver = false;

    public GameObject continueButton;
    public GameObject gameOverScreen;
    public GameObject pauseButton;

    public GameObject adErrorMessage;

    public bool isMuted = false;

    public bool canContinue = true;

    InterstitialAd intersitialAd;
    RewardedAds rewardedAd;
    BannerAd banner;

    bool adsLoaded = false;
    HanldeMute volume;


    public Spawn spawn;
    public Scroll scroll;
    public ContinueTimer continueTimer;

    //public Player player;
    
    void Awake()
    {
        Time.timeScale = 1;
        justGothit = false;
        canContinue = true;
        gameOver = false;
        continueButton.SetActive(false);
        gameOverScreen.SetActive(false);
        adErrorMessage.SetActive(false);
    }

    private void Start()
    {
        intersitialAd = FindObjectOfType<InterstitialAd>();
        rewardedAd = FindObjectOfType<RewardedAds>();
        banner = FindObjectOfType<BannerAd>();
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        banner.ShowBannerAd();

        volume = FindObjectOfType<HanldeMute>();
    }

    public void RestScene()
    {
        Time.timeScale = 1;
        justGothit = false;
        canContinue = true;
        gameOver = false;
        continueButton.SetActive(false);
        gameOverScreen.SetActive(false);
        adErrorMessage.SetActive(false);

        spawn.resetValues();
        scroll.resetValues();
    }

    public void PlayerGotHit()
    {
        adsLoaded = FindObjectOfType<RewardedAds>()._showAdButton.interactable;
        pauseButton.SetActive(false);
        
        
        //for when left and right cube got hit at the same time
        if (justGothit)
            return;

        

        FindObjectOfType<Spawn>().Save();
        GameObject.FindGameObjectWithTag("HitSound").GetComponent<AudioSource>().Play();
        Time.timeScale = 0;

        justGothit = true;

       

        if (canContinue && adsLoaded)
        {
            continueButton.SetActive(true);
            canContinue = false;
            continueTimer.Show();
            banner.ShowBannerAd();
        }
        else
        {
            ShowGameOverScreen();
        }
    }

    public void ShowGameOverScreen()
    {
        Invoker.InvokeDelayed(MaybeShowAd, 0.3f);
        continueButton.SetActive(false);
        gameOverScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

    void MaybeShowAd()
    {
        
        if (Player.instance.adCount > 5 && adsLoaded)
        {
            gameOver = true;
            AudioListener.pause = true;
            banner.HideBannerAd();
            intersitialAd.ShowAd();
        }
    }

    public bool GetGameState()
    {
        return gameOver;
    }

    public void Continue(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            ShowRewardedAd();
        }
    }

    public void ShowRewardedAd()
    {
        AudioListener.pause = true;
        banner.HideBannerAd();
        rewardedAd.ShowAd();
        justGothit = false;
        continueButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void OnRewardedComplete()
    {
        Time.timeScale = 1;
        
        AudioListener.pause = volume.muteSate;
        FindObjectOfType<RightCube>().Resume();
        banner.ShowBannerAd();

        //change mute state then call mute function to get proper state
        isMuted = !isMuted;
        HandleMute();
    }

    public void PlayAgain(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        FindObjectOfType<LevelChanger>().FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }


    
    public void LoadGameScreen()
    {
        FindObjectOfType<LevelChanger>().FadeToLevel(4);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void PauseGame(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            pauseButton.gameObject.GetComponent<PauseButton>().Pause();
        }
    }

    
    public void ResumeGame(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            pauseButton.gameObject.GetComponent<PauseButton>().Resume();
        }
    }

    public void ToggleMute(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            HandleMute();
        }
    }

    public void HandleMute()
    {
        if (isMuted)
        {
            AudioListener.volume = volume.muteSate? 0: 1;
        }
        else
        {
            AudioListener.volume = 0;
        }

        isMuted = AudioListener.volume == 0;
    }


    public void ShowAdError(string message)
    {
        adErrorMessage.SetActive(true);
        adErrorMessage.GetComponent<Text>().text = message;
    }
}
