using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<GameObject> UIOptions = new List<GameObject>();

    GameState gameState;

    private void Start()
    {
        gameState = GameState.Start;
    }

    private void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        if(!GameManager.Instance.IsState(gameState))
        {
            UIOptions[(int)gameState].gameObject.SetActive(false);
            UIOptions[(int)GameManager.Instance.GetState()].gameObject.SetActive(true);
        }
    }
}
