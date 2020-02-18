using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//SOURCE: https://www.youtube.com/watch?v=98gfkursxYI&t=615s

public class Shoot : MonoBehaviour
{

    private SimpleShoot simpleShoot;
    //private OVRGrabbable ovrGrabbable;
    public OVRInput.Button trigger;



    // Start is called before the first frame update
    void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        //ovrGrabbable = GetComponent<OVRGrabbable>();

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(trigger)) 
        {
            simpleShoot.TriggerShoot();

        }
    }
}
