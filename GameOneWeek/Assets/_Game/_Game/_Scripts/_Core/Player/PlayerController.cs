using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction inputAction;
    
    [SerializeField] private Rigidbody2D _rb;
    
    private Vector2 dirPlayer;
    private float speedPlayer = 8f;

    private void Start()
    {
        inputAction = InputSystem.actions.FindAction("Movement");
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (GameManager.Instance.IsState(GameState.Playing))
        {
            dirPlayer = inputAction.ReadValue<Vector2>();
            dirPlayer.Normalize();
            _rb.linearVelocity = dirPlayer * speedPlayer;
        }
    }
    
}
