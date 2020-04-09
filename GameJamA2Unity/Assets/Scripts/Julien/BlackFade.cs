using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour   
{

    public Image screen;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeToBlack()
    {
        screen.color = Color.black;
        screen.canvasRenderer.SetAlpha(0.0f);
        screen.CrossFadeAlpha(1.0f, time, false);
    }

    void FadeFromBlack()
    {
        screen.color = Color.black;
        screen.canvasRenderer.SetAlpha(1.0f);
        screen.CrossFadeAlpha(0.0f, time, false);
    }

    void FadeToWhite()
    {
        screen.color = Color.white;
        screen.canvasRenderer.SetAlpha(0.0f);
        screen.CrossFadeAlpha(1.0f, time, false);
    }


}
