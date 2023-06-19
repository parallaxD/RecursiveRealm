using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfBook : Interactable
{
    [SerializeField] private GameObject _bookImage;
    [SerializeField] private List<GameObject> _notebookContent;
    private bool _canInteract;

    protected override void Interact()
    {
        if (GameManager.IsSomeBookOpen)
        {
            return;
        }
        if (GameManager.CurrentPart == GameManager.GameParts.FirstPart) _canInteract = true;

        if (_canInteract)
        {
            GameManager.IsGamePaused = true;
            GameManager.IsSomeBookOpen = true;
            Cursor.lockState = CursorLockMode.None;
            _bookImage.SetActive(true);
            if (!HasInteracted)
            {
                StartCoroutine(PlayerThoughts.Thought("Хмм... Интересно..."));
            }
            HasInteracted = true;
            GameManager.CurrentPart = GameManager.GameParts.SecondPart;
            foreach (var content in _notebookContent)
            {
                content.SetActive(true);
            }
        }
        else
        {
            StartCoroutine(PlayerThoughts.Thought("Сейчас это не нужно"));
        }
    }
}
