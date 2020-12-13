using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public float scrollSpeed;
    Material backgroundMaterial;
    public bool scroll = true;

    private void Awake()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }
    private void FixedUpdate()
    {
        if (scroll)
        {
            Vector2 offset = new Vector2(scrollSpeed * Time.time, 0);
            backgroundMaterial.mainTextureOffset = offset;
        }
    }
}
