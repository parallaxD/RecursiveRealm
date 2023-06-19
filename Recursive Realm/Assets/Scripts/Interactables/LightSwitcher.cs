using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : Interactable
{
    [SerializeField] private List<Light> _lights;
    private bool _isLightEnable;

    protected override void Interact()
    {
        SoundManager.PlaySound(InteractSound);
        if (GameObject.Find("Lights").GetComponent<FlickeringLight>().enabled)
        {
            GameObject.Find("Lights").GetComponent<FlickeringLight>().enabled = false;
        }
        foreach (var light in _lights)
        {
            _isLightEnable = !_isLightEnable;
            light.enabled = !light.enabled;
        }
    }
}
