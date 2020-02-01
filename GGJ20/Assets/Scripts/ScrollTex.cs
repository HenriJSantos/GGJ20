using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTex : MonoBehaviour
{
    float scrollSpeed = 0.5f;
    private Material material;

    public bool scroolX, scroolY;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = 0, offsetY = 0;
        
        if(scroolX)
            offsetX = Time.time * scrollSpeed;

        if (scroolY)
            offsetY = Time.time * scrollSpeed;

        material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
