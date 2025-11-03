using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction inputAction;
    
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameManager _gameManager;
    
    private Vector2 dirPlayer;
    private float speedPlayer = 8f;

    private void Start()
    {
        inputAction = InputSystem.actions.FindAction("Movement");
        _gameManager.currState = GameManager.GameState.Playing;
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (_gameManager.currState == GameManager.GameState.Playing)
        {
            dirPlayer = inputAction.ReadValue<Vector2>();
            dirPlayer.Normalize();
            _rb.linearVelocity = dirPlayer * speedPlayer;
        }
    }
    
}
