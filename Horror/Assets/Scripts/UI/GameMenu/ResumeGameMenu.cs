using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameMenu : MonoBehaviour, IMenuButton
{
    public void OnEPress()
    {
        GameManager.Instance.InGameMenu = false;
        GameManager.Instance.InInventory = false;
    }

    public void OnQPress()
    {
        //does nothing
        return;
    }
}
