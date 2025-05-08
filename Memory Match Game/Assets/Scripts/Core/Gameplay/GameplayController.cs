using MemoryMatch.Core.ApplicationStates.ControllerInterfaces;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace MemoryMatch.Core.Gameplay
{
    public class GameplayController : MonoBehaviour, IGameplayControllable
    {
        [SerializeField]
        private TMP_Text m_TimerText;

        private ICardControllable m_CardController;

        private float m_TimeElapsed = 0f;

        private bool m_IsGameEnd = false;

        public UnityAction<string> OnGameplayEnded { get; set; }

        private void Awake()
        {
            m_CardController = Object.FindObjectsOfType<MonoBehaviour>().OfType<ICardControllable>().FirstOrDefault();
        }

        private void Update()
        {
            if(!m_IsGameEnd) UpdateTimer();
        }

        public void StartGameplay()
        {
            m_CardController.GenerateCards();
            m_CardController.OnAllCardFliped += HandleGameplayEnd;
        }

        private void UpdateTimer()
        {
            m_TimeElapsed += Time.deltaTime;
            int minutes = Mathf.FloorToInt(m_TimeElapsed / 60);
            int seconds = Mathf.FloorToInt(m_TimeElapsed % 60);
            m_TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void HandleGameplayEnd()
        {
            m_IsGameEnd = true;
            m_CardController.OnAllCardFliped -= HandleGameplayEnd;
            OnGameplayEnded?.Invoke(m_TimerText.text);
        }
    }
}