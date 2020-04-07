using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public GameObject Pointer;
    public GameObject Player;
    private float yaw = 0.0f;
    private float pitch = 0.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        Pointer.transform.eulerAngles = new Vector3(pitch, yaw);
        Player.transform.eulerAngles = new Vector3(0, yaw);

        if (pitch >= 90)
        {
            Pointer.transform.eulerAngles = new Vector3(90, yaw, 0.0f);
            Player.transform.eulerAngles = new Vector3(0, yaw);
        }
        else if (pitch <= -90)
        {
            Pointer.transform.eulerAngles = new Vector3(-90, yaw, 0.0f);
            Player.transform.eulerAngles = new Vector3(0, yaw);
        }

    }
}
