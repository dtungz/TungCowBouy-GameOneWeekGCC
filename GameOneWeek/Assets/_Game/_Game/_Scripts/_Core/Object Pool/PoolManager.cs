using System.Collections.Generic;
using UnityEngine;
public static class PoolManager
{
      private static Dictionary<PoolType, Pool> pools = new Dictionary<PoolType, Pool>();
        
      public static void OnInit(GameUnit prefabs, int amount, Transform root = null)
      {
            if (prefabs != null && !pools.ContainsKey(prefabs.PoolType))
            {
                  Pool pool = new Pool(prefabs, amount, root);
                  pool.Init();
                  pools.Add(prefabs.PoolType, pool);
            }
      }

      public static T Spawn<T>(PoolType poolType, Vector3 pos, Quaternion rot) where T : GameUnit
      {
            if (!pools.ContainsKey(poolType))
            {
                  return null;
            }
            return pools[poolType].Spawn(pos, rot) as T;
      }

      public static void Despawn(GameUnit obj)
      {
            if (obj != null && pools.ContainsKey(obj.PoolType))
            {
                  pools[obj.PoolType].Despawn(obj);
            }
      }

      public static void CollectAll()
      {
            foreach (var pool in pools.Values)
            {
                  pool.Collect();
            }
      }

    public static void ClearDicT()
    {
        pools.Clear();
    }

    
}
