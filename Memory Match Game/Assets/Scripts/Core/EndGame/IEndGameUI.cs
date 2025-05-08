using UnityEngine.Events;

namespace MemoryMatch.Core.EndGame
{
    public interface IEndGameUI
    {
        UnityAction OnBackToMenu { get; set; }
        UnityAction OnRestart { get; set; }

        void SetActiveEndGameUI(bool IsActive);

        void SetTimerText(string text);
    }
}