using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGameMenu : MonoBehaviour, IMenuButton
{
    public void OnEPress()
    {
        Application.Quit();
    }

    public void OnQPress()
    {
        //does nothing
        return;
    }
}