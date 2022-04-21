using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        FindObjectOfType<RightCube>().immune = true;
        Time.timeScale = 1;
        FindObjectOfType<LevelChanger>().FadeToLevel(0);
    }
}
