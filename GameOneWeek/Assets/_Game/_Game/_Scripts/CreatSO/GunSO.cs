using UnityEngine;


[CreateAssetMenu(fileName = "GunSO", menuName = "ScriptableObjects/GunSO")]
public class GunSO : ScriptableObject
{
    [field: SerializeField] public int damage { get; private set; }
    [field: SerializeField] public float delayPrevShot { get; private set; }
    [field: SerializeField] public float delay { get; private set; }
    [field: SerializeField] public float speedReload { get; private set; }


}
