using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightCube : MonoBehaviour
{
    public float speed = 10;

    public float maxLeft = -6.75f;
    
    bool touchingRight = false;
    bool touchingLeft = false;
    public bool immune = false;
    
    
    bool left = false, right = false;

    GameFunctions gameFunctions;

    private void Start()
    {
        gameFunctions = FindObjectOfType<GameFunctions>();
    }

    // Update is called once per frame
    void Update()
    {

        //move right
        if (right)
        {
            if (!touchingRight && transform.position.x < 27)
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            }
        }
        else if (left)
        {
            if (!touchingLeft)
            {
                if(transform.position.x < maxLeft)
                {
                    transform.Translate(new Vector3(0, 0, 0));
                }
                else
                {
                    transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
                }
            }
        }

        //return to center from right
        if (!right && transform.position.x > 0)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }

        //return to center from left
        if(!left && transform.position.x < 0.75){
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Left":
                touchingLeft = true;
                break;
            case "Right":
                touchingRight = true;
                break;
            case "Tutorial":
                gameFunctions.ReloadScene();
                break;
            default:
                if (!immune)
                {
                    gameFunctions.PlayerGotHit();
                }
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        touchingLeft = false;
        touchingRight = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        gameFunctions.LoadGameScreen();
    }

    void MakeVulnerable ()
    {
        immune = false;
    }

    public void PressLetft()
    {
        left = true;
    }

    public void ReleaseLeft()
    {
        left = false;
    }

    public void PressRight()
    {
        right = true;
    }

    public void ReleaseRight()
    {
        right = false;
    }


    public void SetLeft(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            left = true;
        }
        if (value.canceled)
        {
            left = false;
        }
    }
    public void SetRight(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            right = true;
        }
        if (value.canceled)
        {
            right = false;
        }
    }



    public void Resume()
    {

        immune = true;
        Time.timeScale = 1;
        //this is what makes you immune for one second
        Invoke("MakeVulnerable", 1);
    }
}


