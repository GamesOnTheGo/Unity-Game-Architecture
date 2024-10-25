using UnityEngine;

/// <summary>
/// Handles the visual representation of the player,
/// including animations and effects triggered by the player's actions.
/// </summary>
public class PlayerView : MonoBehaviour
{
    private Animator animator;  // Reference to the Animator component
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    /// <summary>
    /// Initialize components and caching animator and renderer references.
    /// </summary>
    private void Awake()
    {
        animator = GetComponent<Animator>();  // Get the Animator for player animations
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get SpriteRenderer for visual effects
    }

    /// <summary>
    /// Updates the movement animations based on the player’s speed.
    /// </summary>
    public void UpdateMovementAnimation(Vector2 movement)
    {
        // Update animator parameters to match movement direction
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    /// <summary>
    /// Triggers the jump animation.
    /// </summary>
    public void TriggerJumpAnimation()
    {
        animator.SetTrigger("Jump");  // Trigger jump animation in Animator
    }

    /// <summary>
    /// Triggers the damage visual effect.
    /// </summary>
    public void TakeDamageEffect()
    {
        // Change color to indicate damage taken
        spriteRenderer.color = Color.red;
        // Optionally reset color back to normal after a delay
        Invoke(nameof(ResetColor), 0.2f);
    }

    /// <summary>
    /// Resets player color to default after damage effect.
    /// </summary>
    private void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }
}
