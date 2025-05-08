using MemoryMatch.Core.EndGame;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MemoryMatch.UI
{
    public class EndGameUI : MonoBehaviour, IEndGameUI
    {
        [SerializeField]
        private GameObject m_EndGameplayUI;

        [SerializeField]
        private Button m_BackToMenuButton;

        [SerializeField]
        private Button m_RestartButton;

        public UnityAction OnBackToMenu { get; set; }

        public UnityAction OnRestart { get; set; }

        private void Awake()
        {
            m_BackToMenuButton.onClick.AddListener(BackToMenuHandler);
            m_RestartButton.onClick.AddListener(RestartGameplyHandler);
        }

        private void RestartGameplyHandler()
        {
            OnRestart?.Invoke();
            m_RestartButton.onClick.RemoveListener(RestartGameplyHandler);
        }

        private void BackToMenuHandler()
        {
            OnBackToMenu?.Invoke();
            m_BackToMenuButton.onClick.RemoveListener(BackToMenuHandler);
        }

        public void SetActiveEndGameUI(bool IsActive)
        {
            m_EndGameplayUI.SetActive(IsActive);
        }
    }
}