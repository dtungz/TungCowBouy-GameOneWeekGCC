using UnityEngine;

public enum GunStatic
{
    Rifle = 0,
    Shotgun = 1,
    Snip =2,
}
public class ChoiceGun
{
    public static GunStatic currGun = GunStatic.Rifle;
    public static void SetStatic(int i)
    {
        currGun = (GunStatic)i;
    }
}
