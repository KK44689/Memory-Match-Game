using MemoryMatch.Core.ApplicationStates.ControllerInterfaces;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace MemoryMatch.Core.EndGame
{
    public class EndGameController : MonoBehaviour, IEndGameControllable
    {
        public UnityAction OnBackToMenu { get; set; }

        public UnityAction OnRestart { get; set; }

        private IEndGameUI m_EndGameUI;

        void Awake()
        {
            m_EndGameUI = Object.FindObjectsOfType<MonoBehaviour>().OfType<IEndGameUI>().FirstOrDefault();
            m_EndGameUI.OnBackToMenu += BackToMenuHandler;
            m_EndGameUI.OnRestart += RestartHandler;
        }

        private void OnDestroy()
        {
            m_EndGameUI.OnBackToMenu -= BackToMenuHandler;
            m_EndGameUI.OnRestart -= RestartHandler;
        }

        private void RestartHandler()
        {
            OnRestart?.Invoke();
        }

        private void BackToMenuHandler()
        {
            OnBackToMenu?.Invoke();
        }

        public void ShowGameEndUI(string timerText)
        {
            m_EndGameUI.SetActiveEndGameUI(true);
            m_EndGameUI.SetTimerText(timerText);
        }
    }
}