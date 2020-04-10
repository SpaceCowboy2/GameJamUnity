using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Gameplay : MonoBehaviour
{
    public int numberOfShakes = 5;
    public Animator animShake;
    private bool canShake = false;
    public bool Doors;
    public bool calledOnce = true;
    public Animator DoorAnimator;
    public bool test = false;

    // Start is called before the first frame update
    void Start()
    {
       // animDoors = Doors.GetComponent<Animator>();
        StartCoroutine(WaitForShaking());
        
    }

    // Update is called once per frame
    void Update()
    {
        DoorAnimator.SetBool("CanCloseDoors",Doors);

        if(!calledOnce)
        {
            calledOnce = true;
            StartCoroutine(Shaking());
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            animShake.SetBool("ShakeAgain",true);
        }


        if(animShake.GetBool("ShakeAgain") == true && animShake.GetBool("FinishedShaking") == true)
        {
            StartCoroutine(Shaking());
        }
    }


    IEnumerator Shaking()
    {
        
       for (int i = 0; i < 30; i++)
       {
            animShake.SetTrigger("CanShake");
            Debug.Log(i);
            animShake.Play("ShakeFreeFall");
            yield return new WaitForSeconds(0.16f);            
       }
        animShake.SetBool("ShakeAgain",false); // Mettre à false pour refaire l'animation 
        animShake.SetBool("FinishedShaking", true);
    }


    IEnumerator WaitForShaking()
    {
        yield return new WaitForSeconds(2.0f);
        calledOnce = false; 
    }
}
