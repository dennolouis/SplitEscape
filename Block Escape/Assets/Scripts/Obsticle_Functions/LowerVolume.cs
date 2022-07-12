using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerVolume : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource)
            audioSource.volume -= 0.5f * Time.deltaTime;
    }
}
