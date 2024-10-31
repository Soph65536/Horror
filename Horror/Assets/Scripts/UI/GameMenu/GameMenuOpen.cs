using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuOpen : MonoBehaviour
{
    const KeyCode GameMenuKey = KeyCode.Escape;

    [SerializeField] private GameObject GameMenuObject;

    // Start is called before the first frame update
    void Start()
    {
        GameMenuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(GameMenuKey)
           && !GameManager.Instance.InGameMenu 
           && !GameManager.Instance.InInventory
           && !GameManager.Instance.ViewingDocument
           && !GameManager.Instance.UsingKeypad) 
        {
            GameManager.Instance.InGameMenu = true;
        }
        else if (Input.GetKeyUp(GameMenuKey)
            && GameManager.Instance.InGameMenu)
        {
            GameManager.Instance.InGameMenu = false;
        }

        GameMenuObject.SetActive(GameManager.Instance.InGameMenu);
    }
}
