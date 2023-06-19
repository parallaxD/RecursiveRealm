using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorPassword : MonoBehaviour
{
    private string _enteredPassword = string.Empty;
    private string _rightPassword = "IritRTF";

    [SerializeField] private GameObject _blackCanvas;

    [SerializeField] private Text _passwordText;

    [SerializeField] private GameObject _door;

    private void OnEnable()
    {
        GameManager.PlayerUICanvas.SetActive(false);
        GameManager.PauseGame();
    }

    private void OnDisable()
    {
        GameManager.PlayerUICanvas.SetActive(true);
        GameManager.ResumeGame();
    }


    private void Update()
    {
        _passwordText.text = _enteredPassword;
    }

    public void EnterButtonNumber(string buttonNumber) => _enteredPassword += buttonNumber;

    public void TryPassword()
    {
        if (_enteredPassword == _rightPassword)
        {
            var doorScript = _door.GetComponent<Door>();
            SoundManager.PlaySound(_door.GetComponent<Door>().InteractSound);
            PlayerPrefs.SetInt("PlayerScore", GameManager.PlayerScore);

            GameManager.PlayerUICanvas.SetActive(false);
            _blackCanvas.SetActive(true);

            Destroy(gameObject);
            doorScript.IsOpen = true;
            doorScript.PromptMessage = "—бежать";
            GameManager.CurrentPart = GameManager.GameParts.FifthPart;
        }
    }

    public void DeletePassword()
    {
        _enteredPassword = string.Empty;
    }
}
