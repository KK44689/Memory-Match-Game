using UnityEngine;

namespace MemoryMatch.Core.ApplicationStates.States
{
    public class StarterState : BaseApplicationState
    {
        public StarterState(AppStateManager manager) : base(manager) { }

        public override int ID => (int)StateIndex.Starter;

        public override string Name => StateIndex.Starter.ToString();

        public override void StateIn(params object[] args)
        {
            Debug.Log($"[StateIn] Enter {Name}");
            m_AppStateManager.ChangeStateTo(StateIndex.Gameplay);
        }

        public override void StateOut()
        {
            Debug.Log($"[StateOut] Exit {Name}");
        }
    }
}