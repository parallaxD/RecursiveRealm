using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : Interactable
{
    protected override void Interact()
    {
        if (GameManager.CurrentPart == GameManager.GameParts.ThirdPart && !HasInteracted)
        {
            GetComponent<Animator>().enabled = true;
            SoundManager.PlaySound(InteractSound);
            HasInteracted = true;
            GetComponent<Wardrobe>().enabled = false;
        }
        else StartCoroutine(PlayerThoughts.Thought("Это пока не нужно"));
    }
}
