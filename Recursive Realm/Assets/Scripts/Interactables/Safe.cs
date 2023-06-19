
using UnityEngine;

public class Safe : Interactable
{
    [SerializeField] private GameObject _safePasswordCanvas;

    public bool IsOpened;

    protected override void Interact()
    {
        _safePasswordCanvas.SetActive(true);
    }
}
