using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraRaycast : MonoBehaviour
{
    const float interactrange = 2.5f;

    [SerializeField] private TextMeshProUGUI ObjectNameText;

    private GameObject hitObject = null;

    // Update is called once per frame
    void FixedUpdate()
    {
        CastRay();
    }

    void CastRay(){
        
        //reset object so it doesn't outline or show name text
        if (hitObject != null && hitObject.GetComponent<Outline>() != null) { hitObject.GetComponent<Outline>().enabled = false; }
        ObjectNameText.text = null;


        //RayCastHit contains information about whatever object the raycast is detecting
        RaycastHit raycastobjinfo = new RaycastHit();

        //hit determines if the raycast has hit an object
        bool hit = Physics.Raycast(transform.position, Camera.main.transform.forward, out raycastobjinfo, interactrange);

        if(hit)
        {
            hitObject = raycastobjinfo.transform.gameObject;

            //cache interactable script
            IInteractable hitObjectScript = hitObject.GetComponent<IInteractable>();

            //if is interactable
            if (hitObjectScript != null)
            {
                //make outline on object
                hitObject.GetComponent<Outline>().enabled = true;

                //display name of object on screen
                ObjectNameText.text = hitObjectScript.GetName();

                //if interact then call interact function
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log(hitObject);
                    hitObjectScript.Interact();
                }
            }
        }
    }
}
