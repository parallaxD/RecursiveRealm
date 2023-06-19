using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string PromptMessage;
    public bool HasInteracted;

    public AudioClip InteractSound;

    public void BaseInteract()
    {
        Interact();
    }
    protected abstract void Interact();
}
