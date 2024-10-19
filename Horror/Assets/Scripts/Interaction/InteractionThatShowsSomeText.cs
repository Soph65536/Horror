using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionThatShowsSomeText : MonoBehaviour, IInteractable
{
    [SerializeField] private string objectName;
    [SerializeField] private string displayText;

    private TypeWriterSubtitles typeWriterSubtitles;

    private void Start()
    {
        typeWriterSubtitles = GameObject.FindObjectOfType<TypeWriterSubtitles>().GetComponent<TypeWriterSubtitles>();
        Debug.Log(typeWriterSubtitles);
    }

    public string GetName()
    {
        return objectName;
    }

    public void Interact()
    {
        //if nothing is currently being displayed in typewritersubtitles then write the text
        if (!typeWriterSubtitles.CurrentlyWritingText)
        {
            typeWriterSubtitles.StartCoroutine("TypeWriteText", displayText);
        }
    }
}
