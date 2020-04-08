using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public float Hallucination_F;
    public Image Hallucination_Bar;
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
    }
}
