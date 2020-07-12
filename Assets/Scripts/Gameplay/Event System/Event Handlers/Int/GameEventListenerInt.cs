using UnityEngine;

/// <summary>
/// An event listener that triggers the provided Game Event Scriptable Object.
/// Following the Unity Architecture: https://unity.com/how-to/architect-game-code-scriptable-objects
/// </summary>
namespace LegDay.Events
{
    public class GameEventListenerInt : MonoBehaviour
    {
        public GameEventInt Event;
        public IntEvent Reponse;

        private void OnEnable() { Event.RegisterListener(this); }
        private void OnDisable() { Event.UnregisterListener(this); }
        public void OnEventRaise(int value) { Reponse.Invoke(value); }
    }
}