using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    public List<GameObject> lights = new List<GameObject>();
    private int listLength = 5;
    private int _switch = 5;

  


    // Start is called before the first frame update
    void Start()
    {
        
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
        yield return new WaitForSeconds(25);
        _switch--;
        
        
        
    }
}
