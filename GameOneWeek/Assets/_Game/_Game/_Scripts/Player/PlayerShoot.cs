using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    InputAction shootAction;
    Camera cam;
    private bool isShoting = false;
    Coroutine ShoootingDelay;
    private float timeDelayShoot;
    GunStatic currWeapon;

    [SerializeField] private List<GunSO> OptionGun = new List<GunSO>();
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
        currWeapon = ChoiceGun.currGun;
        timeDelayShoot = OptionGun[(int)currWeapon].delayPrevShot;
    }

    private void Shooting()
    {
        if (shootAction.IsPressed() && !isShoting)
        {
            if(ShoootingDelay != null)
            {
                ShoootingDelay = null;
            }
            ShoootingDelay = StartCoroutine(ShootingDelayTime());
            Vector2 direction = Mouse.current.position.ReadValue();
            direction = cam.ScreenToWorldPoint(direction);
            GunRif.Shoot(direction);
        }
    }

    IEnumerator ShootingDelayTime()
    {
        isShoting = true;
        yield return new WaitForSeconds(timeDelayShoot);
        isShoting = false;
    }
}
