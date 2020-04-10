using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_Controller : MonoBehaviour
{
    private MeshRenderer rendere;
    public float maxOutLineWidth;
    public Color OutlineColor;

    private void Start()
    {
        rendere = GetComponent<MeshRenderer>();
    }

    public void ShowOutline()
    {

        foreach (var mat in rendere.materials)
        { 
            mat.SetFloat("_Outline", maxOutLineWidth);
            mat.SetColor("_OutlineColor", OutlineColor);
        }

    }

    public void HideOutline()
    {
        foreach (var mat in rendere.materials)
        {
            mat.SetFloat("_Outline", 0f);
        }
    }
}
