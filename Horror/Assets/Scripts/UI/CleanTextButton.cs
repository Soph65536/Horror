using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanTextButton : MonoBehaviour
{
    [SerializeField] private GameObject CleanText;
    private void Start()
    {
        CleanText.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameManager.Instance.ViewingDocumentCleanText = false;
            CleanText.SetActive(false);
        }
    }

    public void ShowCleanText()
    {
        GameManager.Instance.ViewingDocumentCleanText = true;
        CleanText.SetActive(true);
    }
}
