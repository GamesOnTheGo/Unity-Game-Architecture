using UnityEngine;

/// <summary>
/// Controller to manage player-specific actions, connecting input to player behavior.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public PlayerModel model; // Reference to player data model
    private MovementComponent movement; // Handles physical movement of the player

    /// <summary>
    /// Initializes player components.
    /// </summary>
    private void Awake() => movement = GetComponent<MovementComponent>();

    /// <summary>
    /// Handles player actions every frame.
    /// </summary>
    private void Update()
    {
        Vector2 moveInput = InputService.Instance.GetMovement();
        movement.Move(moveInput, model.speed);

        if (InputService.Instance.IsJumpPressed() && !model.isJumping)
        {
            model.isJumping = true;
            movement.Jump(10f); // Apply jump force
        }
    }

    public void TakeDamage(int amount)
    {
        model.health -= amount;
        if (model.health <= 0)
            EventService.Instance.TriggerEvent("PlayerDied", null); // Trigger death event
    }
}
