using Unity.VisualScripting;
using UnityEngine;

public class AmountLooting : GameUnit
{
    public GunStatic amountLoot;
    [SerializeField] private SpriteRenderer _sr => this.GetComponent<SpriteRenderer>();

    //private void Awake()
    //{
    //    if(_sr != null)
    //        _sr = this.GetComponent<SpriteRenderer>();
    //}

    private void OnEnable()
    {
        amountLoot = (GunStatic)((int)Random.Range(0, 9)%3);
        switch((int)amountLoot)
        {

            case 0:
                _sr.color = Color.green;
                break;
            case 1:
                _sr.color = Color.red;
                break;
            case 2:
                _sr.color = Color.blue;
                break;
        }
    }

    public void DeSpawn()
    {
        PoolManager.Despawn(this);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Player"))
    //    {
    //        DeSpawn();
    //    }
    //}
}
