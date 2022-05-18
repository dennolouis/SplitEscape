using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    public float speed = 60;
    public float rate = 0.4f;

    float initSpeed, initRate;

    GameFunctions gameFunctions;
    void Start()
    {
        initSpeed = speed;
        initRate = rate;
        gameFunctions = FindObjectOfType<GameFunctions>();
    }

    public void resetValues()
    {
        speed = initSpeed;
        rate = initRate;
        transform.Translate(0, -1000, 0);
    }



    void Update()
    {
        //only do this is game is not over
        if (gameFunctions)
        {
            if (!gameFunctions.GetGameState())
                transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
        if(transform.position.y > 9999999999999999999)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        speed += rate * Time.deltaTime;
    }
}
