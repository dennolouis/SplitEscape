using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResetDiamonds();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LeftCube" || other.gameObject.tag == "RightCube")
        {
            Player.instance.AddToBalance();
        }
    }

    public void ResetDiamonds()
    {
        bool remove =  !(Mathf.Floor(Random.Range(0, 12)) < 2);
        if (remove)
        {
            gameObject.SetActive(false);
            return;
        }
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
        print("heeh");
    }
}
