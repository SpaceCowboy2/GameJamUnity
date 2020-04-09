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
        if (Hallucination_F>=10 && Hallucination_F<= 30)
        {
            var Cam = gameObject.GetComponent<PostProcessVolume >();
            Cam.weight = 0.1f;
            
        }
        else if (Hallucination_F >= 31 && Hallucination_F <= 50)
        {
            var Cam = gameObject.GetComponent<PostProcessVolume>();
            var cam = PP.GetComponent<Volume>();
            var Com = gameObject.GetComponent<Camera>();
            Cam.weight = 0.3f;
            cam.weight = 0.2f;
            Com.fieldOfView = 57;
        }
        else if (Hallucination_F >= 51 && Hallucination_F <= 70)
        {
            var Cam = gameObject.GetComponent<PostProcessVolume>();
            var cam = PP.GetComponent<Volume>();
            var Com = gameObject.GetComponent<Camera>();
            Cam.weight = 0.7f;
            cam.weight = 0.5f;
            Com.fieldOfView = 51;
        }
    }
}
