using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBook : Interactable
{
    [SerializeField] private GameObject _bookImage;

    protected override void Interact()
    {
        if (GameManager.IsSomeBookOpen)
        {
            return;
        }
        GameManager.IsGamePaused = true;
        GameManager.IsSomeBookOpen = true;
        Cursor.lockState = CursorLockMode.None;
        _bookImage.SetActive(true);
    }
}
