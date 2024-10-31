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


    private void Start()
    {
        PlayerObject = GameObject.FindFirstObjectByType<PlayerMovement>().gameObject;
        KeypadUI.SetActive(false);

        KeypadFocusPosition = new Vector3(0, 1.75f, 2.75f);
        KeypadFocusRotation = Quaternion.identity;

        isLerpingToNewTransform = false;
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

        if (Vector3.Distance(PlayerObject.transform.position, CurrentPositionToLerpTo) > Vector3.kEpsilon && 
            PlayerObject.transform.rotation == CurrentRotationToLerpTo)
        {
            //no longer lerping to new transform
            isLerpingToNewTransform = false;
        }
    }


    private void Update()
    {
        //if using keyboard
        if (GameManager.Instance.UsingKeypad)
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
    }

    private void OpenKeypad()
    {
        //is using keypad
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
        GameManager.Instance.UsingKeypad = false;
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
