using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafePasswordCanvas : MonoBehaviour
{
    private string _enteredPassword = string.Empty;
    private string _rightPassword = "aBCaABc";

    [SerializeField] private GameObject _safe;
    [SerializeField] private AudioClip _safeOpenSound;

    private Safe _safeScript;

    [SerializeField] private Text passwordText;

    private void Start()
    {
        _safeScript = _safe.GetComponentInChildren<Safe>();
    }

    private void OnEnable()
    {
        GameManager.PlayerUICanvas.SetActive(false);
        GameManager.PauseGame();
    }

    private void OnDisable()
    {
        if (_safeScript.IsOpened)
        {
            Destroy(_safeScript);
        }
        GameManager.PlayerUICanvas.SetActive(true);
        GameManager.ResumeGame();
    }

    private void Update()
    {
        passwordText.text = _enteredPassword;
    }

    public void EnterButtonNumber(string buttonNumber) => _enteredPassword += buttonNumber;

    public void TryPassword()
    {
        if (_enteredPassword == _rightPassword)
        {
            _safe.GetComponentInChildren<Animator>().SetBool("IsOpen", true);
            foreach (var collider in _safe.GetComponentsInChildren<BoxCollider>())
            {
                collider.enabled = true;
            }
            _safeScript.IsOpened = true;
            SoundManager.PlaySound(_safeOpenSound);
            Destroy(gameObject);
        }
    }

    public void DeletePassword()
    {
        _enteredPassword = string.Empty;
    }
}
