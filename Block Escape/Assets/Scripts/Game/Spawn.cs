using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{

    public GameObject[] obj;
    public float speed = 2;
    public float rate = 0.4f;

    float initSpeed, initRate;

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI bestUI;

    int score = 0;
    public int best;


    public bool justShowLast = false;


    private void Awake()
    {
        Load();
        bestUI.text = "Best: " + best.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {

        initSpeed = speed;
        initRate = rate;
        
        Invoke("Init", speed/2);

    }

    public void resetValues()
    {
        speed = initSpeed;
        rate = initRate;
        score = 0;
    }


    void Init()
    {
        //only continue if game is not over
        if (!FindObjectOfType<GameFunctions>().GetGameState())
            Invoke("Init", speed);
        
        CreateObsticle();
        HandleScore();
        HandleSpeed();
    }

    public int GetScore()
    {
        return score;
    }

    void HandleScore()
    {
        score++;
        scoreUI.text = "Score: " + score.ToString();
        if (score > best)
        {
            best = score;
            bestUI.text = "Best: " + best.ToString();
        }
    
    }

    void CreateObsticle()
    {
        GameObject obsticle =  !justShowLast
            ? Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity) 
            : Instantiate(obj[ obj.Length - 1], transform.position, Quaternion.identity);
        
        Destroy(obsticle, speed + 1.5f);
    }

    void HandleSpeed()
    {
        if (speed > 0.8)
            speed -= rate * Time.deltaTime;
    }

    public void test()
    {
        print("it works");
    }


    public void Save()
    {
        SaveSystem.Save(this.best);
    }

    public void Load()
    {
        PlayerData data = SaveSystem.Load();

        best = data.highscore;
    }

    public void AddToScore(int add)
    {
        score += add;
    }
}
