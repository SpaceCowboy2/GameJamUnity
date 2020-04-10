using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    //parametre de roue
    [Header("paramètre de roue")]
    public float speed = 0.0f;
    public float angle = 0.0f;
    public float angleoffset = 0.0f;
    public Camera cam;
    public float dist;
    public Gameplay gameplay;

    [Header("Saisie des symboles")]
    public string[] symbols;

    //Etat de saisie
    [Header("Saisie des UI des symboles")]
    public Symbols[] UISymbols;
    private string symb;
    private int count = 0;

    //Etat de résultat
    [Header("Attente pendant résultat")]
    public float resultDuration = 3.0f;
    private float resultTimer = 0.0f;

    [Header("Noms des démons")]
    public string[] validSymbolsStage1;
    public string[] validSymbolsStage2;
    public string[] validSymbolsStage3;
    public string[] validSymbolsStage4;
    public string[] validSymbolsStage5;
    public string[] validSymbolsStage6;
    public string[] validSymbolsStage7;

    [Header("CheatMode")]
    public bool cheatMode = false;


    enum Stages
    {
        Stage1 = 0,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
        Stage6,
        Stage7,
    };

    enum Etat
    {
        Saisie,
        Resultat,
    };

    Stages stage = Stages.Stage1;
    Etat etat = Etat.Saisie;

    void UpdateEtatSaisie()
    {
        float angleDecale = angle + angleoffset;

        if (angleDecale < 0)
        {
            angleDecale += 360;
        }
        angleDecale %= 360;
        int value = Mathf.FloorToInt(angleDecale / 360 * 13);

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, dist))
        {
            if (hit.collider.CompareTag("Disk"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    symb = symbols[value];
                    UISymbols[count].symbol = symb;
                    bool isSymbolValid = CheckSymbolValid(symb, stage, count);
                    UISymbols[count].isValid = isSymbolValid;
                    count++;
                    if (!isSymbolValid)
                    {
                        resultTimer = resultDuration;
                        etat = Etat.Resultat;
                    }
                    if (CheckFinish(count))
                    {
                        resultTimer = resultDuration;
                        etat = Etat.Resultat;
                    }
                }
            }
        }

    }

    bool CheckSymbolValid(string symbol, Stages stage, int pos)
    {
        if (cheatMode)
        {
            return true;
        }

        switch (stage)
        {
            case Stages.Stage1:
                return validSymbolsStage1[pos] == symbol;

            case Stages.Stage2:
                return validSymbolsStage2[pos] == symbol;

            case Stages.Stage3:
                return validSymbolsStage3[pos] == symbol;

            case Stages.Stage4:
                return validSymbolsStage4[pos] == symbol;

            case Stages.Stage5:
                return validSymbolsStage5[pos] == symbol;

            case Stages.Stage6:
                return validSymbolsStage6[pos] == symbol;

            case Stages.Stage7:
                return validSymbolsStage7[pos] == symbol;

            default:
                return false;
        }
    }

    bool CheckFinish(int pos)
    {
        switch (stage)
        {
            case Stages.Stage1:
                return pos == validSymbolsStage1.Length;

            case Stages.Stage2:
                return pos == validSymbolsStage2.Length;

            case Stages.Stage3:
                return pos == validSymbolsStage3.Length;

            case Stages.Stage4:
                return pos == validSymbolsStage4.Length;

            case Stages.Stage5:
                return pos == validSymbolsStage5.Length;

            case Stages.Stage6:
                return pos == validSymbolsStage6.Length;

            case Stages.Stage7:
                return pos == validSymbolsStage7.Length;

            default:
                return false;
        }
    }

    void UpdateEtatResultat()
    {
        resultTimer -= Time.deltaTime;
        if (resultTimer <= 0)
        {
            for (int i = 0; i < UISymbols.Length; i++)
            {
                UISymbols[i].symbol = "";
            }
            if (CheckFinish(count))
            {
                NextStage();
            }
            count = 0;
            etat = Etat.Saisie;
        }
    }

    void UpdateRoue()
    {
        angle += speed * Time.deltaTime;
        angle %= 360;
        Vector3 newEulerAngles = transform.localEulerAngles;
        newEulerAngles.z = -angle;
        transform.localEulerAngles = newEulerAngles;
    }

    void Update()
    {

        UpdateRoue();

        if (etat == Etat.Saisie)
        {
            UpdateEtatSaisie();
        }
        else
        {
            UpdateEtatResultat();
        }

    }


    private void NextStage()
    {
        if(stage != Stages.Stage7)
        {
            stage++;
        }
        else
        {
            Debug.Log("Au dela du stage 7");
        }
    }
}
