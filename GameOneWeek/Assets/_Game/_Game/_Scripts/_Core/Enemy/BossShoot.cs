using System;
using System.Collections;
using UnityEngine;

public class BossShoot : MonoBehaviour, IShootable
{
    [SerializeField] private EnemyBullet BulletPrefab;
    [SerializeField] private EnemySO data;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _tf;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] PlayerManager _playerManager;
    [SerializeField] private float distance; // Khoảng cách giữa Player và Enemy
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SpawnManager spawnManager;
    public bool isAttacking = false;
    private Coroutine delayAttack;


    //private void Start()
    //{
    //    BulletPrefab.gameObject.SetActive(false);
    //    currHP = data.HP;
    //}

    private void OnEnable()
    {
        BulletPrefab.gameObject.SetActive(false);
    }

    private void Update()
    {
        //if (_tf != null || _playerManager == null)
        //    return;
        if (!GameManager.Instance.IsState(GameState.Playing) || !spawnManager.checkWave()) return;
        distance = Vector3.Distance(_target.position, transform.position);
        XoayNguoi();
        if (distance <= data.AttackRange)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            // TODO: 
            if (delayAttack != null)
            {
                delayAttack = null;
            }
            delayAttack = StartCoroutine(WaitForAttacked());

        }
    }

    IEnumerator WaitForAttacked()
    {
        yield return new WaitForSeconds(0.5f);
        //Debug.DrawLine(_target.position, BeetweenPlayer.normalized * data.AttackRange * 2, Color.red);
        Shoot((Vector2)transform.right);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        if (BulletPrefab.gameObject.activeInHierarchy)
        {
            BulletPrefab.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
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

}
