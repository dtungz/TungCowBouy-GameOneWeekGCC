using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    InputAction shootAction;
    Camera cam;

    [SerializeField] private List<GunSO> OptionGun = new List<GunSO>();
    GunStatic currentGun;

    [SerializeField] Rifle GunRif;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    private void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (shootAction.WasPressedThisFrame())
        {
            Vector2 direction = Mouse.current.position.ReadValue();
            direction = cam.ScreenToWorldPoint(direction);
            GunRif.Shoot(direction);
        }
    }
}
