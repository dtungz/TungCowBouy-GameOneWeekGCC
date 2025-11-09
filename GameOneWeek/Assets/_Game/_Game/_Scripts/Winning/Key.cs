using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] Transform Transform;
    [SerializeField] GameObject Door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Door.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void SetPossition(Transform transform)
    {
        this.Transform.position = transform.position;
    }
}
