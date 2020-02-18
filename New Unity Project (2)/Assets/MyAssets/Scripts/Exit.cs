using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision collisionObj)
    {
        //Output the message
        if (collisionObj.gameObject.tag == "Bullet")
        {
            Application.Quit();
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
