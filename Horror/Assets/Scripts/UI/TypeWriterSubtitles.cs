using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterSubtitles : MonoBehaviour
{
    const float typeWriteDelay = 0.1f;
    const float typeWriteEndDelay = 1.5f;

    private TextMeshProUGUI SubtitleText;

    public bool CurrentlyWritingText;

    // Start is called before the first frame update
    void Start()
    {
        SubtitleText = GetComponent<TextMeshProUGUI>();
    }

    public void changeTextColour(Color colour)
    {
        SubtitleText.color = colour;
    }

    public IEnumerator TypeWriteText(string textString)
    {
        CurrentlyWritingText = true;

        //create temp string to display text as
        string tempString = string.Empty;

        //add each char of text to the string with delay
        for(int character = 0; character < textString.Length; character++)
        {
            tempString += textString[character];
            SubtitleText.text = tempString;
            yield return new WaitForSeconds(typeWriteDelay);
        }

        yield return new WaitForSeconds(typeWriteEndDelay);
        SubtitleText.text = string.Empty;

        CurrentlyWritingText = false;
    }
}
