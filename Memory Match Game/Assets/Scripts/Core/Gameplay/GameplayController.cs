using MemoryMatch.Core.ApplicationStates.ControllerInterfaces;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace MemoryMatch.Core.Gameplay
{
    public class GameplayController : MonoBehaviour, IGameplayControllable
    {
        private ICardControllable m_CardController;

        public UnityAction OnGameplayEnded { get; set; }

        private void Awake()
        {
            m_CardController = Object.FindObjectsOfType<MonoBehaviour>().OfType<ICardControllable>().FirstOrDefault();
        }

        public void StartGameplay()
        {
            m_CardController.GenerateCards();
            m_CardController.OnAllCardFliped += HandleGameplayEnd;
        }

        private void HandleGameplayEnd()
        {
            m_CardController.OnAllCardFliped -= HandleGameplayEnd;
            OnGameplayEnded?.Invoke();
        }
    }
}