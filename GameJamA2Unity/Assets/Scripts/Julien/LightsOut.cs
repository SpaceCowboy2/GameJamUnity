using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    public List<GameObject> lights = new List<GameObject>();
    private int listLength = 5;
    private int _switch = 5;
    public Light _light;
    private Color32 red;



    // Start is called before the first frame update
    void Start()
    {
        red = new Color32(130, 18, 18, 255);
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
        yield return new WaitForSeconds(5);
        _switch--;

        if (listLength == 1)
        {
            _light.color = red;
        }



    }
}
