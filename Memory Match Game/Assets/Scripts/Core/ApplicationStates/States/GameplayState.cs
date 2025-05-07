using UnityEngine;

namespace MemoryMatch.Core.ApplicationStates.States
{
    public class GameplayState : BaseApplicationState
    {
        public GameplayState(AppStateManager manager) : base(manager)
        {
        }

        public override int ID => (int)StateIndex.Gameplay;

        public override string Name => StateIndex.Gameplay.ToString();

        public override void StateIn(params object[] args)
        {
            Debug.Log($"[StateIn] Enter {Name}");
        }

        public override void StateOut()
        {
            Debug.Log($"[StateOut] Exit {Name}");
        }
    }
}