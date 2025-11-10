using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boss : MonoBehaviour, ITakeDamageable, IEnemy
{
    [SerializeField] private EnemySO data;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _tf;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private SpriteRenderer _sr => this.GetComponent<SpriteRenderer>();
    [SerializeField] private GameManager _gameManager;
    [SerializeField] PlayerManager _playerManager;
    [SerializeField] private float distance; // Khoảng cách giữa Player và Enemy
    [SerializeField] private Key key;
    [SerializeField] private SpawnManager spawnManager;
    //[SerializeField] private List<EnemyBullet> _bullets = new List<EnemyBullet>();
    //[SerializeField] private List<Transform> _bulletPosition = new List<Transform>();
    public bool onAttacked = false, isAttacking = false;
    private Coroutine delayAttack, delayTakeDamage;
    private Vector2 BeetweenPlayer;
    private int currHP;
    int rateDrop;

    private void OnEnable()
    {
        //BulletPrefab.gameObject.SetActive(false);
        currHP = data.HP;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsState(GameState.Playing) || !spawnManager.checkWave()) return;
        if (currHP <= 0)
        {
            gameObject.SetActive(false);
            rateDrop = UnityEngine.Random.Range(0, 101);
            Drop();
            return;
        }
        distance = Vector3.Distance(_target.position, transform.position);
        BeetweenPlayer = (Vector2)(_target.position - _tf.position);

        if (distance <= data.AttackRange)
        {
            Attack();
        }
        else
        {
            Movement();
        }
    }

    public void TakeDamage(int damage)
    {
        currHP -= damage;
        //Debug.Log(currHP);
        //if (currHP <= 0)
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
        if (Physics2D.Raycast(_tf.position, BeetweenPlayer, data.AttackRange + 0.5f, _playerMask))
        {
            _playerManager.TakeDamage(data.Damage);
        }
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        _sr.color = Color.white;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        onAttacked = false;
        isAttacking = false;
    }

    private void Drop()
    {
        key.SetPossition(_tf);
        key.gameObject.SetActive(true);
    }

    //public void Shoot(Vector2 direction)
    //{
    //    for(int i = 0; i < _bullets.Count; i++)
    //    {
    //        _bullets[i].gameObject.SetActive(true);
    //        _bullets[i].transform.position = _bulletPosition[i].position;


    //        _bullets[i].FireBullet(direction, data.Damage, data.AttackRange);
    //    }
        
    //}
}
