using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAmountManager : MonoBehaviour
{
    //[SerializeField] private Vector2Int[] BaseAmount = new Vector2Int[3];
    [SerializeField] private List<GunSO> OptionGun = new List<GunSO>();
    [SerializeField] private Vector2Int[] Inventory = new Vector2Int[3]; // x : số đạn hiện tại, y : số băng đạn hiện tại
    GunStatic currentWeapon;
    Coroutine reloadCoroutin;
    InputAction reloadAction;

    private void Start()
    {
        reloadAction = InputSystem.actions.FindAction("Reload");
        currentWeapon = ChoiceGun.currGun;
        for(int i = 0; i < Inventory.Length; i++)
        {
            Inventory[i] = new Vector2Int(OptionGun[i].bullet, OptionGun[i].mag);
        }
    }

    private void Update()
    {
        if (Inventory[(int)ChoiceGun.currGun].x == 0 && PlayerShootingState.state != PlayerState.Reload)
        {
            PlayerShootingState.state = PlayerState.NoShot;
        }
        else if(Inventory[(int)ChoiceGun.currGun].x != 0 && PlayerShootingState.state == PlayerState.NoShot)
        {
            PlayerShootingState.state = PlayerState.Shoot;
        }
        if(currentWeapon != ChoiceGun.currGun)
        {
            StopAllCoroutines();
            currentWeapon = ChoiceGun.currGun;
            if (Inventory[(int)currentWeapon].x == 0)
            {
                PlayerShootingState.state = PlayerState.NoShot;
            }
            else
            {
                PlayerShootingState.state = PlayerState.Shoot;
            }
        }
        if(reloadAction.WasPressedThisFrame() && Inventory[(int)currentWeapon].y > 0)
        {
            Reload();
        }
    }
    
    public void IncAmount()
    {
        Inventory[(int)ChoiceGun.currGun].x--;
    }

    public void Reload()
    {
        PlayerShootingState.state = PlayerState.Reload;
        if(reloadCoroutin != null)
        {
            StopCoroutine(reloadCoroutin);
        }
        reloadCoroutin = StartCoroutine(ReloadDelay());
    }

    IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(OptionGun[(int)currentWeapon].speedReload);
        Inventory[(int)currentWeapon].y--;
        Inventory[(int)currentWeapon].x = OptionGun[(int)currentWeapon].bullet;
        PlayerShootingState.state = PlayerState.Shoot;
    }

    public void UpdateBullet(int i)
    {
        Inventory[i].y++;
    }
}
