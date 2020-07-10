using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Scriptable Object that stores all of the GameEventListeners that are subscribed to it.
/// Following the Unity Architecture: https://unity.com/how-to/architect-game-code-scriptable-objects
/// </summary>
namespace LegDay.Events
{
    [CreateAssetMenu(fileName = "Game-Event", menuName = "ScriptableObjects/Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaise();
        }

        public void RegisterListener(GameEventListener listener) { listeners.Add(listener); }
        public void UnregisterListener(GameEventListener listener) { listeners.Add(listener); }
    }

}