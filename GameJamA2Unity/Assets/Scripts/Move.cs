using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody PlayerBody;
    //public Camera camera;
    // Use this for initialization
    void Start()
    {
        //camera.GetComponent<Palier5>().enabled = true;
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
    }
}
