using System.Collections;
using UnityEngine;
using LegDay.Events;

namespace LegDay.Interaction
{
    public class EventHandler : MonoBehaviour
    {
        [SerializeField]
        private GameEvent gameEvent;

        private void OnTriggerEnter(Collider col)
        {
            //if (col.GetComponent<[MovementClass]>() && isKicking)
            //TriggerEvent();
        }

        public virtual void TriggerEvent() { gameEvent.Raise(); }
    }
}