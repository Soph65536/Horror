using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //creates the gamemanager instance
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    //constants
    const float TimeSpeed = 1.0f;

    //variables
    public bool InGameMenu;
    public bool InInventory;

    void Awake()
    {
        //makes sure there is only one gamemanager instance and sets that instance to this
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        InGameMenu = false; 
        InInventory = false;
    }

    private void Update()
    {
        if(InGameMenu ||  InInventory)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = TimeSpeed;
        }
    }
}
