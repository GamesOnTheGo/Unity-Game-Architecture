using UnityEngine;

/// <summary>
/// Service for handling player inputs, supports cross-platform input.
/// </summary>
public class InputService : Singleton<InputService>
{
    /// <summary>
    /// Gets directional movement input from the player.
    /// </summary>
    public Vector2 GetMovement() => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    /// <summary>
    /// Checks if jump button was pressed.
    /// </summary>
    public bool IsJumpPressed() => Input.GetButtonDown("Jump");

    /// <summary>
    /// Checks if attack button was pressed.
    /// </summary>
    public bool IsAttackPressed() => Input.GetButtonDown("Fire1");
}
