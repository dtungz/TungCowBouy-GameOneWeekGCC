using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState currState = GameState.Playing;
    public enum GameState
    {
        Paused,
        Playing,
        GameOver,
        Minigame,
    }
}
