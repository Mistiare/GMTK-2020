using UnityEngine;
using TMPro;
using LegDay.Events;

namespace LegDay.Dialogue
{
    public class CharacterDialogue : MonoBehaviour
    {
        [SerializeField]
        private DialogueData dialogueData;

        [SerializeField]
        private StringEvent OnNameChange;
        [SerializeField]
        private StringEvent OnDialogueChange;

        private string name;
        private string currentDialogue;

        private void Start() 
        {
            name = dialogueData.GetRandomName();
            OnNameChange?.Invoke(name);
        }
        
        private void DrawDialogue()
        {

        }
    }
}
