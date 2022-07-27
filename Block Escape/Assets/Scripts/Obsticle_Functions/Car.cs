using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    int lane;
    int speed = 10;
    bool isChanginglane;
    bool moveLeft;
    bool canChange = false;

    // Start is called before the first frame update
    void Start()
    {
        isChanginglane = Random.Range(0, 5) < 3;
        moveLeft = Random.Range(0, 5) < 3;

        lane = Random.Range(-1, 2);
        transform.Translate(0, 0, lane * 20);

        Invoke("SwitchLane", 0.5f);
    }

    private void Update()
    {
        if (!isChanginglane) return;
        if (!canChange) return;

        switch (lane)
        {
            case -1:
                transform.Rotate(new Vector3(0, -0.5f, 0) * speed * Time.deltaTime);
                transform.Translate(new Vector3(2f, 0, 1) * speed * Time.deltaTime);
                break;
            case 0:
                transform.Rotate(new Vector3(0, moveLeft? -0.5f: 0.5f, 0) * speed * Time.deltaTime);
                transform.Translate(new Vector3(2f, 0, moveLeft ? 1 : -1) * speed * Time.deltaTime);
                break;
            case 1:
                transform.Rotate(new Vector3(0, 0.5f, 0) * speed * Time.deltaTime);
                transform.Translate(new Vector3(2f, 0, -1) * speed * Time.deltaTime);
                break;
        }
    }


    void SwitchLane()
    {
        canChange = true;
        AudioSource horn = GetComponent<AudioSource>();
        if (isChanginglane && horn)
        {
            horn.Play();
        }
    }
}
