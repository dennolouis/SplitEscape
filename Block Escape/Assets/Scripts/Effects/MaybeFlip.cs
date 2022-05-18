using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaybeFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, Random.Range(0, 5) < 3 ? 0 : 180, 0);
    }
}
