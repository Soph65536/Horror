using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
    [SerializeField] private string objectName;
    [SerializeField] private string displayText;
    [SerializeField] private AudioClip soundToPlay;

    private TypeWriterSubtitles typeWriterSubtitles;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    public string GetName()
    {
        return objectName;
    }

    public void Interact()
    {
        audioSource.PlayOneShot(soundToPlay);
        Destroy(gameObject);
    }
}
