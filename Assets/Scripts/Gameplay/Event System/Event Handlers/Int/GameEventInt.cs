using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Scriptable Object that stores all of the GameEventListeners that are subscribed to it.
/// Following the Unity Architecture: https://unity.com/how-to/architect-game-code-scriptable-objects
/// </summary>
namespace LegDay.Events
{
    [CreateAssetMenu(fileName = "Game-Event-Int", menuName = "ScriptableObjects/Events/GameEventInt")]
    public class GameEventInt : ScriptableObject
    {
        private List<GameEventListenerInt> listeners = new List<GameEventListenerInt>();

        public void Raise(int value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaise(value);
        }

        public void RegisterListener(GameEventListenerInt listener) { listeners.Add(listener); }
        public void UnregisterListener(GameEventListenerInt listener) { listeners.Remove(listener); }
    }

}