using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGetSize : MonoBehaviour
{
    SpriteRenderer spr;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.localScale.x * spr.size.x + " " + transform.localScale.z * spr.size.y);
    }
    
}
