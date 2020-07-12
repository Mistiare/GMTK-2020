using UnityEngine;
using LegDay.Events;

namespace LegDay.Data
{
    [CreateAssetMenu(fileName = "Checklist", menuName = "ScriptableObjects/Data/Checklist")]
    public class Checklist : ScriptableObject
    {
        public Task[] tasks;
        [SerializeField]
        private GameEventInt onTaskComplete;

        private void OnEnable()
        {
            ResetAllTasks();
        }

        public void CompleteTask(GameEvent gameEvent)
        {
            for (int i = 0; i < tasks.Length; i++)
                if (tasks[i].gameEvent == gameEvent && !tasks[i].isCompleted)
                {
                    tasks[i].isCompleted = true;
                    onTaskComplete.Raise(i);
                }
        }

        private void ResetAllTasks()
        {
            for (int i = 0; i < tasks.Length; i++)
                tasks[i].isCompleted = false;
        }
    }
}


