using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{

    public int speed = 10;
    float direction;

    AudioSource audioSource;

    private void Start()
    {
        direction = Mathf.Floor(Random.Range(-1, 2));
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(direction, 0, 0) * speed * Time.deltaTime);
        audioSource.volume -= 0.06f * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        speed = -speed;
    }
}
