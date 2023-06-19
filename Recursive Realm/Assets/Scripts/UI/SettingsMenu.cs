using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _volumeValueText;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private TMP_InputField _FpsLimitInputField;
    [SerializeField] private TMP_Dropdown _qualityDropdown;
    [SerializeField] private Toggle _fullScreenToogle;
    [SerializeField] private Toggle _vSyncToogle;

    private Resolution[] _resolutions;

    private void Start()
    {
        _fullScreenToogle.isOn = Screen.fullScreen;
        if (QualitySettings.vSyncCount == 1) _vSyncToogle.isOn = true;
        else _vSyncToogle.isOn = false;

        Cursor.lockState = CursorLockMode.None;

        _qualityDropdown.value = 0;

        QualitySettings.vSyncCount = 1;
        QualitySettings.SetQualityLevel(0);

        _resolutions = Screen.resolutions;

        _resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = $"{_resolutions[i].width}  x {_resolutions[i].height}";
            options.Add(option);

            if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    private void Awake()
    {
        _volumeValueText.text = "100";
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 30);
        _volumeValueText.text = Mathf.RoundToInt(_volumeSlider.value * 100).ToString();
        SaveVolumeSetting();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVsync(bool isEnable)
    {
        QualitySettings.vSyncCount = isEnable ? 1 : 0;
    }

    public void SetMaximumFps()
    {
        int fpsNumber;
        if (int.TryParse(_FpsLimitInputField.text, out fpsNumber))
        {
            Application.targetFrameRate = int.Parse(_FpsLimitInputField.text);
        }
        else
        {
            _FpsLimitInputField.text = "¬ведите целое число";
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", _qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", _resolutionDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference", _volumeSlider.value);
        PlayerPrefs.SetInt("VsyncPreference", QualitySettings.vSyncCount);
    }
    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference")) _qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else _qualityDropdown.value = 3;
        
        if (PlayerPrefs.HasKey("ResolutionPreference")) _resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else _resolutionDropdown.value = currentResolutionIndex;
        
        if (PlayerPrefs.HasKey("FullscreenPreference")) Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else Screen.fullScreen = true;
        
        if (PlayerPrefs.HasKey("VolumePreference")) _volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        else _volumeSlider.value = 100f;

        if (PlayerPrefs.HasKey("VsyncPreference")) QualitySettings.vSyncCount = PlayerPrefs.GetInt("VsyncPreference");
        else QualitySettings.vSyncCount = 1;
    }

    private void SaveVolumeSetting()
    {
        PlayerPrefs.SetFloat("VolumePreference", _volumeSlider.value);
    }
}
