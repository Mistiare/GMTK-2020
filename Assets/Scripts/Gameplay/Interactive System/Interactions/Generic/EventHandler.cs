using UnityEngine;
using LegDay.Events;

namespace LegDay.Interaction
{
    public class EventHandler : MonoBehaviour
    {
        [SerializeField]
        private GameEvent gameEvent;
        [SerializeField]
        private float interactVelocity = 1.0f;

        private const int legLayer = 9;

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.layer == legLayer)
            {
                Rigidbody rigidBody = col.GetComponent<Rigidbody>();
                if (rigidBody.velocity.magnitude > interactVelocity)
                    TriggerEvent();
            }
        }

        public virtual void TriggerEvent() { gameEvent.Raise(); }
    }
}