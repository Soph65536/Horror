using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float yRotation = 0;
    public float maxAngle = 90;

    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(yRotation, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //change yrotation by mousey input
        yRotation -= (Input.GetAxis("Mouse Y")*2);
        //set yrotation boundaries so it can only rotate between maxangle and -maxangle degrees
        yRotation = Mathf.Clamp(yRotation, -maxAngle, maxAngle);

        //update transform angle to be new y rotation
        transform.localEulerAngles = new Vector3(yRotation, 0, 0);
    }
}
