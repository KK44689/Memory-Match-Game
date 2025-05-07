using MemoryMatch.Core.ApplicationStates.States;
using MemoryMatch.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace MemoryMatch.Core.ApplicationStates
{
    public class AppStateManager : MonoSingleton<AppStateManager>
    {
        public static BaseApplicationState CurrentState { get; private set; }

        protected Dictionary<StateIndex, BaseApplicationState> m_ApplicationStateList;

        public UnityEvent OnCompleteLoadScene;

        public override void Awake()
        {
            base.Awake();
            InitialStates();
            ChangeStateTo(StateIndex.Starter);
        }

        protected void InitialStates()
        {
            m_ApplicationStateList = new()
            {
                { StateIndex.Starter, new StarterState(this) },
                { StateIndex.Gameplay, new GameplayState(this) },
                { StateIndex.End, new EndGameState(this) }
            };
        }

        public void ChangeStateTo(StateIndex stateId, params object[] args)
        {
            var newState = m_ApplicationStateList[stateId];

            if(newState == null)
            {
                throw new System.Exception("New State is null!");
            }
            else
            {
                if(CurrentState != null)
                {
                    CurrentState.StateOut();
                }

                CurrentState = newState;
                CurrentState.StateIn(args);
            }
        }

        public void StartLoadScene(StateIndex stateId, params object[] args)
        {
            StartCoroutine(LoadAsyncScene(stateId, args));
        }

        public IEnumerator LoadAsyncScene(StateIndex stateId, params object[] args)
        {
            var asyncLoad = SceneManager.LoadSceneAsync((int)stateId);

            while(!asyncLoad.isDone)
            {
                yield return null;
            }

            OnCompleteLoadScene?.Invoke();
            ChangeStateTo(stateId, args);
        }
    }
}