using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPress : MonoBehaviour
{
    [SerializeField] private KeypadDisplay KeypadDisplay;
    [SerializeField] private string Key;

    public void PressKey()
    {
        KeypadDisplay.CurrentKeys += Key;
    }
}
