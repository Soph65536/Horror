using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDelete : MonoBehaviour
{
    [SerializeField] private KeypadDisplay KeypadDisplay;

    public void DeleteKey()
    {
        KeypadDisplay.CurrentKeys = string.Empty;
    }
}
