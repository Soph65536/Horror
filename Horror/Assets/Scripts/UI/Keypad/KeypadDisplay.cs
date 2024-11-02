using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadDisplay : MonoBehaviour
{
    public string CurrentKeys;

    private TextMeshProUGUI NumbersText;

    // Start is called before the first frame update
    void Start()
    {
        NumbersText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        NumbersText.text = CurrentKeys;
        if(CurrentKeys.Length > 4 ) { CurrentKeys = CurrentKeys.Substring(0, 4); }
    }
}
