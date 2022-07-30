using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDropScroll : MonoBehaviour
{
    [SerializeField] bool accelerate = false;

    public float speed = 100;

    float y;

    Material backdrop;
    // Start is called before the first frame update
    void Start()
    {
        y = GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    // Update is called once per frame
    void Update()
    {
        //backdrop.SetTextureOffset("_MainTex", new Vector2(0, -1) * speed * Time.deltaTime);
        y += speed * Time.deltaTime;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, y));

        speed = accelerate ? speed - 0.005f * Time.deltaTime : speed;
    }
}
