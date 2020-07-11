using UnityEngine;

namespace LegDay.Interaction
{
    public class MicrowaveExplosion : Interactable
    {
        [SerializeField]
        private float timeToDestroy = 1.0f;

        public override void InteractObject()
        {
            base.InteractObject();
            ExplodeMicrowave(timeToDestroy);
        }

        private void ExplodeMicrowave(float delay)
        {
            // Play explosion effects
            //Destroy(this.gameObject, delay);
        }
    }
}