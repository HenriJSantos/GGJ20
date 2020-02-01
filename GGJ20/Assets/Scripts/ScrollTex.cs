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

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;

        var croppedTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        var pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                (int)sprite.textureRect.y,
                                                (int)sprite.textureRect.width,
                                                (int)sprite.textureRect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        material.mainTexture = croppedTexture;
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
