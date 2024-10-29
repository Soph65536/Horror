using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentViewer : MonoBehaviour, IInteractable
{
    [SerializeField] private string objectName;
    [SerializeField] private GameObject DocumentToView;

    public string GetName()
    {
        return objectName;
    }

    public void Interact()
    {
        GameManager.Instance.ViewingDocument = true;

        //create document object in the canvas
        Instantiate(DocumentToView, GameObject.FindAnyObjectByType<Canvas>().transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && !GameManager.Instance.ViewingDocumentCleanText)
        {
            GameManager.Instance.ViewingDocument = false;

            //destroys all document instances
            foreach(GameObject document in (GameObject.FindGameObjectsWithTag("Document")))
            {
                Destroy(document);
            }
        }        
    }
}
