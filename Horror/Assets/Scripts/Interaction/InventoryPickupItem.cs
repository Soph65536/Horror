using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickupItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string objectName;
    [SerializeField] private InventoryObject inventoryObject;

    public string GetName()
    {
        return objectName;
    }

    public void Interact()
    {
        GameObject.FindObjectOfType<InventorySystem>().PickupObject(inventoryObject);
        Destroy(gameObject);
    }
}
