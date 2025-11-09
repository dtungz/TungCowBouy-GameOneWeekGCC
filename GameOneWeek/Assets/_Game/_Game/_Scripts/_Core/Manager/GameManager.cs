using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum GameState
{
    Start = 0,
    Playing = 1,
    GameOver = 2,
    Winner = 3,
}
public class GameManager : MonoBehaviour
{
    InputAction playAction;
    public static GameManager Instance
    {
        get; private set;
    }
    private GameState currState;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playAction = InputSystem.actions.FindAction("Start");
        currState = GameState.Start;
    }

    private void Update()
    {
        if (currState == GameState.Start && playAction.WasPressedThisFrame())
        {
            currState = GameState.Playing;
        }
        if(currState == GameState.GameOver && playAction.WasPressedThisFrame())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public bool IsState(GameState state)
    {
        return currState == state;
    }
    public void ChangeState(GameState state)
    {
        if (currState != state)
        {
            currState = state;
        }
    }

    public GameState GetState()
    {
        return currState;
    }
}
