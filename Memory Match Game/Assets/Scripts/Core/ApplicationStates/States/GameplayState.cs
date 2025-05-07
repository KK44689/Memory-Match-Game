using MemoryMatch.Core.ApplicationStates.ControllerInterfaces;
using MemoryMatch.Models;
using System.Linq;
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

        private ICardControllable m_CardController;

        public override void StateIn(params object[] args)
        {
            Debug.Log($"[StateIn] Enter {Name}");
            m_CardController = Object.FindObjectsOfType<MonoBehaviour>().OfType<ICardControllable>().FirstOrDefault();
            m_CardController.GenerateCards();
        }

        public override void StateOut()
        {
            Debug.Log($"[StateOut] Exit {Name}");
        }
    }
}