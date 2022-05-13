using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class TouchControl : MonoBehaviour
{

    public LeftCube leftCube;
    public RightCube rightCube;

    AudioSource audioSource;

    int activeFingers = 0;

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Touch.activeFingers.Count == 2)
        {
            leftCube.PressLetft();
            rightCube.PressRight();
        }
        else if (Touch.activeFingers.Count == 1)
        {
            if ((Touch.activeTouches[0].screenPosition.y > Screen.height * 0.85))
            {
                return;
            }
            if(Touch.activeTouches[0].screenPosition.x > Screen.width / 2)
            {
                rightCube.PressRight();
                leftCube.PressRight();
                rightCube.ReleaseLeft();
                leftCube.ReleaseLeft();
            }
            else
            {
                rightCube.PressLetft();
                leftCube.PressLetft();
                rightCube.ReleaseRight();
                leftCube.ReleaseRight();
            }
            

        }
        else
        {
            leftCube.ReleaseLeft();
            leftCube.ReleaseRight();
            rightCube.ReleaseRight();
            rightCube.ReleaseLeft();
        }


    }

    public void PlaySound()
    {
        audioSource.Play();
    }

}
