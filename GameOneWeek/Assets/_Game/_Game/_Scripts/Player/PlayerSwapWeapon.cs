using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwapWeapon : MonoBehaviour
{
    InputAction Option1, Option2, Option3;

    private void Start()
    {
        Option1 = InputSystem.actions.FindAction("Option1");
        Option2 = InputSystem.actions.FindAction("Option2");
        Option3 = InputSystem.actions.FindAction("Option3");
    }

    private void ChangeWeapon()
    {
        if(Option1.WasPressedThisFrame())
        {
            GunStatic.currGun
        }
    }
}
