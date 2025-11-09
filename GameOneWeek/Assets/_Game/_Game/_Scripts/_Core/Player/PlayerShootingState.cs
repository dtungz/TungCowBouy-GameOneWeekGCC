using UnityEngine;

public enum PlayerState
{
    Shoot = 0,
    Reload = 1,
    NoShot = 2,
}

public class PlayerShootingState : MonoBehaviour
{
    public static PlayerState state;

    private void Start()
    {
        state = PlayerState.Shoot;
    }
}
