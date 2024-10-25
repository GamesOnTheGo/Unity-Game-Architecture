using System;
using System.Collections.Generic;

/// <summary>
/// EventService allows different parts of the game to communicate without direct dependencies.
/// This is done by subscribing and triggering events, following the Observer pattern.
/// </summary>
public class EventService : Singleton<EventService>
{
    // Dictionary to store events and their listeners
    private Dictionary<string, Action<object>> events = new Dictionary<string, Action<object>>();

    /// <summary>
    /// Registers a listener for a specific event.
    /// </summary>
    public void RegisterListener(string eventName, Action<object> listener)
    {
        if (events.TryGetValue(eventName, out var thisEvent))
            events[eventName] += listener; // Append listener
        else
            events.Add(eventName, listener); // Add new event with listener
    }

    /// <summary>
    /// Removes a listener from a specific event.
    /// </summary>
    public void RemoveListener(string eventName, Action<object> listener)
    {
        if (events.TryGetValue(eventName, out var thisEvent))
            events[eventName] -= listener; // Remove listener
    }

    /// <summary>
    /// Triggers an event, notifying all subscribed listeners.
    /// </summary>
    public void TriggerEvent(string eventName, object param = null)
    {
        if (events.TryGetValue(eventName, out var thisEvent))
            thisEvent?.Invoke(param); // Notify all listeners with event parameter
    }
}
