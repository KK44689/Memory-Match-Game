using MemoryMatch.Models;
using UnityEngine;

namespace MemoryMatch.Core.ApplicationStates.States
{
    public class EndGameState : BaseApplicationState
    {
        public EndGameState(AppStateManager manager) : base(manager)
        {
        }

        public override int ID => (int)StateIndex.End;

        public override string Name => StateIndex.End.ToString();

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