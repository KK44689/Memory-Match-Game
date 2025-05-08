using UnityEngine.Events;

namespace MemoryMatch.Core.ApplicationStates.ControllerInterfaces
{
    public interface IEndGameControllable
    {
        UnityAction OnBackToMenu { get; set; }

        UnityAction OnRestart { get; set; }

        void ShowGameEndUI(string timerText);
    }
}