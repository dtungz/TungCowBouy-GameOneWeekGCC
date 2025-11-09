using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    private int Damage;
    
    public void FireBullet(Vector2 Direction, int Damage, float Range)
    {
        _rb.AddForce(Direction.normalized * (Range), ForceMode2D.Impulse);
        this.Damage = Damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ITakeDamageable player = other.GetComponent<ITakeDamageable>();
            player.TakeDamage(Damage);
            gameObject.SetActive(false);
        }
    }
}
