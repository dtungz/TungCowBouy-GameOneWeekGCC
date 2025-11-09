using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ITakeDamageable
{
    [SerializeField] private SpriteRenderer _sr;
    public int hp = 200;
    private Coroutine makeColor;

    private void Update()
    {
        if(hp <= 0)
        {
            GameManager.Instance.ChangeState(GameState.GameOver);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (makeColor != null)
            makeColor = null;
        makeColor = StartCoroutine(ChangeColor(Color.red));
        //Debug.Log("Người chơi còn lại " + hp + "hp");
    }
    
    IEnumerator ChangeColor(Color color)
    {
        _sr.color = color;
        yield return new WaitForSeconds(0.2f);
        _sr.color = Color.white;
    }
}
