using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{
    public float speed = 10;
    float whatToLookAt;
    // Start is called before the first frame update
    void Start()
    {
        whatToLookAt = Mathf.Floor(Random.Range(-1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        if (whatToLookAt % 2 == 0)
        {
            transform.LookAt(FindObjectOfType<RightCube>().transform);
        }
        else
        {
            transform.LookAt(FindObjectOfType<LeftCube>().transform);

        }

        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
    }
}
