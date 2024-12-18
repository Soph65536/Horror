using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    const KeyCode InventoryKey = KeyCode.I;

    [SerializeField] private GameObject InventorySystemObject;

    // Start is called before the first frame update
    void Start()
    {
        InventorySystemObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(InventoryKey)
           && !GameManager.Instance.InInventory
           && !GameManager.Instance.InGameMenu
           && !GameManager.Instance.ViewingDocument 
           && !GameManager.Instance.UsingKeypad)
        {
            GameManager.Instance.InInventory = true;
            //update the inventoy menu
            GameObject.FindObjectOfType<InventorySystem>().UpdateInventoryMenu();
        }
        else if (Input.GetKeyUp(InventoryKey)
            && GameManager.Instance.InInventory)
        {
            GameManager.Instance.InInventory = false;
        }

        InventorySystemObject.SetActive(GameManager.Instance.InInventory);
    }
}
