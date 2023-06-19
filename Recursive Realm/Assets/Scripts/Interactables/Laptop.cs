using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : Interactable
{
    [SerializeField] private GameObject _exerciseToStart;
    protected override void Interact()
    {
        if (GameManager.CurrentPart != GameManager.GameParts.FourthPart) StartCoroutine(PlayerThoughts.Thought("Это сейчас не нужно"));
        if (GameManager.CurrentPart == GameManager.GameParts.FourthPart && !HasInteracted)
        {            
            gameObject.GetComponent<Animator>().enabled = true;
            PromptMessage = "Посмотреть";
            HasInteracted = true;
            SoundManager.PlaySound(InteractSound);
        }
        else if (HasInteracted)
        {
            StartCoroutine(PlayerThoughts.Thought("Надеюсь, это конец..."));
            StartCoroutine(GameManager.StartExcercise(_exerciseToStart));
        }
    }
}
