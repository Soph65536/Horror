using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameMenu : MonoBehaviour, IMenuButton
{
    public void OnButtonPress()
    {
        GameManager.Instance.InGameMenu = false;
        GameManager.Instance.InInventory = false;
    }
}
