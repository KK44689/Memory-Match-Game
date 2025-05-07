using MemoryMatch.Core.ApplicationStates.ControllerInterfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MemoryMatch.Core.Menu
{
    public class MenuController : MonoBehaviour, IMenuControllable
    {
        public UnityAction OnGameplayStarted { get; set; }

        // Update is called once per frame
        void Update()
        {
            if(Input.anyKeyDown)
            {
                OnGameplayStarted?.Invoke();
            }
        }
    }
}