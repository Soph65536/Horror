using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //locks cursor on opening game
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitClicked()
    {
        Application.Quit();
    }
}
