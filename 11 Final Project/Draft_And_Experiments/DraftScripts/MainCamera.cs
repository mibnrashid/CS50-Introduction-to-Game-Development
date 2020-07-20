using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Vector3 z = new Vector3(0, 0, 1);
    private Vector3 x = new Vector3(1, 0, 0);
    private Vector3 y = new Vector3(0, 1, 0);
    private float speed = 50.0f;
    public bool move = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if ( transform.position.x >= 60 & transform.position.x <= 80 &
           //transform.position.z >= -50 & transform.position.z <= -30 ){
            InputKeys();
            DefaultPosition();
        //} 
        //transform.Rotate(Vector3.down * speed * Time.deltaTime);          
    }
    public void InputKeys() {
        if (Input.GetKey("right shift")){
            if (Input.GetKey("w"))
            {
                transform.position -= (y / 2);
            }
            if (Input.GetKey("s"))
            {
                transform.position += (y / 2);
            }  
        } 
        if (Input.GetKey("left shift")) {
            if (Input.GetKey("w"))
            {
                transform.position += (z / 2);
            }
            if (Input.GetKey("s"))
            {
                transform.position -= (z / 2);
            }  
            if (Input.GetKey("d"))
            {
                transform.position += (x / 1);
            }
            if (Input.GetKey("a"))
            {
                transform.position -= (x / 1);
            } 
        }
    }
    public void DefaultPosition() {
        if ( transform.position.x >= 40 ){
            transform.position -= x;
        }
        if ( transform.position.x <= 100 ){
            transform.position += x;
        }
        if ( transform.position.z >= -60 ){
            transform.position -= z;
        }
        if ( transform.position.z <= -20 ){
            transform.position += z;
        }
        if ( transform.position.y <= 10 ){
            transform.position += y;
        }
    }
}