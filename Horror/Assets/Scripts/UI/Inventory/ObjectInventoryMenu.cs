using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInventoryMenu : MonoBehaviour, IMenuButton
{
    public void OnEPress()
    {
        GameObject.FindObjectOfType<InventorySystem>().UseObject();
    }

    public void OnQPress()
    {
        GameObject.FindObjectOfType<InventorySystem>().DropObject();
    }
}
