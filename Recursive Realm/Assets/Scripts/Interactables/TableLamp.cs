using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableLamp : Interactable
{
    [SerializeField] private Light _spotLight;
    private bool _isLightEnable;

    protected override void Interact()
    {
        if (!_isLightEnable) PromptMessage = "Включить";
        else PromptMessage = "Выключить";

        SoundManager.PlaySound(InteractSound);

        _isLightEnable = !_isLightEnable;
        _spotLight.enabled = !_spotLight.enabled;
    }
}
