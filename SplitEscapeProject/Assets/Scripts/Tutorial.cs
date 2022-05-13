using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject step1, step2, step3;

    public float nextStepWaitTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        step1.SetActive(true);
        step2.SetActive(false);
        step3.SetActive(false);
        StartCoroutine(ShowStep2());
    }


    IEnumerator ShowStep2()
    {
        yield return new WaitForSeconds(nextStepWaitTime);

        

        step1.SetActive(false);
        step2.SetActive(true);
        StartCoroutine(ShowStep3());
    }

    IEnumerator ShowStep3()
    {
        yield return new WaitForSeconds(nextStepWaitTime);


        step2.SetActive(false);
        step3.SetActive(true);
    }

}
