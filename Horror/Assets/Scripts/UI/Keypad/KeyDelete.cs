using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDelete : MonoBehaviour
{
    [SerializeField] private KeypadDisplay KeypadDisplay;

    public void DeleteKey()
    {
        if(KeypadDisplay.CurrentKeys != string.Empty)
        {
            KeypadDisplay.CurrentKeys = KeypadDisplay.CurrentKeys.Substring(0, KeypadDisplay.CurrentKeys.Length - 1);
        }
    }
}
