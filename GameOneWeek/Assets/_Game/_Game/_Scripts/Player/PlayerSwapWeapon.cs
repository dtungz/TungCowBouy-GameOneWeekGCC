using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwapWeapon : MonoBehaviour
{
    InputAction Option1, Option2, Option3;
    public GunStatic GunNow;


    private void Awake()
    {
        Option1 = InputSystem.actions.FindAction("Option1");
        Option2 = InputSystem.actions.FindAction("Option2");
        Option3 = InputSystem.actions.FindAction("Option3");
    }

    private void Update()
    {
        ChangeWeapon();
        GunNow = ChoiceGun.currGun;
    }

    private void ChangeWeapon()
    {
        if(Option1.WasPressedThisFrame())
        {
            ChoiceGun.SetStatic(0);
        }
        if (Option2.WasPressedThisFrame())
        {
            ChoiceGun.SetStatic(1);
        }
        if (Option3.WasPressedThisFrame())
        {
            ChoiceGun.SetStatic(2);
        }
    }
}
