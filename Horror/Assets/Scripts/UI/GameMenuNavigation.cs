using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameMenuNavigation : MonoBehaviour
{
    public GameObject[] menuButtons = null;
    private int selectedButton;

    private Color defaultColor;
    private Color selectedColor;

    // Start is called before the first frame update
    void Start()
    {
        selectedButton = 0;

        defaultColor = new Color(0, 1, 0);
        selectedColor = new Color(0, 1, 0.5f);
    }

    //reset selected button when menu opened
    private void OnEnable()
    {
        selectedButton = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //button selection and movement
        if (Input.GetKeyUp(KeyCode.E))
        {
            PressButton();
        } 
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            selectedButton++;
        } 
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.S))
        {
            selectedButton--;
        }

        //loop buttons
        if (selectedButton > menuButtons.Length - 1) { selectedButton = 0; }
        if (selectedButton < 0) { selectedButton = menuButtons.Length - 1; }

        //button colours
        for(int i = 0; i < menuButtons.Length; i++)
        {
            //gets an array of each text item in menubuttons[i]
            TextMeshProUGUI[] textItems = menuButtons[i].GetComponentsInChildren<TextMeshProUGUI>();

            //sets colour for each text item
            for(int j = 0; j < textItems.Length; j++)
            {
                //sets colour based on whether selected or not
                if(i == selectedButton)
                {
                    textItems[j].color = selectedColor;
                }
                else
                {
                    textItems[j].color = defaultColor;
                }
            }

            //sets rectangle outline of objects based on whether selected or not
            if(i == selectedButton)
            {
                menuButtons[i].GetComponentInChildren<UnityEngine.UI.Image>().enabled = true;
            }
            else
            {
                menuButtons[i].GetComponentInChildren<UnityEngine.UI.Image>().enabled = false;
            }
        }

    }

    void PressButton()
    {
        menuButtons[selectedButton].GetComponent<IMenuButton>().OnButtonPress();
    }
}
