using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObject/EnemySO")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public int HP { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float speed { get; private set; }
    [field: SerializeField] public float active { get; private set; }
}
