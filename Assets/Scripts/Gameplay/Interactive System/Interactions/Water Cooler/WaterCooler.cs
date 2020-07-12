using UnityEngine;

namespace LegDay.Interaction
{   
    public class WaterCooler : Interactable
    {
        [SerializeField]
        private float force;
        [SerializeField]
        private Rigidbody rigidBody;

        private void Start()
        {
            if (!rigidBody)
                rigidBody = this.GetComponent<Rigidbody>();
        }

        public override void InteractObject()
        {
            base.InteractObject();

        }
        public void KickObject(Transform player)
        {
            rigidBody.isKinematic = false;
            rigidBody.AddForce((rigidBody.position - player.position).normalized * force, ForceMode.Impulse);
        }
    }
}