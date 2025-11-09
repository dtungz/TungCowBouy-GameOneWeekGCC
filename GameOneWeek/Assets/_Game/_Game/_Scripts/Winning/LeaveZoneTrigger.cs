using UnityEngine;

public class LeaveZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.ChangeState(GameState.Winner);
        }
    }
}
