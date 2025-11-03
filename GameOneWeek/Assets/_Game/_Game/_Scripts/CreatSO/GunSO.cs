using UnityEngine;


[CreateAssetMenu(fileName = "GunSO", menuName = "ScriptableObjects/GunSO")]
public class GunSO : ScriptableObject
{
    [field: SerializeField] public float damage { get; private set; }
    [field: SerializeField] public float speedShoot { get; private set; }
    [field: SerializeField] public float speedReload { get; private set; }
    [field: SerializeField] public float rangeShoot { get; private set; }
    [field: SerializeField] public int bulletCount { get; private set; }
    [field: SerializeField] public int magCount { get; private set; }
}
