using UnityEngine;
using UnityEngine.Events;

//Based on Dapper Dino Scriptable Object Event System
//https://www.youtube.com/watch?v=iXNwWpG7EhM
//https://www.youtube.com/watch?v=P-U7GPXMtLY

namespace ScriptableObjects.Events
{
    //Crreates interface with Type, Event, UnityEventResponse
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour,
        IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField] private E gameEvent;
        public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }

        [SerializeField] private UER unityEventResponse;

        private void OnEnable()
        {
            if (gameEvent == null) { return; }

            GameEvent.AddListener(this);
        }

        private void OnDisable()
        {
            if (gameEvent == null) { return; }

            GameEvent.RemoveListener(this);
        }

        public void OnEventRaised(T item)
        {
            if (unityEventResponse != null)
            {
                unityEventResponse.Invoke(item);
            }

        }
    }
}


