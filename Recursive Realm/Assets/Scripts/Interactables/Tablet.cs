using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : Interactable
{
    [SerializeField] private GameObject _tabletPasswordCanvas;
    [SerializeField] private GameObject _exerciseToStart;
    public bool IsOpen;
    protected override void Interact()
    {
        if (_tabletPasswordCanvas != null) _tabletPasswordCanvas.SetActive(true);
        if (IsOpen && !HasInteracted)
        {
            SoundManager.PlaySound(InteractSound);
            StartCoroutine(PlayerThoughts.Thought("Посмотрим, что тут"));
            StartCoroutine(GameManager.StartExcercise(_exerciseToStart));
            HasInteracted = true;
            GameManager.CurrentPart = GameManager.GameParts.FourthPart;
        }
    }
}
