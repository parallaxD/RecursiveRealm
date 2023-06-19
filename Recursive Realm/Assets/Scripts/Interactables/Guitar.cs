using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : Interactable
{
    protected override void Interact()
    {
        if (!HasInteracted)
        {
            StartCoroutine(PlayerThoughts.Thought("Неплохой чехол. У отца такой же на балконе стоит"));
            HasInteracted = true;
        }
        else
        {
            StartCoroutine(PlayerThoughts.Thought("Лучше не буду эго трогать"));
        }
    }
}
