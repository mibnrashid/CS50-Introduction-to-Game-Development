using UnityEngine;

// Script for adjusting the camera according to the screen ratio
public class CameraCropping : MonoBehaviour
{
    // set the desired aspect ratio (the values in this example are
    // hard-coded for 27:10, but you could make them into public
    // variables instead so you can set them at design time)
    public float targetaspect = 27.0f / 10.0f;

    // obtain camera component so we can modify its viewport
    Camera mycamera;

    void Start (){
        mycamera = GetComponent<Camera>();
    }
    
    void Update (){
        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f){
            float recty = (1.0f - scaleheight) / 2.0f;
            mycamera.rect = new Rect(0, recty, 1.0f, scaleheight);
        } else{ 
            // add pillarbox
            float scalewidth = 1.0f / scaleheight;
            float rectx = (1.0f - scalewidth) / 2.0f;
            mycamera.rect = new Rect(rectx, 0, scalewidth, 1.0f);
        }
    }
}
