using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraEffect : MonoBehaviour{
    public Material material;

    public void OnRenderImage(RenderTexture source, RenderTexture destination){
        Graphics.Blit(source, destination, material);
    }
}
