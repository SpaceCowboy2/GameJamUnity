using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    public List<GameObject> lights = new List<GameObject>();
    private int listLength = 5;
    private int _switch = 5;

<<<<<<< HEAD
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {

=======
=======
  
>>>>>>> parent of cc293ac... LD : spotlight bouttons


    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        red = new Color32(130, 18, 18, 255);
>>>>>>> 7a5185475bc7923ceba58d17897439a33580720a
=======
        
>>>>>>> parent of cc293ac... LD : spotlight bouttons
    }

    // Update is called once per frame
    void Update()
    {
        if (listLength > 0 && listLength == _switch)
        {
            StartCoroutine(TurnOffLights());
        }
    }

    IEnumerator TurnOffLights()
    {
        //Debug.Log(listLength);
        lights[listLength - 1].gameObject.SetActive(false);
        listLength--;
<<<<<<< HEAD
        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(5);
        _switch--;
<<<<<<< HEAD
        
=======

        if (listLength == 1)
        {
            _light.color = red;
        }



>>>>>>> 7a5185475bc7923ceba58d17897439a33580720a
=======
        yield return new WaitForSeconds(25);
        _switch--;
        
        
        
>>>>>>> parent of cc293ac... LD : spotlight bouttons
    }
}
