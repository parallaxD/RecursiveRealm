using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System;
public class GameManager : MonoBehaviour
{
    public enum GameParts
    {
        ZeroPart,
        FirstPart,
        SecondPart,
        ThirdPart,
        FourthPart,
        FifthPart
    }

    public static GameObject ExerciseBackGround;

    public static bool IsGamePaused;
    public static bool IsSomeBookOpen;    
    public static bool IsExericiseStarted;

    public static int PlayerScore;

    public static bool IsPlayerHasNotebook;
    public static bool IsPlayerHasKey;

    public static float SoundValue;

    public static GameParts CurrentPart = GameParts.ZeroPart;

    public static GameObject PlayerUICanvas;

    private const string qualitySettingsKey = "QualitySettings";

    [SerializeField] private GameObject _playerController;


    private void Awake()
    {
        ExerciseBackGround = GameObject.Find("BackgroundImage");
        ExerciseBackGround.SetActive(false);
        PlayerUICanvas = GameObject.Find("PlayerUICanvas");
        LoadQualitySettings();
    }

    public static void PauseGame()
    {
        if (IsGamePaused)
        {
            return;
        }
        IsGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public static void ResumeGame()
    {
        PauseMenu.PauseMenuObject.SetActive(false);
        IsGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public static IEnumerator StartExcercise(GameObject exerciseToStart)
    {
        InputManager.PlayerActions.Interact.Disable();
        yield return new WaitForSeconds(7f);
        ExerciseBackGround.SetActive(true);
        exerciseToStart.SetActive(true);
        IsSomeBookOpen = true;
        PlayerUICanvas.SetActive(false);
        PauseGame();
    }

    public void DestroyGameObject(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy);
    }

    private void LoadQualitySettings()
    {
        if (PlayerPrefs.HasKey(qualitySettingsKey))
        {
            int qualityLevel = PlayerPrefs.GetInt(qualitySettingsKey);
            QualitySettings.SetQualityLevel(qualityLevel);
        }
    }
    private void OnApplicationQuit()
    {
        SaveQualitySettings();
    }
    private void SaveQualitySettings()
    {
        int qualityLevel = QualitySettings.GetQualityLevel();
        PlayerPrefs.SetInt(qualitySettingsKey, qualityLevel);
        PlayerPrefs.Save();
    }
}
