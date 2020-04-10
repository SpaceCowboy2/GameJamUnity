using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    public float Hallucination_F;
    public Image Hallucination_Bar;
    public GameObject PP;
    
    void Start()
    {
        
    }
public void Damage()
    {
        Hallucination_F--;
    }
    void Update()
    {
        Hallucination_Bar.fillAmount = Hallucination_F / 100;
        if (Hallucination_F>100)
        {
            Hallucination_F = 100;
        }
        else if (Hallucination_F<0)
        {
            Hallucination_F = 0;
        }
        var Com = gameObject.GetComponent<Camera>();
        var Cam = gameObject.GetComponent<PostProcessVolume>();
        var cam = PP.GetComponent<Volume>();
        Com.fieldOfView = Hallucination_F/((Com.fieldOfView * 100) / 60);
            Cam.weight = Hallucination_F/200;
            cam.weight = Hallucination_F / 200;

    }
}
