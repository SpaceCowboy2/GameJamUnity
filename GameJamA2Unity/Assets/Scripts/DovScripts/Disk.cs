using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    public float speed = 0.0f;
    public string[] symbols ;
    public float angle = 0.0f;
    private string symb;
    private bool isFinished = false;
    private int count = 0;

    enum Stages
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
        Stage6,
        Stage7,
    };

    Stages stage = Stages.Stage1;

    void Update()
    {
        //Raycast cam pour visé le click sur l'objet
        //speed = Random.Range(0.4f, 1.0f);
        //transform.Rotate(Vector3.up, speed);
        angle += speed * Time.deltaTime;
        angle = angle % 360;
        Vector3 newEulerAngles = transform.localEulerAngles;
        newEulerAngles.y = angle;
        transform.localEulerAngles = newEulerAngles;
        int value = Mathf.FloorToInt(angle / 360 * 3);


        if (Input.GetButtonDown("Fire1"))
        {
            
            //Debug.Log(symbols[value]);
            count++;
            symb += symbols[value];

        }

        switch (stage)
        {
            case Stages.Stage1:
                if (count == 3)
                {
                    if (symb == "DA" + "MON" + "IEL")
                    {
                        //Debug.Log("Tu as réussi ce stage !");
                        isFinished = true;
                        symb = "";
                        count = 0;
                    }
                    else
                    {
                        //Debug.Log("Tu as faux");
                        symb = "";
                        count = 0;
                    }
                }
                break;

            case Stages.Stage2:
                if (count == 3)
                {
                    if (symb == "AX" + "DA" + "IEL")
                    {
                        //Debug.Log("Tu as réussi ce stage !");
                        isFinished = true;
                        symb = "";
                        count = 0;
                    }
                    else
                    {
                        //Debug.Log("Tu as faux");
                        symb = "";
                        count = 0;
                    }
                }
                break;

            case Stages.Stage3:
                if (count == 4)
                {
                    if (symb == "ROG" + "GU" + "MON" + "IRA")
                    {
                        //Debug.Log("Tu as réussi ce stage !");
                        isFinished = true;
                        symb = "";
                        count = 0;
                    }
                    else
                    {
                        //Debug.Log("Tu as faux");
                        symb = "";
                        count = 0;
                    }
                }
                break;

            case Stages.Stage4:
                if (count == 4)
                {
                    if (symb == "DA" + "LUX" + "ER" + "IA")
                    {
                        //Debug.Log("Tu as réussi ce stage !");
                        isFinished = true;
                        symb = "";
                        count = 0;
                    }
                    else
                    {
                        //Debug.Log("Tu as faux");
                        symb = "";
                        count = 0;
                    }
                }
                break;

            case Stages.Stage5:
                if (count == 4)
                {
                    if (symb == "IN" + "AVA" + "MON" + "IEL")
                    {
                        //Debug.Log("Tu as réussi ce stage !");
                        isFinished = true;
                        symb = "";
                        count = 0;
                    }
                    else
                    {
                        //Debug.Log("Tu as faux");
                        symb = "";
                        count = 0;
                    }
                }
                break;

            case Stages.Stage6:
                if (count == 5)
                {
                    if (symb == "GU" + "LA" + "ROG" + "AX" + "AX"+ "IEL")
                    {
                        //Debug.Log("Tu as réussi ce stage !");
                        isFinished = true;
                        symb = "";
                        count = 0;
                    }
                    else
                    {
                        //Debug.Log("Tu as faux");
                        symb = "";
                        count = 0;
                    }
                }
                break;

            case Stages.Stage7:
                if (count == 4)
                {
                    if (symb == "AVA" + "DA" + "MON" + "IA")
                    {
                        //Debug.Log("Tu as réussi ce stage !");
                        isFinished = true;
                        symb = "";
                        count = 0;
                    }
                    else
                    {
                        //Debug.Log("Tu as faux");
                        symb = "";
                        count = 0;
                    }
                }
                break;
        }
    }

    private void IsFinished()
    {
        if (isFinished == true)
        {
            //Debug.Log("Tu as fini ce niveau !");
            stage++;
        }
    }

}
