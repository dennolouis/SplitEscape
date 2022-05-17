using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public Material[] colors;
    AudioSource audioSource;

    void Awake()
    {
        int i = Random.Range(0, colors.Length);
        gameObject.GetComponent<MeshRenderer>().material = colors[i];
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.Play();
        FindObjectOfType<Spawn>().AddToScore(5);
    }
}
