using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        bool remove = Mathf.Floor(Random.Range(0, 5)) < 3;

        if (remove)
        {
            gameObject.SetActive(false);
            return;
        }

        float whatToLookAt = Mathf.Floor(Random.Range(-1, 2));
        if (whatToLookAt % 2 == 0)
        {
            transform.LookAt(FindObjectOfType<RightCube>().transform);
        }
        else
        {
            transform.LookAt(FindObjectOfType<LeftCube>().transform);

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
    }
}
