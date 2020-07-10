using LegDay.Events;
using UnityEngine;

namespace LegDay.Interaction
{
    public class EventHandler : MonoBehaviour
    {
        [SerializeField]
        private GameEvent gameEvent;

        public void TriggerEvent() { gameEvent.Raise(); }
    }
}