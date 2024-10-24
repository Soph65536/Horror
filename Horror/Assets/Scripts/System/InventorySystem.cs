using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private List<InventoryObject> Objects = null;

    [SerializeField] private MenuNavigation InventoryMenu;
    [SerializeField] private GameObject MenuButton;
    [SerializeField] private GameObject ReturnButton;

    public void PickupObject(InventoryObject inventoryObject)
    {
        //checks if already obtained 1 of object and if has then increase count
        bool AlreadyHasObject = false;

        for (int i = 0; i < Objects.Count; i++)
        {
            if (Objects[i] == inventoryObject)
            {
                Objects[i].objectCount++;
                AlreadyHasObject = true;
            }
        }

        //add new object if doesn't already have one
        if (!AlreadyHasObject) { Objects.Append(inventoryObject); }
    }

    public void DropObject()
    {
        int selectedObject = InventoryMenu.selectedButton;

        //instantiate object and either decrease count or remove
        Instantiate(Objects[selectedObject].objectPrefab);

        if (Objects[selectedObject].objectCount > 1) 
        { 
            Objects[selectedObject].objectCount--;
        }
        else
        {
            Objects.RemoveAt(InventoryMenu.selectedButton);
        }
    }

    public void UpdateInventoryMenu()
    {
        //remove all items from inventorymenu by setting it to a new empty array of the correct size
        InventoryMenu.menuButtons = new GameObject[Objects.Count+1];

        //destroy all children in current inventory menu so they can be remade
        foreach (Transform child in InventoryMenu.gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        //create return button as first object in redrawn inventory menu
        InventoryMenu.menuButtons[0] = Instantiate(ReturnButton, InventoryMenu.gameObject.transform);

        //create each item in inventory as menu button and set in corresponding index of menubuttons array
        for (int i = 0; i < Objects.Count; i++)
        {
            GameObject newButton = Instantiate(MenuButton, InventoryMenu.gameObject.transform);
            InventoryMenu.menuButtons[i+1] = newButton;

            //gets an array of each text item in the button
            TextMeshProUGUI[] textItems = newButton.GetComponentsInChildren<TextMeshProUGUI>();
            //sets the text items to the contents of object[i]
            textItems[0].text = Objects[i].objectName;
            textItems[1].text = Objects[i].objectCount.ToString();
        }
    }
}
