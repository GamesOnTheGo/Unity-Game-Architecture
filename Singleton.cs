using UnityEngine;

/// <summary>
/// Singleton base class for ensuring only one instance exists.
/// Helps manage global systems like GameManager and InputManager.
/// </summary>
/// <typeparam name="T">Type of the singleton class inheriting from MonoBehaviour</typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Static instance to provide global access
    private static T _instance;

    /// <summary>
    /// Public property to get the instance, creating it if it doesn’t exist.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<T>(); // Finds or creates the instance in the scene
            return _instance;
        }
    }

    /// <summary>
    /// Ensures only one instance of the singleton exists in the scene.
    /// </summary>
    protected virtual void Awake()
    {
        if (_instance == null)
            _instance = this as T; // Assigns the current instance
        else
            Destroy(gameObject); // Destroy duplicate instance to enforce singleton pattern
    }
}
