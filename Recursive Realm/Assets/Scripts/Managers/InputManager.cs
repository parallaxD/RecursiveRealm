using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputSystem _inputSystem;
    public static InputSystem.PlayerActions PlayerActions;
    void Awake()
    {
        _inputSystem = new InputSystem();
        PlayerActions = _inputSystem.Player;
        PlayerActions.Enable();
    }
}
