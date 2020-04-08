using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public int numberOfShakes = 5;
    private Animator animShake;
    // Start is called before the first frame update
    void Start()
    {
        animShake = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking()
    {
        if(numberOfShakes > 0)
        {
            animShake.Play("ShakeFreeFall");
            numberOfShakes--;
            //Debug.Log(numberOfShakes);
            yield return new WaitForSeconds(0.16f);
        }
        else
        {
           // animShake.Play();
        }
    }
}
