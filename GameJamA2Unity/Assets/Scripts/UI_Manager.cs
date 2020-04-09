using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private int demence = 0;
    private Camera cam;
    
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        /*Hallucination_Bar.fillAmount = Hallucination_F / 100;
        
        if (Hallucination_F>100)
        {
            Hallucination_F = 100;
        }
        else if (Hallucination_F<0)
        {
            Hallucination_F = 0;
        }
        
        var Cam = gameObject.GetComponent<PostProcessVolume>();
        var cam = PP.GetComponent<Volume>();
        Com.fieldOfView = Hallucination_F/((Com.fieldOfView * 100) / 60);
        Debug.Log(Com.fieldOfView);
        Cam.weight = Hallucination_F/200;
            cam.weight = Hallucination_F / 200;*/

        if(demence > 0 && demence <= 10)
        {
            // Rien pour l'instant
        }
        else if (demence > 10 && demence <= 30)
        {
            // Intégrer le tangage faible de Dov
            // Blurr random un peu flou
            
            Camera.main.fieldOfView -= 2;
        }
        else if (demence > 30 && demence <= 50)
        {
            Camera.main.fieldOfView -= 2;
        }
        else if (demence > 50 && demence <= 70)
        {
            Camera.main.fieldOfView -= 2;
        }
        else if (demence > 70 && demence <= 90)
        {
            Camera.main.fieldOfView -= 2;
        }
        
        else if (demence > 90 && demence < 100)
        {
            Camera.main.fieldOfView -= 2;
        }
        else if (demence >= 100)
        {
            // Défaite
        }
    }

   
}
