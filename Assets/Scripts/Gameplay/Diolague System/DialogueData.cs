using UnityEngine;

namespace LegDay.Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue-Data", menuName = "ScriptableObjects/Data/Dialogue-Data")]
    public class DialogueData : ScriptableObject
    {
        [SerializeField]
        private string[] names;

        [TextArea(0, 10)]
        [SerializeField]
        private string[] dialogue;

        public string GetRandomName() { return names[Random.Range(0, names.Length)]; }
        public string GetRandomDialogue() { return dialogue[Random.Range(0, dialogue.Length)]; }
    }
}