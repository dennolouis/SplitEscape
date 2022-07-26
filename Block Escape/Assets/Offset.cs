using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Random.Range(-15, 15), 0, 0);
    }
}
