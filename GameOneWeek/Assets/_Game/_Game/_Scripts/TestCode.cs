using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestCode : MonoBehaviour
{
    InputAction moveAction;
    
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Vector2 _direction;
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Movement");
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {   
        _direction = moveAction.ReadValue<Vector2>();
        _rb.linearVelocity = _speed * _direction;
    }
}
