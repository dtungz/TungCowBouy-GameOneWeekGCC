using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestOnStart : MonoBehaviour
{
    InputAction action;
    [SerializeField] private int Click1 = 0, Click2 = 0;
    
    
    private void Start()
    {
        action = InputSystem.actions["Collect"];
        Click1 = 0;
        
    }

    private void OnEnable()
    {
        Click2 = 0;
    }

    private void Update()
    {
        if (action.IsPressed())
        {
            Click2++;
            Click1++;
        }
    }
}
