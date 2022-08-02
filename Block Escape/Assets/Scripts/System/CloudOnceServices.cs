using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices instance;

    private void Awake()
    {
        TestSingleton();
    }

    void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreToLeaderBoard(int score, int level)
    {
        switch (level)
        {
            case 1:
                Leaderboards.world1.SubmitScore(score);
                break;
            case 2:
                Leaderboards.world2.SubmitScore(score);
                break;
            case 3:
                Leaderboards.world3.SubmitScore(score);
                break;
            case 4:
                Leaderboards.world4.SubmitScore(score);
                break;
            case 5:
                Leaderboards.world5.SubmitScore(score);
                break;
            case 6:
                Leaderboards.world6.SubmitScore(score);
                break;
            case 7:
                Leaderboards.world7.SubmitScore(score);
                break;
        }

    }
}
