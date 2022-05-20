using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanldeMute : MonoBehaviour
{
    public GameObject mute;
    public GameObject unMute;
    public bool muteSate;

    private void Start()
    {
        HandleMute();
    }

    public void Mute()
    {
        AudioListener.volume = 0;
        HandleMute();
    }

    public void UnMute()
    {
        AudioListener.volume = 1;
        HandleMute();
    }

    void HandleMute()
    {
        if (AudioListener.volume == 0)
        {
            mute.SetActive(false);
            unMute.SetActive(true);
            muteSate = true;
        }
        else
        {
            unMute.SetActive(false);
            mute.SetActive(true);
            muteSate = false;
        }
        AudioListener.pause = muteSate;
    }
}
