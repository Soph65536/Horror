using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class KeyEnter : MonoBehaviour
{
    const string CorrectKeys = "6662";
    const float ResetDelay = 2.0f;

    [SerializeField] private KeypadDisplay KeypadDisplay;
    [SerializeField] private KeypadInteraction KeypadInteraction;

    [SerializeField] private GameObject KeypadScreenNeutral;
    [SerializeField] private GameObject KeypadScreenGreen;
    [SerializeField] private GameObject KeypadScreenRed;

    [SerializeField] private AudioSource KeypadAudioSource;
    [SerializeField] private AudioClip CorrectSound;
    [SerializeField] private AudioClip WrongSound;

    private bool ResettingKeypad;

    private void Start()
    {
        KeypadScreenNeutral.SetActive(true);
        KeypadScreenGreen.SetActive(false);
        KeypadScreenRed.SetActive(false);

        ResettingKeypad = false;
    }


    public void EnterKey()
    {
        CheckKeys(KeypadDisplay.CurrentKeys);
    }


    private void CheckKeys(string keys)
    {
        KeypadScreenNeutral.SetActive(false);

        if (keys == CorrectKeys)
        {
            ShowNewScreen(KeypadScreenGreen, CorrectSound);
            
            KeypadInteraction.StartCoroutine("UnlockWall");
            KeypadInteraction.CloseKeypad();
        }
        else if(!ResettingKeypad)
        {
            ShowNewScreen(KeypadScreenRed, WrongSound);
            StartCoroutine("ResetKeypad");
        }
    }

    private void ShowNewScreen(GameObject screen, AudioClip sound)
    {
        screen.SetActive(true);
        KeypadAudioSource.PlayOneShot(sound);
    }


    private IEnumerator ResetKeypad()
    {
        ResettingKeypad = true;

        yield return new WaitForSeconds(ResetDelay);
        KeypadDisplay.CurrentKeys = string.Empty;
        KeypadScreenRed.SetActive(false);
        KeypadScreenNeutral.SetActive(true);

        ResettingKeypad = false;
    }
}
