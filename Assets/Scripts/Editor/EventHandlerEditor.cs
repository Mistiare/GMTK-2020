using UnityEngine;
using UnityEditor;
using LegDay.Interaction;

namespace LegDay.Tools
{
    [CustomEditor(typeof(EventHandler), true)]
    public class EventHandlerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EventHandler eventHandler = (EventHandler)target;

            if (GUILayout.Button("Trigger Event"))
                eventHandler.TriggerEvent();
        }
    }
}