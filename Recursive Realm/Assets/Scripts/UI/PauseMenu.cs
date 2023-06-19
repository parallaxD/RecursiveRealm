using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static GameObject PauseMenuObject;
    private GameObject _pausePanel;
    private GameObject _settingsPanel;
    private GameObject _keyBindingsPanel;


    private void Awake()
    {
        PauseMenuObject = GameObject.Find("PauseMenu");
        _pausePanel = GameObject.Find("PausePanel");
        _settingsPanel = GameObject.Find("SettingsPanel");
        _keyBindingsPanel = GameObject.Find("KeyBindingsPanel");
    }

    private void Start()
    {
        PauseMenuObject.SetActive(false);
        _pausePanel.SetActive(false);
        _settingsPanel.SetActive(false);
        _keyBindingsPanel.SetActive(false);
    }


    private void Update()
    {
        if (InputManager.PlayerActions.PauseGame.triggered && !GameManager.IsSomeBookOpen)
        {
            if (!GameManager.IsGamePaused)
            {
                PauseMenuObject.SetActive(true);
                _pausePanel.SetActive(true);
                GameManager.PauseGame();
            }
            else
            {
                PauseMenuObject.SetActive(false);
                _pausePanel.SetActive(false);
                _settingsPanel.SetActive(false);
                _keyBindingsPanel.SetActive(false);
                GameManager.ResumeGame();
            }
        }
    }

    public void OpenSettingsPanel()
    {
        _pausePanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }
    public void OpenKeyBindingsPanel()
    {
        _pausePanel.SetActive(false);
        _keyBindingsPanel.SetActive(true);
    }
}
