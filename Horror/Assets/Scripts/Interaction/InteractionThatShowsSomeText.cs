using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionThatShowsSomeText : MonoBehaviour, IInteractable
{
    [SerializeField] private string objectName;
    [SerializeField] private string displayText;

    public string GetName()
    {
        return objectName;
    }

    public void Interact()
    {
        Debug.Log("m");
    }
}
