using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public List<ObjectPool> pools;

    private void Awake()
    {
        PoolManager.ClearDicT();
        for (int i = 0; i < pools.Count; i++)
        {
            PoolManager.OnInit(pools[i].prefab, pools[i].amount, pools[i].root);
        }
    }
}

[System.Serializable]
public class ObjectPool
{
    public Transform root = null;
    public GameUnit prefab = null;
    public int amount = 0;
}