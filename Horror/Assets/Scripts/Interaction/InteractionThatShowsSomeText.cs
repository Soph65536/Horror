using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionThatShowsSomeText : MonoBehaviour, IInteractable
{
    [SerializeField] private string objectName;
    [SerializeField] private string displayText;
    [SerializeField] private AudioClip soundToPlay;

    private TypeWriterSubtitles typeWriterSubtitles;
    private AudioSource audioSource;

    private void Start()
    {
        typeWriterSubtitles = GameObject.FindObjectOfType<TypeWriterSubtitles>().GetComponent<TypeWriterSubtitles>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(soundToPlay);
            typeWriterSubtitles.StartCoroutine("TypeWriteText", displayText);
        }
    }
}
