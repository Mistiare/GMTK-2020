using UnityEngine;
using UnityEditor;
using LegDay.Events;

namespace LegDay.Tools
{
    [CustomEditor(typeof(GameEvent), true)]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GameEvent gameEvent = (GameEvent)target;
            if (GUILayout.Button("Trigger Event"))
                gameEvent.Raise();
        }
    }
}
