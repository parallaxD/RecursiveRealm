using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : Interactable
{
    [SerializeField] private GameObject exerciseToStart;
    [SerializeField] private GameObject _bookContent;
    protected override void Interact()
    {
        if (GameManager.IsPlayerHasKey && !HasInteracted)
        {
            gameObject.GetComponent<Animator>().SetBool("IsFallen", true);
            StartCoroutine(GameManager.StartExcercise(exerciseToStart));
            SoundManager.PlaySound(InteractSound);
            GameManager.CurrentPart = GameManager.GameParts.ThirdPart;
            PromptMessage = string.Empty;
        }
    }
}
