using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeypadInteraction : MonoBehaviour, IInteractable
{
    //movement stuff for unlockwall
    const float KeypadMovement = 0.1f;
    const float KeypadDelay = 0.05f;
    const float AmountForKeypadToMove = 6.6f;

    const float TransformMoveSpeed = 0.01f;

    [SerializeField] private string objectName;

    //objects of player
    private GameObject PlayerObject;
    private GameObject CameraAnimatorObject;
    private GameObject CameraObject;

    [SerializeField] private GameObject KeypadUI;

    private Vector3 KeypadFocusPosition;
    private Quaternion KeypadFocusRotation;

    private Vector3 PlayerPosition;
    private Quaternion PlayerRotation;

    private Vector3 CurrentPositionToLerpTo;
    private Quaternion CurrentRotationToLerpTo;
    private bool isLerpingToNewTransform;

    //another thing for unlock wall
    [SerializeField] private GameObject KeypadWall;


    private void Start()
    {
        PlayerObject = GameObject.FindFirstObjectByType<PlayerMovement>().gameObject;
        CameraAnimatorObject = PlayerObject.GetComponentInChildren<Animator>().gameObject;
        CameraObject = CameraAnimatorObject.GetComponentInChildren<Camera>().gameObject;

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

        //if lerping to keyboard
        if(CurrentPositionToLerpTo == KeypadFocusPosition)
        {
            //lerp player children rotations to identity so is exact
            CameraAnimatorObject.transform.rotation = Quaternion.Lerp(CameraAnimatorObject.transform.rotation, Quaternion.identity, TransformMoveSpeed);
            CameraObject.transform.rotation = Quaternion.Lerp(CameraObject.transform.rotation, Quaternion.identity, TransformMoveSpeed);

            //check for no longer lerping including player children
            if (Vector3.Distance(PlayerObject.transform.position, CurrentPositionToLerpTo) > Vector3.kEpsilon
            && PlayerObject.transform.rotation == CurrentRotationToLerpTo
            && CameraAnimatorObject.transform.rotation == Quaternion.identity
            && CameraObject.transform.rotation == Quaternion.identity)
            {
                //no longer lerping to new transform
                isLerpingToNewTransform = false;
            }
        }
        //else
        else
        {
            //check for no longer lerping
            if (Vector3.Distance(PlayerObject.transform.position, CurrentPositionToLerpTo) > Vector3.kEpsilon
            && PlayerObject.transform.rotation == CurrentRotationToLerpTo)
            {
                //no longer lerping to new transform
                isLerpingToNewTransform = false;
            }
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

    public void CloseKeypad()
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


    public IEnumerator UnlockWall()
    {
        KeypadWall.transform.parent = gameObject.transform;

        for (int i = 0; i < AmountForKeypadToMove / KeypadMovement; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - KeypadMovement, transform.position.z);
            yield return new WaitForSeconds(KeypadDelay);
        }
    }
}
