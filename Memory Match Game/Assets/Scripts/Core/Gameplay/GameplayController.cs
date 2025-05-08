using MemoryMatch.Core.ApplicationStates.ControllerInterfaces;
using System.Linq;
using UnityEngine;

namespace MemoryMatch.Core.Gameplay
{
    public class GameplayController : MonoBehaviour, IGameplayControllable
    {
        private ICardControllable m_CardController;

        private void Awake()
        {
            m_CardController = Object.FindObjectsOfType<MonoBehaviour>().OfType<ICardControllable>().FirstOrDefault();
        }

        public void StartGameplay()
        {
            m_CardController.GenerateCards();
        }
    }
}