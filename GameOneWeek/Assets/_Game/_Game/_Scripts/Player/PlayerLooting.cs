using UnityEngine;

public class PlayerLooting : MonoBehaviour
{
    [SerializeField] private PlayerAmountManager amountManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Amount"))
        {
            AmountLooting hit = collision.GetComponent<AmountLooting>();
            if(hit != null)
            {
                amountManager.UpdateBullet((int)hit.amountLoot);
                hit.DeSpawn();
            }
        }
    }
}
