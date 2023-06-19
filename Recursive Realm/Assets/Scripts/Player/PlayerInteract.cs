using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private float _interactDistance = 3f;
    [SerializeField] private LayerMask _mask;
    private PlayerUI _playerUI;

    [SerializeField] private float _interactCooldown = 0.7f;
    private float _lastInteractTime;

    void Start()
    {
        _playerUI = GetComponent<PlayerUI>();
        _cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (GameManager.IsGamePaused)
        {
            return;
        }
        _playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * _interactDistance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, _interactDistance, _mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                _playerUI.UpdateText(interactable.PromptMessage);
                if (InputManager.PlayerActions.Interact.triggered && CanInteract())
                {
                    interactable.BaseInteract();
                    _lastInteractTime = Time.time;
                }
            }
        }
    }

    private bool CanInteract()
    {
        return Time.time - _lastInteractTime >= _interactCooldown;
    }
}
