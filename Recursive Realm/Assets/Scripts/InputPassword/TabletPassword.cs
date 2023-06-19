using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletPassword : MonoBehaviour
{
    private string _enteredPassword = string.Empty;
    private string _rightPassword = "8642";

    [SerializeField] private Text _passwordText;

    [SerializeField] private GameObject _tabletPasswordImage;

    [SerializeField] private GameObject _tablet;


    private Tablet _tabletScript;

    private void Start()
    {
        _tabletScript = _tablet.GetComponent<Tablet>();
    }
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

    public void EnterButtonNumber(int buttonNumber) => _enteredPassword += buttonNumber.ToString();

    public void TryPassword()
    {
        if (_enteredPassword == _rightPassword)
        {
            _tabletScript.IsOpen = true;
            Destroy(gameObject);
            Destroy(_tabletPasswordImage);
        }
    }

    public void DeletePassword()
    {
        _enteredPassword = string.Empty;
    }
}
