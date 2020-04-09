using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    public float speed = 0.0f;
    public string[] symbols ;
    public float angle = 0.0f;


    void Update()
    {
        //speed = Random.Range(0.4f, 1.0f);
        //transform.Rotate(Vector3.up, speed);
        angle += speed * Time.deltaTime;
        angle = angle % 360;
        Vector3 newEulerAngles = transform.localEulerAngles;
        newEulerAngles.y = angle;
        transform.localEulerAngles = newEulerAngles;
        int value = Mathf.FloorToInt(angle / 360 * 13);

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(symbols[value]);
        }

        
        
       
    }

}
