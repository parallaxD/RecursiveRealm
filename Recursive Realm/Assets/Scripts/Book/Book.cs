using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private float _pageRotationSpeed = 0.5f;
    [SerializeField] private List<Transform> _pages;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _forwardButton;

    [SerializeField] private AudioClip _pageChangeSound;

    private bool _isCooldown;
    public float _rotationCooldown = 0.1f;

    private int _index = -1;
    private bool _isRotate = false;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < _pages.Count; i++)
        {
            _pages[i].transform.rotation = Quaternion.identity;
        }
        _pages[0].SetAsLastSibling();
        _backButton.SetActive(false);
    }
    public void RotateForward()
    {
        if (_isCooldown || _isRotate)
        {
            return;
        }
        SoundManager.PlaySound(_pageChangeSound);
        _index++;
        float angle = 180;
        ForwardButtonActions();
        _pages[_index].SetAsLastSibling();
        StartCoroutine(StartRotationCooldown());
        StartCoroutine(Rotate(angle, true));
    }

    public void RotateBack()
    {
        if (_isCooldown || _isRotate)
        {
            return;
        }
        SoundManager.PlaySound(_pageChangeSound);
        float angle = 0;
        BackButtonActions();
        _pages[_index].SetAsLastSibling();
        StartCoroutine(StartRotationCooldown());
        StartCoroutine(Rotate(angle, false));
    }

    public void ForwardButtonActions()
    {
        if (_backButton.activeInHierarchy == false)
        {
            _backButton.SetActive(true);
        }
        if (_index == _pages.Count - 1)
        {
            _forwardButton.SetActive(false);
        }
    }
    public void BackButtonActions()
    {
        if (_forwardButton.activeInHierarchy == false)
        {
            _forwardButton.SetActive(true);
        }
        if (_index - 1 == -1)
        {
            _backButton.SetActive(false);
        }
    }

    public void CloseBook()
    {
        if (_isCooldown)
        {
            return;
        }
        gameObject.SetActive(false);
        GameManager.IsGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.IsSomeBookOpen = false;
    }


    IEnumerator Rotate(float angle, bool isForward)
    {
        float value = 0f;
        while(true)
        {
            _isRotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * _pageRotationSpeed;
            _pages[_index].rotation = Quaternion.Slerp(_pages[_index].rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(_pages[_index].rotation, targetRotation);            
            if (angle1 < 0.1f)
            {
                if (!isForward)
                {
                    _index--;
                }
                _isRotate = false;
                break;
            }
            yield return null;
        }
    }

    private IEnumerator StartRotationCooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(_rotationCooldown);
        _isCooldown = false;
    }
}
