using System;
using System.Collections;
using UnityEngine;

public class Range : GameUnit, IEnemy, IShootable, ITakeDamageable
{
    [SerializeField] private EnemyBullet BulletPrefab;
    [SerializeField] private EnemySO data;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _tf;
    [SerializeField] private LayerMask _playerMask; 
    private SpriteRenderer _sr => this.GetComponent<SpriteRenderer>();
    [SerializeField] PlayerManager _playerManager;
    [SerializeField] private float distance; // Khoảng cách giữa Player và Enemy
    public bool onAttacked = false, isAttacking = false;
    private Coroutine delayAttack, delayTakeDamage;
    private Vector2 BeetweenPlayer;
    private int currHP;
    private int rateDrop;

    //private void Start()
    //{
    //    BulletPrefab.gameObject.SetActive(false);
    //    currHP = data.HP;
    //}

    private void OnEnable()
    {
        BulletPrefab.gameObject.SetActive(false);
        currHP = data.HP;
    }

    private void Update()
    {
        if (currHP <= 0)
        {
            rateDrop = UnityEngine.Random.Range(0, 101);
            if(rateDrop > 60)
                Drop();
            PoolManager.Despawn(this);
            return;
        }
        distance = Vector3.Distance(_target.position, transform.position);
        BeetweenPlayer = (Vector2)(_target.position - _tf.position);
        XoayNguoi();
        if (distance <= data.AttackRange)
        {
            Attack();
        }
        else if (distance <= data.active)
        {
            Movement();
        }
    }

    public void TakeDamage(int damage)
    {
        currHP -= damage;
        onAttacked = true;
        _rb.AddForce(-BeetweenPlayer.normalized * 3f, ForceMode2D.Impulse);
        if (delayTakeDamage != null)
        {
            delayTakeDamage = null;
        }

        delayTakeDamage = StartCoroutine(WaitForMove());
    }

    public void Movement()
    {
        if (!onAttacked && !isAttacking)
        {
            _rb.linearVelocity = BeetweenPlayer.normalized * data.speed;
        }
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            _rb.linearVelocity = Vector2.zero;
            // TODO: 
            if (delayAttack != null)
            {
                delayAttack = null;
            }
            delayAttack = StartCoroutine(WaitForAttacked());
            
        }
    }

    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(1f);
        onAttacked = false;
    }

    IEnumerator WaitForAttacked()
    {
        yield return new WaitForSeconds(0.5f);
        //Debug.DrawLine(_target.position, BeetweenPlayer.normalized * data.AttackRange * 2, Color.red);
        _sr.color = Color.blue;
        Shoot((Vector2)transform.right);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        _sr.color = Color.white;
        if (BulletPrefab.gameObject.activeInHierarchy)
        {
            BulletPrefab.gameObject.SetActive(false);
        }
    }
    
    private void OnDisable()
    {
        StopAllCoroutines();
        onAttacked = false;
        isAttacking = false;
    }

    private void XoayNguoi()
    {
        Vector3 lookDir = _target.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
        
    }
    
    public void Shoot(Vector2 direction)
    {
        BulletPrefab.gameObject.SetActive(true); 
        BulletPrefab.transform.position = _tf.position;
        BulletPrefab.FireBullet(direction, data.Damage, data.AttackRange);
    }

    private void Drop()
    {
        PoolManager.Spawn<AmountLooting>(PoolType.Amount, transform.position, Quaternion.identity);
    }

}
