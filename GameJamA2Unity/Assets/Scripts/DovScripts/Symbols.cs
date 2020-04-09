using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Symbols : MonoBehaviour
{
    public string symbol;
    public bool isValid = false;
    public Color colorValid = Color.green;
    public Color colorInValid = Color.red;

    void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.name == symbol)
            {
                child.gameObject.SetActive(true);
                if (isValid)
                {
                    child.GetComponent<Image>().color = colorValid;
                }
                else
                {
                    child.GetComponent<Image>().color = colorInValid;
                }
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
