using System.Collections;
using UnityEngine;

namespace LegDay.Interaction
{
    public class ExtinguisherHandler : EventHandler
    {
        [SerializeField]
        private float thrustSpeed = 30.0f;
        [SerializeField]
        private float rotateSpeed = 0.5f;
        [SerializeField]
        private float rotateDelay = 1.0f;

        [SerializeField]
        private Transform extinguisherModel;
        [SerializeField]
        private Transform microwaveLocation;

        public override void TriggerEvent() 
        {
            base.TriggerEvent();
            StartCoroutine(MoveToObject(extinguisherModel, microwaveLocation.position, thrustSpeed, rotateSpeed, rotateDelay));
        }

        private IEnumerator MoveToObject(Transform originalObject, Vector3 targetPosition, float moveSpeed, float rotationSpeed, float rotateDelay)
        {
            originalObject.SetParent(null);
            Rigidbody rigidbody = originalObject.GetComponent<Rigidbody>();

            float startTime = Time.time;

            while (Vector3.Distance(originalObject.position, targetPosition) > 2.0f)
            {
                if (Time.time - startTime > rotateDelay)
                {
                    Vector3 direction = targetPosition - originalObject.position;
                    originalObject.up = Vector3.Lerp(originalObject.up, direction, Time.deltaTime * rotationSpeed);
                }

                rigidbody.AddForce(originalObject.transform.up * moveSpeed, ForceMode.Acceleration);
                yield return null;
            }

            Destroy(originalObject.gameObject);
            //Display Particles
        }
    }
}