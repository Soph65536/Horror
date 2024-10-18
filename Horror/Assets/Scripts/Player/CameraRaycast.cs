using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public float interactrange = 25;

    // Update is called once per frame
    void FixedUpdate()
    {
        CastRay();
    }

    void CastRay(){
        //RayCastHit contains information about whatever object the raycast is detecting
        RaycastHit raycastobjinfo = new RaycastHit();
        //hit determines if the raycast has hit an object
        bool hit = Physics.Raycast(transform.position, Camera.main.transform.forward, out raycastobjinfo, interactrange);
        if(hit){
            GameObject hitObject = raycastobjinfo.transform.gameObject;
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log(hitObject);
                hitObject.GetComponent<IInteractable>().Interact();
            }
        }
    }
}
