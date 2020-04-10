using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Gameplay : MonoBehaviour
{
    public int numberOfShakes = 5;
<<<<<<< HEAD
    //public GameObject Doors;
    private Animator animShake;

=======
    private Animator animShake;
>>>>>>> 7a5185475bc7923ceba58d17897439a33580720a
    private bool canShake = false;
    public bool Doors;
    public Animator DoorAnimator;

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
<<<<<<< HEAD

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
      
       
    }

    void CloseDoor()
    {
        
    }
=======
>>>>>>> 7a5185475bc7923ceba58d17897439a33580720a
}
