using MemoryMatch.Core.ApplicationStates.ControllerInterfaces;
using MemoryMatch.Models;
using System.Linq;
using UnityEngine;

namespace MemoryMatch.Core.ApplicationStates.States
{
    public class EndGameState : BaseApplicationState
    {
        public EndGameState(IStateManagable manager) : base(manager)
        {
        }

        public override int ID => (int)StateIndex.End;

        public override string Name => StateIndex.End.ToString();

        private IEndGameControllable m_EndGameplayController;

        public override void StateIn(params object[] args)
        {
            Debug.Log($"[StateIn] Enter {Name}");
            m_EndGameplayController = Object.FindObjectsOfType<MonoBehaviour>().OfType<IEndGameControllable>().FirstOrDefault();
            m_EndGameplayController.ShowGameEndUI();
            m_EndGameplayController.OnBackToMenu += BackToMenuHandler;
            m_EndGameplayController.OnRestart += RestartGameHandler;
        }

        public override void StateOut()
        {
            Debug.Log($"[StateOut] Exit {Name}");
            m_EndGameplayController.OnBackToMenu -= BackToMenuHandler;
            m_EndGameplayController.OnRestart -= RestartGameHandler;
        }

        private void RestartGameHandler()
        {
            m_AppStateManager.StartLoadScene(StateIndex.Gameplay);
        }

        private void BackToMenuHandler()
        {
            m_AppStateManager.StartLoadScene(StateIndex.Starter);
        }
    }
}