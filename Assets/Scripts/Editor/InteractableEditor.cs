using UnityEngine;
using UnityEditor;
using LegDay.Interaction;

namespace LegDay.Tools
{
    [CustomEditor(typeof(Interactable), true)]
    public class InteractableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Interactable interactable = (Interactable)target;

            if (GUILayout.Button("Debug the Method"))
                interactable.InteractObject();
        }
    }
}