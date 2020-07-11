using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using LegDay.Events;

namespace LegDay.Dialogue
{
    public class CharacterDialogue : MonoBehaviour
    {
        [SerializeField]
        private DialogueData dialogueData;
        [SerializeField]
        private float dialogueSpeed = 0.01f;
        [SerializeField]
        private float endDelay = 1.0f;

        [SerializeField]
        private StringEvent OnNameChange;
        [SerializeField]
        private StringEvent OnDialogueChange;
        [SerializeField]
        private UnityEvent OnDialogueStart;
        [SerializeField]
        private UnityEvent OnDialogueEnd;

        private new string name;
        private string currentDialogue;

        private Coroutine coroutine;

        private void Start() 
        {
            name = dialogueData.GetRandomName();
            OnNameChange?.Invoke(name);

            //Remove to prevent it doing it on the start
            LoadRandomDialogue();
        }

        public void LoadRandomDialogue()
        {
            currentDialogue = dialogueData.GetRandomDialogue();

            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(LoadDialogue(currentDialogue, dialogueSpeed, endDelay));
        }

        private IEnumerator LoadDialogue(string dialogue, float characterDelay, float endDelay)
        {
            OnDialogueStart?.Invoke();

            string currentDialogue = "";
            foreach (char character in dialogue)
            {
                currentDialogue += character;
                OnDialogueChange?.Invoke(currentDialogue);

                yield return new WaitForSeconds(characterDelay);
            }

            yield return new WaitForSeconds(endDelay);
            OnDialogueEnd?.Invoke();
        }
    }
}
