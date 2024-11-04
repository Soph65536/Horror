using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyClear : MonoBehaviour
{
    [SerializeField] private KeypadDisplay KeypadDisplay;

    public void ClearKey()
    {
        KeypadDisplay.CurrentKeys = string.Empty;
    }
}
