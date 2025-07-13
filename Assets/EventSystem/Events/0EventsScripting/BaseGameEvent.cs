using System.Collections.Generic;
using UnityEngine;

//Based on Dapper Dino Scriptable Object Event System
//https://www.youtube.com/watch?v=iXNwWpG7EhM
//https://www.youtube.com/watch?v=P-U7GPXMtLY

namespace ScriptableObjects.Events
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>();

        public void Raise(T item)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
            {
                eventListeners[i].OnEventRaised(item);
            }
        }

        public void AddListener(IGameEventListener<T> listener) 
        {
            if(!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        public void RemoveListener(IGameEventListener<T> listener)
        {
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }
        }
    }
}

