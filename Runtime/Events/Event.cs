using System;
using System.Collections.Generic;
using UnityEngine;

namespace AKRGS.Framework.Events
{

    public class Event : ScriptableObject
    {

        class EventListner
        {
            public object listenterObject;
            public Action callbackhandler;
           
        }

        private object _owner;
        private List<EventListner> _eventListners = new List<EventListner>();

        public bool ClaimOwnership(UnityEngine.Object owner)
        {
            if (_owner!=null)
            {
                return false;
            }
            _owner = owner;
            return true;
        }


        public void AddListner(object listner, Action callbackHandler)
        {
            if (FindIndexof(listner) >= 0)
                return;

            var listnerinput = new EventListner
            {
                listenterObject = listner,
                callbackhandler=callbackHandler

            };

            _eventListners.Add(listnerinput);

        }

        public void RemoveLIstner(object listner)
        {
            int index = FindIndexof(listner);
            if (index>=0)
            {
                _eventListners.RemoveAt(index);
            }
        }

        public void Raise(object arg)
        {
            if (arg == _owner)
            {
                for (int i=_eventListners.Count-1;i>=0; i--)
                {
                    _eventListners[i].callbackhandler();
                }
            }
        }

        
        private int FindIndexof(object listner)
        {
            return _eventListners.FindIndex(item=>item.listenterObject==listner);
        }

       
    }
}