using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the game's UI, including HUD, menus, and game state displays.
/// Listens for state changes to update UI elements accordingly.
/// </summary>
public class UIManager : Singleton<UIManager>
{
    [Header("UI Panels")]
    public GameObject menuPanel;       // Reference to the main menu panel
    public GameObject gameOverPanel;   // Reference to the game over panel
    public GameObject hudPanel;        // Reference to the in-game HUD panel

    [Header("HUD Elements")]
    public Text healthText;            // Displays player's health
    public Text scoreText;             // Displays the player's score

    /// <summary>
    /// Subscribe to game state events on enabling the UI manager.
    /// </summary>
    private void OnEnable()
    {
        EventService.Instance.RegisterListener("GameStateChanged", OnGameStateChanged);
    }

    /// <summary>
    /// Unsubscribe from game state events on disabling the UI manager.
    /// </summary>
    private void OnDisable()
    {
        EventService.Instance.RemoveListener("GameStateChanged", OnGameStateChanged);
    }

    /// <summary>
    /// Updates UI panels based on the current game state.
    /// </summary>
    private void OnGameStateChanged(object state)
    {
        GameManager.GameState gameState = (GameManager.GameState)state;

        // Show/hide UI panels based on the game state
        menuPanel.SetActive(gameState == GameManager.GameState.Menu);
        hudPanel.SetActive(gameState == GameManager.GameState.Play);
        gameOverPanel.SetActive(gameState == GameManager.GameState.GameOver);
    }

    /// <summary>
    /// Updates the health display on the HUD.
    /// </summary>
    public void UpdateHealth(int health)
    {
        healthText.text = $"Health: {health}";
    }

    /// <summary>
    /// Updates the score display on the HUD.
    /// </summary>
    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    /// <summary>
    /// Restart the game from the UI.
    /// Called from the restart button in the UI.
    /// </summary>
    public void OnRestartButtonPressed()
    {
        GameManager.Instance.StartGame();
    }
}
