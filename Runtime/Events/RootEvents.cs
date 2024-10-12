using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AKRGS.Framework.Events
{
    [Serializable]
    public class RootEvents<T> : ScriptableObject 
    {
      
        private List<Action<T>> listeners = new List<Action<T>>();

        public void RegisterListener(Action<T> listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
            else
            {
                Debug.LogWarning("Listener already registered.");
            }
        }

        public void UnregisterListener(Action<T> listener)
        {
            listeners.Remove(listener);
        }

        public void RemoveAll(Action<T> actions)
        {
            listeners.RemoveAll((obj)=> obj.Equals(actions));
        }

        public void Raise(T arg)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].Invoke(arg);
            }
        }

    }
    
}
