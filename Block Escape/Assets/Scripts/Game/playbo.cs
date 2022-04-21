using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playbo : MonoBehaviour
{

    AudioSource auidoSource;
    float volLev = 0;

    private void Start()
    {
        auidoSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        auidoSource.volume -= volLev * Time.deltaTime;
    }

    void lowerVolume()
    {
        volLev = 0.2f;
    }
    public void playbutton(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            PlayGame();
        }

    }

    public void PlayGame()
    {
        auidoSource.Play();
        lowerVolume();
    }
        
}
