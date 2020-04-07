using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_Controller : MonoBehaviour
{
    private MeshRenderer renderer;
    public float maxOutLineWidth;
    public Color OutlineColor;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void ShowOutline()
    {

        foreach (var mat in renderer.materials)
        { 
            mat.SetFloat("_Outline", maxOutLineWidth);
            mat.SetColor("_OutlineColor", OutlineColor);
        }

    }

    public void HideOutline()
    {
        foreach (var mat in renderer.materials)
        {
            mat.SetFloat("_Outline", 0f);
        }
    }
}
