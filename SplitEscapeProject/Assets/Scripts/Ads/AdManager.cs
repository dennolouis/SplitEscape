using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{

#if UNITY_IOS
    string gameId = "4664670";
#elif UNITY_ANDROID
        string gameId = "4664671";
#endif

    bool testMode = true;

    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }
   


    void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                print("watched video in full");
                break;
            case ShowResult.Skipped:
                print("skipped the ad");
                break;
            case ShowResult.Failed:
                print("failed to launch ad. internet?");
                break;
        }
    }
}
