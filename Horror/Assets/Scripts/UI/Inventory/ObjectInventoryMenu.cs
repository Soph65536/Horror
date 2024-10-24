using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInventoryMenu : MonoBehaviour, IMenuButton
{
    public void OnButtonPress()
    {
        GameObject.FindObjectOfType<InventorySystem>().DropObject();
    }
}
