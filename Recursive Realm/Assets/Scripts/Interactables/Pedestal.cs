using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : Interactable
{
    [SerializeField] private GameObject _door;
    private bool _isDoorOpen;
    protected override void Interact()
    {
        SoundManager.PlaySound(InteractSound);
        if (!_isDoorOpen) PromptMessage = "�������";
        else PromptMessage = "�������"; 

        _isDoorOpen = !_isDoorOpen;
        _door.GetComponentInParent<Animator>().SetBool("IsOpen", _isDoorOpen);
    }
}
