using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _promptText;

    public void UpdateText(string promptMessage)
    {
        _promptText.text = promptMessage;   
    }
}
