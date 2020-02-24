using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour{

    public Material material;
    public SpriteRenderer background;
    public Sprite b1;
    public Sprite b2;

    bool started = false;
    float minSize = 0.001f;
    float maxSize = 0.15f;
    float step = 0.002f;
    string pixelSize = "_PixelSize";

    void Start(){
        resetTransition();
    }

    void Update(){
        if(Input.GetKeyUp(KeyCode.Space)){
            if(!started){
                StartCoroutine(transitionCoroutine());
            }
        }
    }

    IEnumerator transitionCoroutine(){
        started = true;

        float size = minSize;
        while(size < maxSize){
            size += step;
            material.SetFloat(pixelSize, size);
            yield return null;
        }

        if(background.sprite == b1){
            background.sprite = b2;
        }else{
             background.sprite = b1;
        }

        yield return new WaitForSeconds(0.02f);

        while(size > minSize){
            size -= step;
            material.SetFloat(pixelSize, size);
            yield return null;
        }

        started = false;
    }

    void resetTransition(){
        material.SetFloat(pixelSize, minSize);
        background.sprite = b1;
    }
}
