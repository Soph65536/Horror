using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGameMenu : MonoBehaviour, IMenuButton
{
    public void OnEPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnQPress()
    {
        //does nothing
        return;
    }
}
