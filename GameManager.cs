using UnityEngine;

/// <summary>
/// Controls the main game flow, including states like Menu, Play, and Pause.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    // Enum representing different game states for easy management
    public enum GameState { Menu, Play, Pause, GameOver }

    // Stores the current game state
    public GameState CurrentState { get; private set; }

    /// <summary>
    /// Initialize the game by setting the starting state.
    /// </summary>
    private void Start() => ChangeState(GameState.Menu);

    /// <summary>
    /// Changes the current game state and triggers a state change event.
    /// </summary>
    public void ChangeState(GameState newState)
    {
        CurrentState = newState; // Updates the current state
        EventService.Instance.TriggerEvent("GameStateChanged", newState); // Notify listeners
    }

    public void StartGame() => ChangeState(GameState.Play); // Start gameplay
    public void PauseGame() => ChangeState(GameState.Pause); // Pause gameplay
    public void GameOver() => ChangeState(GameState.GameOver); // Trigger game over state
}
