using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event listener that triggers the provided Game Event Scriptable Object.
/// Following the Unity Architecture: https://unity.com/how-to/architect-game-code-scriptable-objects
/// </summary>
namespace LegDay.Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Reponse;

        private void OnEnable() { Event.RegisterListener(this); }
        private void OnDisable() { Event.UnregisterListener(this); }
        public void OnEventRaise() { Reponse.Invoke(); }
    }
}