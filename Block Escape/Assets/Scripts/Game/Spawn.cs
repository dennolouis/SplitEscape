using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{

    [SerializeField] GameObject diamonds;
    Diamond[] diamondChildren;

    public GameObject[] obj;
    public float speed = 2;
    public float rate = 0.4f;

    float initSpeed, initRate;

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI bestUI;

    int score = 0;
    public int best;


    public bool justShowLast = false;

    int levelIndex;

    public int numObstacles;


    private void Awake()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex - 3;

        switch (Player.instance.mode)
        {
            case 0:
                numObstacles = obj.Length / 3;
                break;
            case 1:
                numObstacles = (2 * obj.Length) / 3;
                break;
            default:
                numObstacles = obj.Length;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        initSpeed = speed;
        initRate = rate;

        Player.instance.selectedLevel = levelIndex;
        Player.instance.adCount += 1;
        if (Player.instance.adCount > 6) Player.instance.adCount = 0;

        best = Player.instance.scoresList[Player.instance.selectedLevel];
        bestUI.text = "Best: " + best.ToString();

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
        //if (!FindObjectOfType<GameFunctions>().GetGameState())
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
            Player.instance.scoresList[levelIndex] = score;
            bestUI.text = "Best: " + best.ToString();
        }
    
    }

    void CreateObsticle()
    {
        GameObject obsticle =  !justShowLast
            ? Instantiate(obj[Random.Range(0, numObstacles)], transform.position, Quaternion.identity) 
            : Instantiate(obj[ obj.Length - 1], transform.position, Quaternion.identity);
        
        Destroy(obsticle, speed + 1.5f);

        GameObject diamond = Instantiate(diamonds, transform.position, Quaternion.identity);
        Destroy(diamond, speed + 1.5f);
    }

    void HandleSpeed()
    {
        if (speed > 0.8)
            speed -= rate * Time.deltaTime;
    }

    public void Save()
    {
        SaveSystem.Save(Player.instance);

        if(Player.instance.mode == 2)
        {
            CloudOnceServices.instance.SubmitScoreToLeaderBoard(score, levelIndex);
        }
    }

    public void AddToScore(int add)
    {
        score += add;
    }
}
