using UnityEngine;
using UnityEditor;
using LegDay.Dialogue;

namespace LegDay.Tools
{
    [CustomEditor(typeof(CharacterDialogue), true)]
    public class CharacterDialogueEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CharacterDialogue dialogue = (CharacterDialogue)target;

            if (GUILayout.Button("Say Something!"))
                dialogue.LoadRandomDialogue();
        }
    }
}