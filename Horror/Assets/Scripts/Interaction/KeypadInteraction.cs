using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeypadInteraction : MonoBehaviour, IInteractable
{
    const float TransformMoveSpeed = 0.01f;

    [SerializeField] private string objectName;

    private GameObject PlayerObject;
    [SerializeField] private GameObject KeypadUI;

    private Vector3 KeypadFocusPosition;
    private Quaternion KeypadFocusRotation;

    private Vector3 PlayerPosition;
    private Quaternion PlayerRotation;

    private Vector3 CurrentPositionToLerpTo;
    private Quaternion CurrentRotationToLerpTo;
    private bool isLerpingToNewTransform;

    private bool isUsingKeypad;


    private void Start()
    {
        PlayerObject = GameObject.FindFirstObjectByType<PlayerMovement>().gameObject;
        KeypadUI.SetActive(false);

        KeypadFocusPosition = new Vector3(0, 1.75f, 2.75f);
        KeypadFocusRotation = Quaternion.identity;

        isLerpingToNewTransform = false;
        isUsingKeypad = false;
    }


    private void SetNewTransform(Vector3 NewPositon, Quaternion NewRotation)
    {
        CurrentPositionToLerpTo = NewPositon;
        CurrentRotationToLerpTo = NewRotation;
        isLerpingToNewTransform = true;
    }

    private void MovePlayerTransform()
    {
        //lerp player transform to new transform
        PlayerObject.transform.position = Vector3.Lerp(PlayerObject.transform.position, CurrentPositionToLerpTo, TransformMoveSpeed);
        PlayerObject.transform.rotation = Quaternion.Lerp(PlayerObject.transform.rotation, CurrentRotationToLerpTo, TransformMoveSpeed);

        if (PlayerObject.transform.position == CurrentPositionToLerpTo && 
            PlayerObject.transform.rotation == CurrentRotationToLerpTo)
        {
            isLerpingToNewTransform = false;
        }
    }


    private void Update()
    {
        //if using keyboard
        if (isUsingKeypad)
        {
            //enable keyboard ui
            KeypadUI.SetActive(true);

            //if press esc while ui is open
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                CloseKeypad();
            }
        }

        //if lerping to new transform then lerp to new transform
        if (isLerpingToNewTransform)
        {
            MovePlayerTransform();
        }

        //change game manager after finished lerping
        //so it doesn't immediately give player controls back
        if(!isUsingKeypad && !isLerpingToNewTransform)
        {
            GameManager.Instance.UsingKeypad = false;
        }
    }

    private void OpenKeypad()
    {
        //is using keypad
        isUsingKeypad = true;
        GameManager.Instance.UsingKeypad = true;

        //store players current transform
        PlayerPosition = PlayerObject.transform.position;
        PlayerRotation = PlayerObject.transform.rotation;

        //move player transform to keypad transform
        SetNewTransform(KeypadFocusPosition, KeypadFocusRotation);
    }

    private void CloseKeypad()
    {
        //disable keyboard ui
        KeypadUI.SetActive(false);

        //move player transform back to last transform
        SetNewTransform(PlayerPosition, PlayerRotation);

        //no longer using keypad
        isUsingKeypad = false;
    }


    public string GetName()
    {
        return objectName;
    }

    public void Interact()
    {
        OpenKeypad();
    }
}
