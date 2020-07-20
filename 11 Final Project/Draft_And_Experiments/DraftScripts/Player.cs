using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 x = new Vector3(1,0,0);
    private Vector3 y = new Vector3(0,1,0);
    private Vector3 z = new Vector3(0,0,1);
    public string direction;
    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += (z / 5);
            direction = "Up";
            moving = true;
        }
        else if (Input.GetKey("down"))
        {
            transform.position -= (z / 5);
            direction = "Down";
            moving = true;
        }  
        else if (Input.GetKey("right"))
        {
            transform.position += (x / 5);
            direction = "Right";
            moving = true;
        }
        else if (Input.GetKey("left"))
        {
            transform.position -= (x / 5);
            direction = "Left";
            moving = true;
        }
        else{
            moving = false;
            direction = "None";
        }
    }
}
