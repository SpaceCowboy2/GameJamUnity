using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public int numberOfShakes = 5;
    public GameObject Doors;
    private Animator animShake;
    public Animation animDoorOpen;
    public Animation animDoorClose;
    private bool canShake = false;

    // Start is called before the first frame update
    void Start()
    {
        animShake = this.GetComponent<Animator>();
        //animDoors = Doors.GetComponent<Animator>();
        StartCoroutine(WaitForShaking());
        StartCoroutine(WaitForOpeningDoors(8));
        StartCoroutine(WaitForClosingDoors(12));

    }

    // Update is called once per frame
    void Update()
    {
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

    IEnumerator WaitForOpeningDoors(float time)
    {
        yield return new WaitForSeconds(time);
        OpenDoor();

    }

    IEnumerator WaitForClosingDoors(float time)
    {
        
        yield return new WaitForSeconds(time);
        CloseDoor();
    }

    void OpenDoor()
    {
        animDoorOpen.Play();
       
    }

    void CloseDoor()
    {
        animDoorClose.Play();
    }
}
