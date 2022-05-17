using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{

    public Material[] colors;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Right" || other.gameObject.tag == "left")
        {
            int i = Random.Range(0, colors.Length);
            FindObjectOfType<LeftCube>().GetComponent<MeshRenderer>().material = colors[i];
            FindObjectOfType<RightCube>().GetComponent<MeshRenderer>().material = colors[i];
            audioSource.Play();
        }
    }
}
    