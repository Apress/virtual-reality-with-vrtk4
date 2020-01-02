using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimmer : MonoBehaviour
{
    public Light Target_Light;
    public float Rate = .08f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Light pointLight = Target_Light;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            pointLight.range += Rate;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            pointLight.range -= Rate;
        }
    }
}
