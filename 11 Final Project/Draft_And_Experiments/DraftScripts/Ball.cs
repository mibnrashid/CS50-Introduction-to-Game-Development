using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 x = new Vector3(1,0,0);
    private Vector3 y = new Vector3(0,1,0);
    private Vector3 z = new Vector3(0,0,1);
    public GameObject Cube;
    public bool moving = false;
    public string direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction == Player.direction;

        if (direction == "Up"){
            transform.position += (z / 5);
        } else if (direction == "Down"){
            transform.position -= (z / 5);
        } else if (direction == "Right"){
            transform.position += (x / 5);
        } else if (direction == "Left"){
            transform.position -= (x / 5);
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Cube"){
            moving = true;
        }
    }
    void OnCollisionExit(Collision collision){
        if (collision.gameObject.name == "Cube"){
            moving = false;
        }
    }
}
