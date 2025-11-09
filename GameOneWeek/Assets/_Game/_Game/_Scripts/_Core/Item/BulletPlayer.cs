using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : GameUnit
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float speed = 1f;
    [SerializeField] private List<GunSO> OptionGun = new List<GunSO>();
    GunStatic currentGun;
    private int damage;
    float delay;
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        currentGun = ChoiceGun.currGun;
        damage = OptionGun[(int)currentGun].damage;
        delay = OptionGun[(int)currentGun].delay;
        //Debug.Log(delay);
        Invoke(nameof(DeSpawn), delay);
    }

    private void DeSpawn()
    {
        PoolManager.Despawn(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            ITakeDamageable hit = collision.GetComponent<ITakeDamageable>();
            if (hit != null)
            {
                //Debug.Log("Ban trung");
                DeSpawn();
                hit.TakeDamage(damage);
            }
        }
    }
}
