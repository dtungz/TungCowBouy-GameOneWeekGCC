using UnityEngine;

public class GameUnit : MonoBehaviour
{
    public PoolType PoolType;

    public virtual void OnDespawn(float delay)
    {
        Invoke(nameof(Despawn), delay);
    }

    private void Despawn()
    {
        PoolManager.Despawn(this);
    }
}
