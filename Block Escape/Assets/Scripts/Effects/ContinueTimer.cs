using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContinueTimer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    int time = 5;

    GameFunctions gameFunctions;
    bool continued = false;

    // Start is called before the first frame update
    void Start()
    {
        gameFunctions = FindObjectOfType<GameFunctions>();
    }

    public void Show()
    {
        timer.text = time.ToString();
        Invoker.InvokeDelayed(Decrement, 1);
    }

    public void Decrement()
    {
        if (continued)
        {
            return;
        }

        if(time <= 0)
        {
            gameFunctions.ShowGameOverScreen();
            return;
        }
        time--;
        timer.text = time.ToString();
        Invoker.InvokeDelayed(Decrement, 1);
    }


    public void Continue()
    {
        continued = true;
        time = 5;
    }
}
