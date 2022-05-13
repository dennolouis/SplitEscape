using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public int speed = 10;
    public bool x = false;
    public bool y = true;
    public bool z = false;

    float direction;

    private void Start()
    {
        direction = Random.Range(0, 100) <= 50 ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x ? direction: 0, y? direction: 0, z ? direction : 0) * speed * Time.deltaTime);
    }
}
