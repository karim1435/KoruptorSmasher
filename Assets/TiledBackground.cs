﻿using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour {

    public int textureSize = 32;
    private float scale = 1f;
    void Start()
    {
        var newWidth =Mathf.Ceil(Screen.width / (textureSize *PixelPerfectCamera.scale));
        var newHeight= Mathf.Ceil(Screen.height / (textureSize * PixelPerfectCamera.scale));

        transform.localScale = new Vector3(newWidth * textureSize, newHeight * textureSize, 1);
    }
}