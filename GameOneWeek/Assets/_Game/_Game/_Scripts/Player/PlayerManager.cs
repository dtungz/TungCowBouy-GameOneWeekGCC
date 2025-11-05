using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sr;
    private float hp = 200;
    private Coroutine makeColor;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (makeColor != null)
            makeColor = null;
        makeColor = StartCoroutine(ChangeColor());
        Debug.Log("Người chơi còn lại " + hp + "hp");
    }
    
    
    
    IEnumerator ChangeColor()
    {
        _sr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _sr.color = Color.white;
    }
}
