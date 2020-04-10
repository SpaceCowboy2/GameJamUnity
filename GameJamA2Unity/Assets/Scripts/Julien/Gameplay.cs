using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Gameplay : MonoBehaviour
{
    public int numberOfShakes = 5;
    private Animator animShake;
    private bool canShake = false;
    public bool Doors;
    public Animator DoorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        animShake = this.GetComponent<Animator>();
        //animDoors = Doors.GetComponent<Animator>();
        StartCoroutine(WaitForShaking());

    }

    // Update is called once per frame
    void Update()
    {
        DoorAnimator.SetBool("CanCloseDoors",Doors);
        if(canShake)
        StartCoroutine(Shaking());

    }


    IEnumerator Shaking()
    {
        if(numberOfShakes > 0)
        {
            animShake.Play("ShakeFreeFall");
            numberOfShakes--;
            yield return new WaitForSeconds(0.16f);
        }
        else
        {
           animShake.Play("EndOfShake");
        }
    }

    IEnumerator WaitForShaking()
    {
        yield return new WaitForSeconds(20);
        canShake = true; 
    }
}
