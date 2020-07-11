using System;
using UnityEngine;
using UnityEngine.UI;

namespace LegDay.Interaction
{
    [Serializable]
    public enum PCState { BROKEN, FIXED };

    public class PCRepair : Interactable
    {
        [SerializeField]
        private float repairDelay = 1.0f;
        [SerializeField]
        private PCState state;

        public override void InteractObject()
        {
            base.InteractObject();

            InvertState();
            ToggleState((int)state);
        }

        private void InvertState(){ state = (state == PCState.BROKEN) ? PCState.FIXED : PCState.BROKEN; }

        /// <param name="state"></param>
        /// <remarks>Unity still doesn't support enums on UnityEvents.</remarks>
        public void ToggleState(int state)
        {
            this.state = (PCState)state;
            //Disable the fire particles or something
        }
    }
}