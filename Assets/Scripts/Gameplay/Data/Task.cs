using LegDay.Events;
using System;

namespace LegDay.Data 
{
    [Serializable]
    public struct Task 
    {
        public string taskName;
        public GameEvent gameEvent;
        public bool isCompleted;
    } 

}
