using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string objectName;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public string GetName()
    {
        return objectName;
    }

    public void Interact()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
